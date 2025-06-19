using WebRoutes.Dtos.RequestDtos.AdditionalPlaces;

namespace WebRoutes.Services.AdditionalPlaces;

public interface IAdditionalPlaceService
{
    Task CreateAdditionalPlaceAsync(AdditionalPlaceCreateRequestDto additionalPlaceCreateRequestDto);
}