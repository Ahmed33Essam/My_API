using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_API.Models;
using My_API.Repositorys;

namespace My_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct Repo;

        public ProductController(IProduct product)
        {
            this.Repo = product;
        }

        [HttpGet]
        public IActionResult ShowAll()
        {
            return Ok(Repo.ShowAll());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetByID(int id)
        {
            return Ok(Repo.GetByID(id));
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            Repo.Add(product);
            Repo.Save();
            return CreatedAtAction("GetByID", new {id = product.Id}, product);
        }

        [HttpPut("{id:int}")]
        public IActionResult Edit(int id, Product product)
        {
            Product np = Repo.GetByID(id);
            if (np == null) return NotFound("Invalid ID");

            np.Name = product.Name; 
            np.Price = product.Price;
            np.Description = product.Description;
            Repo.Update(np);
            Repo.Save();

            return NoContent();
        }
    }
}
