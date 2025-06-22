using WebRoutes.Enums;

namespace WebRoutes.Dtos.ResponseDtos.Common;

public class UserMark
{
    public int MarkId { get; set; }
    
    public MarkType MarkType { get; set; }
}