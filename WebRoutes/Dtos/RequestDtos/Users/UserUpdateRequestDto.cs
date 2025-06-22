namespace WebRoutes.Dtos.RequestDtos.Users;

public class UserUpdateRequestDto
{
    public string? Username { get; init; }
        
    public string? LastName { get; init; }
        
    public string? FirstName { get; init; }
        
    public string? SecondName { get; init; }
        
    public IFormFile? Image { get; init; }
}