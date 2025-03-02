using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using My_API.DTO;
using My_API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace My_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO obj)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = obj.UserName;
                user.Email = obj.Email;
                IdentityResult result = await userManager.CreateAsync(user, obj.Password);

                if (result.Succeeded)
                {
                    return Ok("Created");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("Password Error", item.Description);
                    }
                }
            }
            return BadRequest(ModelState);

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO obj)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser? user = await userManager.FindByNameAsync(obj.UserName);

                if(user != null && await userManager.CheckPasswordAsync(user, obj.Password))
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                    var roles = await userManager.GetRolesAsync(user);
                    foreach(var item in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, item));
                    }


                    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecritKey"]));
                    SigningCredentials signingCred = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

                    JwtSecurityToken token = new JwtSecurityToken(
                        issuer: configuration["Jwt:IssuerIP"],
                        audience: configuration["Jwt:AudienceIP"],
                        expires: DateTime.Now.AddHours(1),
                        claims: claims,
                        signingCredentials: signingCred
                    );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = DateTime.Now.AddHours(1)
                    });
                    
                }
                else
                {
                    ModelState.AddModelError("Login Error", "Invalid User Name or Password");
                }
            }
            return BadRequest(ModelState);
        }
    }
}
