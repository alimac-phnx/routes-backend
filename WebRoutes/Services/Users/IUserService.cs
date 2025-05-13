using WebRoutes.Dtos.RequestDtos;
using WebRoutes.Dtos.RequestDtos.User;
using WebRoutes.Dtos.ResponseDtos;
using WebRoutes.Dtos.ResponseDtos.User;

namespace WebRoutes.Services.Users;

public interface IUserService
{
    Task<IEnumerable<UserInfoResponseDto>> GetAllUsersAsync();
    
    Task<UserProfileResponseDto> GetUserByIdAsync(int id);
        
    Task<HttpResponseMessage> CreateUserAsync(UserCreateRequestDto userCreateRequestDto);
        
    Task<HttpResponseMessage> UpdateUserAsync(int id, UserUpdateRequestDto userUpdateRequestDto);
        
    Task DeleteUserAsync(int id);
}