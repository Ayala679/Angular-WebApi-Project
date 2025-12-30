using Chinese_Auction.Dto_s;
using Chinese_Auction.Models;
using Chinese_Auction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chinese_Auction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _categoryService.GetAllCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex) {
                //log the exception here
                return BadRequest("Internal server error ocuured"+ex.Message);
            }
            

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(id);
                if (category == null) return NotFound("category with the given ID was not found");
                return Ok(category);
            }
            catch (Exception ex)
            {
                //log the exception here
                return BadRequest("Internal server error ocuured"+ex.Message);
            }

        }
        [HttpPost]

        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto createCategoryDto)
        {
            try
            {
                GetCategoryDto newCategory = await _categoryService.CreateCategoryAsync(createCategoryDto);
                return CreatedAtAction(nameof(GetCategoryById), new { Id = newCategory.Id }, newCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDto updateCategoryDto)
        {
            try
            {
                var updatedCategory = await _categoryService.UpdateCategoryAsync(id, updateCategoryDto);
                if (updatedCategory == null) return NotFound();
                return Ok(updatedCategory);
            }
            catch (Exception ex) {  
                //log the exception here

                return BadRequest(ex.Message);
            }

            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var isDeleted = await _categoryService.DeleteCategoryAsync(id);
                if (!isDeleted) return NotFound("category with the given ID was not found");
                return Ok("deleted succesfully");

            }
            catch (Exception ex)
            {
                //log the exception here
                return BadRequest("Internal server error ocuured" + ex.Message);
            }

        }



    }
}
