using AutoMapper;
using Microsoft.Extensions.Options;
using WebRoutes.Dtos.RequestDtos.Auth;
using WebRoutes.Enums;
using WebRoutes.Models;

namespace WebRoutes.Services.Users.Implementation;

public class UserCreatingService : IUserCreatingService
{
    private readonly IMapper _mapper;
    private readonly IImageStorageService _imageStorageService;
    private readonly DefaultPhotoSettings _defaultPhotoSettings;

    public UserCreatingService(
        IMapper mapper, 
        IImageStorageService imageStorageService, 
        IOptions<DefaultPhotoSettings> defaultPhotoOptions)
    {
        _mapper = mapper;
        _imageStorageService = imageStorageService;
        _defaultPhotoSettings = defaultPhotoOptions.Value;
    }
    
    public User Initialize(RegisterRequestDto registerRequest)
    {
        var user = _mapper.Map<User>(registerRequest);
        
        SetHashPasswordToUser(user, registerRequest.Password);
        
        if (registerRequest.Image != null)
        {
            SetImageToUser(user, registerRequest.Image);
        }
        else
        {
            SetDefaultImageToUser(user, registerRequest);
        }

        return user;
    }

    private static void SetHashPasswordToUser(User user, string password)
    {
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        user.PasswordHash = hashedPassword;
    }

    private void SetImageToUser(User user, IFormFile image)
    {
        user.ImageUrl = _imageStorageService.UploadImageAsync(image);
    }

    private void SetDefaultImageToUser(User user, RegisterRequestDto registerRequest)
    {
        user.ImageUrl = registerRequest.DefaultPhotoType switch
        {
            DefaultPhotoType.Male => _defaultPhotoSettings.Male,
            DefaultPhotoType.Female => _defaultPhotoSettings.Female,
            _ => _defaultPhotoSettings.Unknown
        };
    }
}