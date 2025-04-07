using AutoMapper;
using WebRoutes.Dtos;
using WebRoutes.Models;

namespace WebRoutes.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Trip, RouteDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}