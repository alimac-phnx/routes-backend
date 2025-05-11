using System.ComponentModel.DataAnnotations;

namespace WebRoutes.Dtos.RequestDtos;

public class UserUpdateRequestDto
{
    public string? Username { get; init; }
        
    public string? LastName { get; init; }
        
    public string? FirstName { get; init; }
        
    public string? SecondName { get; init; }
        
    public IFormFile? Image { get; init; }
}