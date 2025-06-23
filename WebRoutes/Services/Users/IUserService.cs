using WebRoutes.Dtos.RequestDtos.Auth;
using WebRoutes.Dtos.RequestDtos.Users;
using WebRoutes.Dtos.ResponseDtos.User;

namespace WebRoutes.Services.Users;

public interface IUserService
{
    Task<IEnumerable<UserInfoResponseDto>> GetAllUsersAsync();

    Task<UserProfileResponseDto> GetUserProfileByIdAsync(int id);
        
    Task<HttpResponseMessage> CreateUserAsync(RegisterRequestDto registerRequest);
        
    Task<HttpResponseMessage> UpdateUserAsync(int id, UserUpdateRequestDto userUpdateRequest);
        
    Task<HttpResponseMessage> DeleteUserAsync(int id);
}