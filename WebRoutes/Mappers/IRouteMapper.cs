using WebRoutes.Dtos.ResponseDtos.Route;
using WebRoutes.Models;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Mappers;

public interface IRouteMapper
{
    void MapInfo(Route route, (List<Coordinate> coordinates, float distance, float time) routeInfo);
    
    IEnumerable<RouteCardUserResponseDto> MapMarks(List<Route> routes, int id, int currentUserId);

    void MapPlaces(Route route, List<string?> imagesUrls);

    void MapAdditionalPlaces(Route route, List<string?>? imagesUrls);
}