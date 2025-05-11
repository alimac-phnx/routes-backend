using System.Net;
using AutoMapper;
using WebRoutes.Dtos.RequestDtos;
using WebRoutes.Dtos.ResponseDtos;
using WebRoutes.Dtos.ResponseDtos.User;
using WebRoutes.Models;

namespace WebRoutes.Services.Users.Implementation;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserDataService _userDataService;
    private readonly IImageStorageService _imageStorageService;

    public UserService(IMapper mapper, IUserDataService userDataService, IImageStorageService imageStorageService)
    {
        _mapper = mapper;
        _userDataService = userDataService;
        _imageStorageService = imageStorageService;
    }

    public async Task<IEnumerable<UserInfoResponseDto>> GetAllUsersAsync()
    {
        var users = await _userDataService.GetAllUsersAsync();
        
        return _mapper.Map<IEnumerable<UserInfoResponseDto>>(users);
    }
    
    public async Task<UserProfileResponseDto> GetUserByIdAsync(int id)
    {
        var user = await _userDataService.GetUserByIdAsync(id);
        
        return _mapper.Map<UserProfileResponseDto>(user);
    }

    public async Task<HttpResponseMessage> CreateUserAsync(UserCreateRequestDto userCreateRequestDto)
    {
        var user = _mapper.Map<User>(userCreateRequestDto);
        if (await _userDataService.GetUserByEmailAsync(user.Email) != null)
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        if (userCreateRequestDto.Image != null)
        {
            user.ImageUrl = _imageStorageService.UploadImageAsync(userCreateRequestDto.Image);
        }
        await _userDataService.CreateUserAsync(user);
        
        return new HttpResponseMessage(HttpStatusCode.Created);
    }

    public async Task<HttpResponseMessage> UpdateUserAsync(int id, UserUpdateRequestDto userUpdateRequestDto)
    {
        var userToUpdate = await _userDataService.GetUserByIdAsync(id);
        if (userToUpdate == null)
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
        
        var user = _mapper.Map(userUpdateRequestDto, userToUpdate);
        await _userDataService.UpdateUserAsync(user);
        
        return new HttpResponseMessage(HttpStatusCode.OK);
    }

    public async Task DeleteUserAsync(int id)
    {
        if (await _userDataService.GetUserByIdAsync(id) != null)
        {
            await _userDataService.DeleteUserAsync(id);
        }
    }
}