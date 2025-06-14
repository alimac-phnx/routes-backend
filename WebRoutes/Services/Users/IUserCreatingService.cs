using WebRoutes.Dtos.RequestDtos.User;
using WebRoutes.Models;

namespace WebRoutes.Services.Users;

public interface IUserCreatingService
{
    User Initialize(RegisterRequestDto registerRequestDto);
}