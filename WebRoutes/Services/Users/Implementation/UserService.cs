using System.Net;
using AutoMapper;
using WebRoutes.Dtos.RequestDtos.Auth;
using WebRoutes.Dtos.RequestDtos.Users;
using WebRoutes.Dtos.ResponseDtos.User;

namespace WebRoutes.Services.Users.Implementation;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserDataService _userDataService;
    private readonly IUserCreatingService _userCreatingService;

    public UserService(IMapper mapper, IUserDataService userDataService, IUserCreatingService userCreatingService)
    {
        _mapper = mapper;
        _userDataService = userDataService;
        _userCreatingService = userCreatingService;
    }

    public async Task<IEnumerable<UserInfoResponseDto>> GetAllUsersAsync()
    {
        var users = await _userDataService.GetAllUsersAsync();
        
        return _mapper.Map<IEnumerable<UserInfoResponseDto>>(users);
    }
    
    public async Task<UserProfileResponseDto> GetUserProfileByIdAsync(int id)
    {
        var user = await _userDataService.GetUserProfileAsync(id);
        
        return _mapper.Map<UserProfileResponseDto>(user);
    }

    public async Task<HttpResponseMessage> CreateUserAsync(RegisterRequestDto registerRequest)
    {
        if (await _userDataService.GetUserByEmailAsync(registerRequest.Email) != null)
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        var user = _userCreatingService.Initialize(registerRequest);
        
        await _userDataService.CreateUserAsync(user);
        
        return new HttpResponseMessage(HttpStatusCode.Created);
    }

    public async Task<HttpResponseMessage> UpdateUserAsync(int id, UserUpdateRequestDto userUpdateRequest)
    {
        var userToUpdate = await _userDataService.GetUserByIdAsync(id);
        if (userToUpdate == null)
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
        
        var user = _mapper.Map(userUpdateRequest, userToUpdate);
        await _userDataService.UpdateUserAsync(user);
        
        return new HttpResponseMessage(HttpStatusCode.OK);
    }

    public async Task<HttpResponseMessage> DeleteUserAsync(int id)
    {
        if (await _userDataService.GetUserByIdAsync(id) == null)
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        await _userDataService.DeleteUserAsync(id);
        
        return new HttpResponseMessage(HttpStatusCode.NoContent);
    }
}