using WebRoutes.Dtos.RequestDtos.Marks;

namespace WebRoutes.Services.Marks;

public interface IMarkService
{
    Task<HttpResponseMessage> CreateMarkAsync(MarkCreateRequestDto markCreateRequest);

    Task DeleteMarkAsync(int id);
}