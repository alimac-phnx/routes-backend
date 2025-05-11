using Microsoft.AspNetCore.Mvc;
using WebRoutes.Dtos.RequestDtos;
using WebRoutes.Dtos.ResponseDtos;
using WebRoutes.Dtos.ResponseDtos.User;
using WebRoutes.Services.Users;

namespace WebRoutes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfileResponseDto>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UserCreateRequestDto userCreateRequestDto)
        {
            var response = await _userService.CreateUserAsync(userCreateRequestDto);
            
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("User could not be created.");
            }
    
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UserUpdateRequestDto userUpdateRequestDto)
        {
            var response = await _userService.UpdateUserAsync(id, userUpdateRequestDto);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("User does not exist.");
            }
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}