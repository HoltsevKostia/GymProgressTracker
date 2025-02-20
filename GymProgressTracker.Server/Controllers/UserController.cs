using AutoMapper;
using GymProgressTracker.Server.Models.DTO.User;
using GymProgressTracker.Server.Repositories.User;
using GymProgressTracker.Server.Services.User;
using GymProgressTracker.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymProgressTracker.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] AddUserDTO userDTO)
        {
            var result = await _userService.RegisterAsync(userDTO);

            if (result == null)
            {
                return BadRequest("User already exists.");
            }

            SetAuthCookie(result.Value.Token);

            return Ok(new { User = result.Value.User });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO)
        {
            var result = await _userService.LoginAsync(userDTO);

            if (result == null)
            {
                return BadRequest("Invalid email or password");
            }

            SetAuthCookie(result.Value.Token);

            return Ok(new {User =  result.Value.User});
        }

        private void SetAuthCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddHours(3)
            };

            Response.Cookies.Append("auth_token", token, cookieOptions);
        }
    }
}
