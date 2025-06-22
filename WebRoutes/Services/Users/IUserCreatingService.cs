using WebRoutes.Dtos.RequestDtos.Auth;
using WebRoutes.Models;

namespace WebRoutes.Services.Users;

public interface IUserCreatingService
{
    User Initialize(RegisterRequestDto registerRequest);
}