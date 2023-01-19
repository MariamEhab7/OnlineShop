using BL;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        #region DI
        private readonly ICategoryService _categoryService;
        private readonly ICategoryRepo _categoryRepo;

        public CategoryController(ICategoryService categoryService, ICategoryRepo categoryRepo)
        {
            _categoryService = categoryService;
            _categoryRepo = categoryRepo;
        }
        #endregion
      
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = _categoryRepo.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDTO category)
        {
            var result = await _categoryService.AddCategory(category);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryAddDTO category, Guid id)
        {
            var result = await _categoryService.UpdateCategory(category, id);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            _categoryService.DeleteCategory(id);
            return Ok();
        }
    }
}
