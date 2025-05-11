namespace WebRoutes.Dtos.ResponseDtos.User;

public class UserInfoResponseDto
{
    public required int UserId { get; init; }
    
    public required string Username { get; init; }
        
    public string? LastName { get; init; }
        
    public string? FirstName { get; init; }
        
    public string? SecondName { get; init; }
        
    public string? ImageUrl { get; init; }
}