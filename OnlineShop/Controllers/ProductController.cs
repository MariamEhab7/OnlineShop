using BL;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Dependancy Injection
        private readonly IProductService _productService;
        private readonly IProductRepo _productRepo;

        public ProductController(IProductService productService, IProductRepo productRepo)
        {
            _productService = productService;
            _productRepo = productRepo;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = _productRepo.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddDTO product)
        {
            var result = await _productService.AddProduct(product);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductAddDTO product, Guid id)
        {
            var result = await _productService.UpdateProduct(product, id);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            _productService.DeleteProduct(id);
            return Ok();
        }
    }
}
