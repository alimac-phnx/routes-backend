namespace WebRoutes.Dtos.ResponseDtos.Reviews;

public class ReviewResponseDto
{
    public required int UserId { get; init; }
    
    public required int RouteId { get; init; }
    
    public required string Text { get; init; }
    
    public required int Grade { get; init; }
}