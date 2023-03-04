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
        [Route("getItems")]
        public async Task<IActionResult> GetAllItems()
        {
            var result = _itemRepo.GetAll();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetItemsByProduct")]
        public async Task<IActionResult> GetItemsByProduct(Guid id)
        {
            var result = await _itemServices.GetItemsOfProduct(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetItemsByPrice")]
        public async Task<IActionResult> GetItemsByPrice(int price)
        {
            var result = await _itemServices.GetItemsByPrice(price);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetItemDetails")]
        public async Task<IActionResult> GetItemDetails(Guid id)
        {
            var result = await _itemServices.GetItemDetails(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(result);
        }


        [HttpPost]
        [Route("addItem")]
        public async Task<IActionResult> AddItem([FromForm] ItemAddDTO itemAdd)
        {
            var result = await _itemServices.Additem(itemAdd);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(result);
        }
        
        [HttpPost]
        [Route("AssignValues")]
        public async Task<IActionResult> AssignValues(Guid Item, List<Guid> Values)
        {
            var result = await _itemServices.AssignVariations(Item, Values);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(result);
        }
        
        [HttpPut]
        [Route("updateItem")]
        public async Task<IActionResult> UpdateItem(ItemUpdateDTO itemAdd, Guid id)
        {
            var result = await _itemServices.UpdateItem(itemAdd, id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(result);
        }

        [HttpDelete]
        [Route("deleteItem")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            _itemServices.DeleteItem(id);
           
             if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }

    }
}
