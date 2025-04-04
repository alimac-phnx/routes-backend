using AutoMapper;
using WebRoutes.Dtos;
using WebRoutes.Models;
using Route = WebRoutes.Models.Route;

namespace WebRoutes.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Route, RouteDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}