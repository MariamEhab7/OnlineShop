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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] ProductAddDTO product)
        {
            var result = await _productService.AddProduct(product);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductAddDTO product, Guid id)
        {
            var result = await _productService.UpdateProduct(product, id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            _productService.DeleteProduct(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }


        [HttpGet]
        [Route("ChildrenProducts")]
        public async Task<IActionResult> GetChildren()
        {
            var result = await _productRepo.GetChildrenProducts();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(result);
        }
        
        [HttpGet]
        [Route("MenProducts")]
        public async Task<IActionResult> GetMen()
        {
            var result = await _productRepo.GetMenProducts();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(result);
        }

        [HttpGet]
        [Route("WomenProducts")]
        public async Task<IActionResult> GetWomen()
        {
            var result = await _productRepo.GetWomenProducts();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(result);
        }




    }
}
