using BL;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariationValuesController : ControllerBase
    {
        #region DI
        private readonly IVariationService _variationService;
        private readonly IVariationValueRepo _valueRepo;

        public VariationValuesController(IVariationService variationService, IVariationValueRepo valueRepo)
        {
            _variationService = variationService;
            _valueRepo = valueRepo;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = _valueRepo.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(VariationValAddDTO variation)
        {
            var result = await _variationService.AddVariationValue(variation);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(VariationValAddDTO variation, Guid id)
        {
            var result = await _variationService.UpdateVariationValue(variation, id);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            _variationService.DeleteVariationValue(id);
            return Ok();
        }

    }
}
