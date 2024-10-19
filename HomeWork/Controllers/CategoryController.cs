using HomeWork.Interface;
using HomeWork.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private ICategory _CategoryService;

        public CategoryController(ICategory CategoryService)
        {
             _CategoryService = CategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _CategoryService.GetAllGategory(); 
            return Ok(categories);

        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
            if (category != null)
            {
               await _CategoryService.CreateCategory(category);
                return Ok(category);
            }
            return NotFound("Can Not Add Null Value");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var GetCat =  await _CategoryService.GetCategory(id);
            if (GetCat != null) {
                return Ok(GetCat);
            }

            return NotFound("This Category Not Found");
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            var newcategory = await _CategoryService.UpdateCategory(category,id);
            if (newcategory != null)
            {
                return Ok(newcategory);
            }
            return NotFound("This Category Not Found");
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var isDeleted = await _CategoryService.DeleteCategory(id);
            if (!isDeleted) 
            {
                return NotFound("This Category Not Found");
            }
            return NotFound("This Category Is Deleted Successfully");
        }

    }
}
