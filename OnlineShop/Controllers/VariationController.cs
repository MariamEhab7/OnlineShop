using BL;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariationController : ControllerBase
    {

        #region Dependancy Injection
        private readonly IVariationService _variationService;
        private readonly IVariationRepo _variationRepo;

        public VariationController(IVariationService variationService, IVariationRepo variationRepo)
        {
            _variationService = variationService;
            _variationRepo = variationRepo;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = _variationRepo.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddValue(VariationAddDTO variation)
        {
            var result = await _variationService.AddVariation(variation);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateValue(VariationAddDTO variation, Guid id)
        {
            var result = await _variationService.UpdateVariation(variation, id);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteValue(Guid id)
        {
            _variationService.DeleteVariation(id);
            return Ok();
        }
    }
}
