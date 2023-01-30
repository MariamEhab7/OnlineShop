using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserLoginDTO userRegister)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.UserRegister(userRegister);
            return Ok(result);
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserLoginDTO userLogin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.UserLogin(userLogin);
            return Ok(result);
        } 
        
        
        [HttpPost]
        [Route("personalDetails")]
        public async Task<IActionResult> AddDetails(UserRegisterDTO user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.AddUserDetails(user);
            return Ok(result);
        }

    }
}
