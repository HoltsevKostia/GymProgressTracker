using AutoMapper;
using GymProgressTracker.Server.Models.DTO.User;
using GymProgressTracker.Server.Repositories.User;
using GymProgressTracker.Server.Services.User;
using GymProgressTracker.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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

        [Authorize]
        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("auth_token");
            return Ok(new { success = true, message = "Logged out successfully" });
        }

        [Authorize]
        [HttpGet]
        [Route("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            var user = await _userService.GetUserByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
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
