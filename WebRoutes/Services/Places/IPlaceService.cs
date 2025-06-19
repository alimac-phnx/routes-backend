using WebRoutes.Dtos.RequestDtos.Places;

namespace WebRoutes.Services.Places;

public interface IPlaceService
{
    Task CreatePlaceAsync(PlaceCreateRequestDto placeCreateRequestDto);
}