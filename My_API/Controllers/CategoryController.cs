using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_API.DTO;
using My_API.Models;
using My_API.Repositorys;

namespace My_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory category;

        public CategoryController(ICategory category)
        {
            this.category = category;
        }

        [HttpGet]
        public IActionResult ShowAll()
        {
            return Ok(category.ShowAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult<CateProduct> ShowById(int id)
        {
            CateProduct cateProduct = new CateProduct();
            List<string> list = category.ShowById(id);
            if(list.Count == 0)
            {
                return null;
            }
            cateProduct.Products = list;
            cateProduct.Id = id;
            cateProduct.Name = category.GetName(id);
            return cateProduct;
        }

    }
}
