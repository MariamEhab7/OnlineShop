using BL;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        #region Dependancy Injection
        private readonly IItemService _itemServices;
        private readonly IItemRepo _itemRepo;

        public ItemController(IItemService itemServices, IItemRepo itemRepo)
        {
            _itemServices = itemServices;
            _itemRepo = itemRepo;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var result = _itemRepo.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(ItemAddDTO itemAdd)
        {
            var result = await _itemServices.Additem(itemAdd);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItem(ItemUpdateDTO itemAdd, Guid id)
        {
            var result = await _itemServices.UpdateItem(itemAdd, id);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            _itemServices.DeleteItem(id);
            return Ok();
        }

    }
}
