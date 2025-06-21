using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebRoutes.Dtos.RequestDtos.Users;
using WebRoutes.Dtos.ResponseDtos.User;
using WebRoutes.Services.Users;

namespace WebRoutes.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInfoResponseDto>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("profile/{id}")]
        public async Task<ActionResult<UserProfileResponseDto>> GetUserProfile(int id)
        {
            var user = await _userService.GetUserProfileByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateUser(int id, UserUpdateRequestDto userUpdateRequestDto)
        {
            var response = await _userService.UpdateUserAsync(id, userUpdateRequestDto);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("User does not exist.");
            }
            
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}