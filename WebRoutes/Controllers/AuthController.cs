using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebRoutes.Dtos.RequestDtos.Auth;
using WebRoutes.Dtos.RequestDtos.User;
using WebRoutes.Services;
using WebRoutes.Services.Users;

namespace WebRoutes.Controllers;

[Route("api/auth")]
[ApiController]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    private readonly IJwtService _jwtService;
    private readonly IUserService _userService;
    private readonly IUserDataService _userDataService;

    public AuthController(IJwtService jwtService, IUserService userService, IUserDataService userDataService)
    {
        _jwtService = jwtService;
        _userService = userService;
        _userDataService = userDataService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequestDto registerRequest)
    {
        var response = await _userService.CreateUserAsync(registerRequest);
            
        if (!response.IsSuccessStatusCode)
        {
            return BadRequest("User could not be registered.");
        }
    
        return NoContent();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LogInRequestDto logInRequest)
    {
        var user = await _userDataService.GetUserByEmailAsync(logInRequest.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(logInRequest.Password, user.PasswordHash))
        {
            return Unauthorized("Invalid email or password.");
        }

        var token = _jwtService.GenerateToken(user);
        return Ok(new { Token = token });
    }
}
