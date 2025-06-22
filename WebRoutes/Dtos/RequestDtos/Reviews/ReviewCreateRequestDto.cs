using System.ComponentModel.DataAnnotations;

namespace WebRoutes.Dtos.RequestDtos.Reviews;

public class ReviewCreateRequestDto
{
    public required int UserId { get; init; }
    
    public required int RouteId { get; init; }
    
    [RegularExpression(@"\S+", ErrorMessage = "Review text cannot be empty or whitespace.")]
    public required string Text { get; init; }
    
    [Range(1, 5, ErrorMessage = "Grade must be between 1 and 5")]
    public required int Grade { get; init; }
}