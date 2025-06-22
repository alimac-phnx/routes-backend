using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using WebRoutes.Enums;

namespace WebRoutes.Dtos.RequestDtos.Auth;
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
    
    [DataType(DataType.Password)]
    public required string Password { get; init; }
    
    public DefaultPhotoType DefaultPhotoType { get; init; }
    
    public IFormFile? Image { get; init; }
}