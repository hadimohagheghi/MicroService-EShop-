using Microsoft.AspNetCore.Mvc;
using ProductService.Model.Dto;
using ProductService.Model.Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get()
        {
            var data = categoryService.GetCategories();
            return Ok(data);
        }

        // POST api/<CategoryController>
        //todo: For Admin
        [HttpPost]
        public IActionResult Post([FromBody] CategoryDto  categoryDto)
        {
            categoryService.AddNewCategory(categoryDto);
            return Ok();
        }
 
    }
}
