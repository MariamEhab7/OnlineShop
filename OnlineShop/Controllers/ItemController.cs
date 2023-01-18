using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemRepo _itemRepo;
        public ItemController(ItemRepo itemRepo)
        {
            _itemRepo = itemRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var result = _itemRepo.GetAll();
            return Ok(result);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddCategory()
        //{
        //    var result = _itemRepo();
        //    return Ok(result);
        //}


    }
}
