using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebRoutes.Dtos.RequestDtos.User;
public class RegisterRequestDto
{
    [RegularExpression(@"\S+", ErrorMessage = "User name cannot be empty or whitespace.")]
    public required string Username { get; init; }
    
    [RegularExpression(@"\S+", ErrorMessage = "Last name cannot be empty or whitespace.")]
    public string? LastName { get; init; }
    
    [RegularExpression(@"\S+", ErrorMessage = "First name cannot be empty or whitespace.")]
    public string? FirstName { get; init; }
    
    [RegularExpression(@"\S+", ErrorMessage = "Second name cannot be empty or whitespace.")]
    public string? SecondName { get; init; }
    
    [EmailAddress]
    public required string Email { get; init; }
    
    [PasswordPropertyText]
    public required string Password { get; init; }
    
    public IFormFile? Image { get; init; }
}