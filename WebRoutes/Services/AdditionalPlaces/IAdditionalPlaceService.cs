using WebRoutes.Dtos.RequestDtos.AdditionalPlace;

namespace WebRoutes.Services.AdditionalPlaces;

public interface IAdditionalPlaceService
{
    Task CreateAdditionalPlaceAsync(AdditionalPlaceCreateRequestDto additionalPlaceCreateRequestDto);
}