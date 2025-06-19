using AutoMapper;
using WebRoutes.Dtos.RequestDtos;
using WebRoutes.Dtos.RequestDtos.AdditionalPlaces;
using WebRoutes.Dtos.RequestDtos.Places;
using WebRoutes.Dtos.RequestDtos.Routes;
using WebRoutes.Dtos.RequestDtos.User;
using WebRoutes.Dtos.RequestDtos.Users;
using WebRoutes.Dtos.ResponseDtos;
using WebRoutes.Dtos.ResponseDtos.AdditionalPlace;
using WebRoutes.Dtos.ResponseDtos.Place;
using WebRoutes.Dtos.ResponseDtos.Route;
using WebRoutes.Dtos.ResponseDtos.User;
using WebRoutes.Enums;
using WebRoutes.Models;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LocationCreateRequestDto, Coordinate>()
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
                .ReverseMap();

            CreateMap<LocationCreateRequestDto, Point>()
                .ForMember(dest => dest.Coordinate, opt => opt.MapFrom(src => src))
                .ReverseMap();
            
            CreateMap<Location, LocationInfoResponseDto>()
                .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Point.Coordinate.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Point.Coordinate.Longitude))
                .ForMember(dest => dest.LocationImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ReverseMap();
            CreateMap<LocationCreateRequestDto, Location>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LocationName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.LocationDescription))
                .ForMember(dest => dest.Point, opt => opt.MapFrom(src => src))
                .ReverseMap();

            CreateMap<Place, PlaceInfoResponseDto>()
                .ForMember(dest => dest.LocationInfo, opt => opt.MapFrom(src => src));
            CreateMap<PlaceCreateRequestDto, Place>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LocationCreateInfo.LocationName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.LocationCreateInfo.LocationDescription))
                .ForMember(dest => dest.Point, opt => opt.MapFrom(src => src.LocationCreateInfo));
            
            CreateMap<AdditionalPlace, AdditionalPlaceInfoResponseDto>()
                .ForMember(dest => dest.LocationInfo, opt => opt.MapFrom(src => src));
            CreateMap<AdditionalPlaceCreateRequestDto, AdditionalPlace>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LocationCreateInfo.LocationName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.LocationCreateInfo.LocationDescription))
                .ForMember(dest => dest.Point, opt => opt.MapFrom(src => src.LocationCreateInfo));

            CreateMap<Route, RouteInfoResponseDto>()
                .ForMember(dest => dest.RouteId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.RouteDistance, opt => opt.MapFrom(src => src.Length))
                .ForMember(dest => dest.RouteTitle, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.RouteDescription, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.RouteRating, opt => opt.MapFrom(src => src.Rating))
                .ForMember(dest => dest.RouteType, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.DateUploaded))
                //.ForMember(dest => dest.IsFavorite, opt => opt.MapFrom(src => src.Marks.Any(m => m.MarkType == MarkType.Liked && m.UserId == (int)context.Items["CurrentUserId"])))
                .ReverseMap();
            CreateMap<Route, RouteCardResponseDto>()
                .ForMember(dest => dest.RouteInfo, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.UserInfo, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.UserCount, opt => opt.MapFrom(src => src.Marks.Count(m => m.MarkType == MarkType.Done)))
                .ReverseMap();
            CreateMap<Route, RoutePostResponseDto>()
                .ForMember(dest => dest.RouteInfo, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.RouteDuration, opt => opt.MapFrom(src => src.Duration))
                .ForMember(dest => dest.RoutePath, opt => opt.MapFrom(src => src.RoutePath))
                .ForMember(dest => dest.AuthorUsername, opt => opt.MapFrom(src => src.User.Username))
                .ForMember(dest => dest.PlacesInfos, opt => opt.MapFrom(src => src.Places))
                .ForMember(dest => dest.AdditionalPlacesInfos, opt => opt.MapFrom(src => src.AdditionalPlaces))
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews))
                .ReverseMap();

            CreateMap<RouteCreateRequestDto, Route>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.RouteTitle))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.RouteDescription))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.RouteType))
                .ForMember(dest => dest.DateUploaded, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.Places, opt => opt.MapFrom(src => src.PlacesInfos))
                .ForMember(dest => dest.AdditionalPlaces, opt => opt.MapFrom(src => src.AdditionalPlacesInfos));
            CreateMap<RouteUpdateRequestDto, Route>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.RouteTitle))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.RouteDescription))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.RouteType))
                .ForMember(dest => dest.Places, opt => opt.MapFrom(src => src.PlacesInfos))
                .ForMember(dest => dest.AdditionalPlaces, opt => opt.MapFrom(src => src.AdditionalPlacesInfos))
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            
            CreateMap<User, UserInfoResponseDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
            
            CreateMap<User, UserProfileResponseDto>()
                .ForMember(dest => dest.UserInfo, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Routes, opt => opt.MapFrom(src => src.Routes))
                .ForMember(dest => dest.SubscriptionsNumber, opt => opt.MapFrom(src => src.Subscriptions.Count(s => s.SubscriberId == src.Id)))
                .ForMember(dest => dest.FollowersNumber, opt => opt.MapFrom(src => src.Subscriptions.Count(s => s.FolloweeId == src.Id)))
                .ForMember(dest => dest.Distance, opt => opt.MapFrom(src => src.Marks
                    .Where(m => m.MarkType == MarkType.Done)
                    .Sum(m => (int)Math.Floor(m.Route.Length))))
                .ReverseMap();
            
            CreateMap<RegisterRequestDto, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ImageUrl, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UserUpdateRequestDto, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ImageUrl, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Subscription, SubscriptionResponseDto>().ReverseMap();
        }
    }
}