
using Microsoft.AspNetCore.Mvc;
using SuperMarket.DTO;
using SuperMarket.Models;
using SuperMarket.Services;

namespace SuperMarket.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase{
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService){

            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories(){ 

            return Ok(await _categoryService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id){ 

            var category = await _categoryService.GetById(id);
            return category == null ? NotFound() : Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDTO categoryDTO){
            
            try{
                await _categoryService.Create(categoryDTO); 
                return Ok();
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id,[FromBody] CategoryDTO categoryDTO){
  
            try{
                await _categoryService.Update(id,categoryDTO);
                return CreatedAtAction(nameof(GetCategoryById), new {name = categoryDTO.Name}, categoryDTO);
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id){
            
            var category = await _categoryService.GetById(id);
            if(category == null) return NotFound();

            await _categoryService.Delete(id);
            return NoContent();
        }

    }

}