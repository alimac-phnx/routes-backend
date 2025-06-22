using AutoMapper;
using WebRoutes.Dtos.ResponseDtos.Common;
using Route = WebRoutes.Models.Route;
using WebRoutes.Dtos.ResponseDtos.Route;
using WebRoutes.Enums;
using WebRoutes.Models;

namespace WebRoutes.Mappers;

public class RouteMapper : IRouteMapper
{
    private readonly IMapper _mapper;

    public RouteMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public void MapInfo(Route route, (List<Coordinate> coordinates, float distance, float time) routeInfo)
    {
        route.Length = routeInfo.distance;
        route.Duration = routeInfo.time;
        route.RoutePath = routeInfo.coordinates;
    }
    
    public IEnumerable<RouteCardUserResponseDto> MapMarks(List<Route> routes, int id, int currentUserId)
    {
        var likedMarks = routes
            .Where(r => r.Marks != null)
            .SelectMany(r => r.Marks!)
            .Where(m => m.MarkType == MarkType.Liked)
            .ToList();

        var mappedRoutes = _mapper.Map<IEnumerable<RouteCardUserResponseDto>>(routes).ToList();
        mappedRoutes.ForEach(r =>
        {
            var likeMark = likedMarks
                .SingleOrDefault(m => m.UserId == currentUserId && m.RouteId == r.RouteInfo.RouteId);

            r.RouteInfo.UserLike = likeMark != null
                ? new UserLike
                {
                    MarkId = likeMark.Id,
                    IsUserFavorite = true
                }
                : null;
        });
        mappedRoutes.ForEach(r =>
        {
            var likeMark = likedMarks
                .SingleOrDefault(m => m.UserId == id && m.RouteId == r.RouteInfo.RouteId);
            
            if (likeMark == null)
            {
                r.UserMarks.RemoveAll(m => m.MarkType == MarkType.Liked);
            }

        });
        
        return mappedRoutes;
    }

    public void MapPlaces(Route route, List<string?> imagesUrls)
    {
        route.Places.ToList().ForEach(place => imagesUrls.ForEach(imageUrl => place.ImageUrl = imageUrl ));
    }

    public void MapAdditionalPlaces(Route route, List<string?>? imagesUrls)
    {
        route.AdditionalPlaces?.ToList().ForEach(additionalPlace => imagesUrls?
            .ForEach(imageUrl => additionalPlace.ImageUrl = imageUrl ));
    }
}