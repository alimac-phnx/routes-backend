using AutoMapper;
using WebRoutes.Dtos.RequestDtos.AdditionalPlaces;
using WebRoutes.Models;

namespace WebRoutes.Services.AdditionalPlaces.Implementation;

public class AdditionalPlaceService : IAdditionalPlaceService
{
    private readonly IAdditionalPlaceDataService _additionalPlaceDataService;
    private readonly IMapper _mapper;

    public AdditionalPlaceService(IAdditionalPlaceDataService additionalPlaceDataService, IMapper mapper)
    {
        _additionalPlaceDataService = additionalPlaceDataService;
        _mapper = mapper;
    }
    public async Task CreateAdditionalPlaceAsync(AdditionalPlaceCreateRequestDto additionalPlaceCreateRequestDto)
    {
        var additionalPlace = _mapper.Map<AdditionalPlace>(additionalPlaceCreateRequestDto);
        
        await _additionalPlaceDataService.CreateAdditionalPlaceAsync(additionalPlace);
    }

    public async Task UpdatePlaceAsync(Models.Place place)
    {
        //_placeRepository.Update(place);
        //await _placeRepository.SaveChangesAsync();
    }

    public async Task DeletePlaceAsync(int id)
    {
        //var place = await _placeRepository.GetByIdAsync(id);
        //if (place != null)
        //{
        //    _placeRepository.Delete(place);
        //    await _placeRepository.SaveChangesAsync();
        //}
    }
}