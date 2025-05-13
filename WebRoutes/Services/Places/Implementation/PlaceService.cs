using AutoMapper;
using WebRoutes.Dtos.RequestDtos.Place;

namespace WebRoutes.Services.Places.Implementation;

public class PlaceService : IPlaceService
{
    private readonly IPlaceDataService _placeDataService;
    private readonly IMapper _mapper;

    public PlaceService(IPlaceDataService placeDataService, IMapper mapper)
    {
        _placeDataService = placeDataService;
        _mapper = mapper;
    }
    public async Task CreatePlaceAsync(PlaceCreateRequestDto placeCreateRequestDto)
    {
        var place = _mapper.Map<Models.Place>(placeCreateRequestDto);
        
        await _placeDataService.CreatePlaceAsync(place);
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