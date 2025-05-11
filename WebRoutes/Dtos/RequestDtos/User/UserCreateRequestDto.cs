using System.ComponentModel.DataAnnotations;

namespace WebRoutes.Dtos.RequestDtos;
public class UserCreateRequestDto
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
    
    public IFormFile? Image { get; init; }
}