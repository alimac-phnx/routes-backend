using WebRoutes.Enums;

namespace WebRoutes.Dtos.RequestDtos.Marks;

public class MarkCreateRequestDto
{
    public required int UserId { get; init; }
    
    public required int RouteId { get; init; }
    
    public required MarkType MarkType { get; init; }
}