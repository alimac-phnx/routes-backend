using WebRoutes.Dtos.RequestDtos.Place;

namespace WebRoutes.Services.Places;

public interface IPlaceService
{
    Task CreatePlaceAsync(PlaceCreateRequestDto placeCreateRequestDto);
}