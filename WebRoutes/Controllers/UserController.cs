using System.Security.Claims;
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

        [HttpGet("{id}/profile")]
        public async Task<ActionResult<UserProfileResponseDto>> GetUserProfile(int id)
        {
            var user = await _userService.GetUserProfileByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateUser(UserUpdateRequestDto userUpdateRequestDto)
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var response = await _userService.UpdateUserAsync(currentUserId, userUpdateRequestDto);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("User does not exist.");
            }
            
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var response = await _userService.DeleteUserAsync(currentUserId);
            
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("This user does not exist.");
            }

            return NoContent();
        }
    }
}