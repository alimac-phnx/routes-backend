using AutoMapper;
using WebRoutes.Dtos.RequestDtos.User;
using WebRoutes.Models;

namespace WebRoutes.Services.Users.Implementation;

public class UserCreatingService : IUserCreatingService
{
    private readonly IMapper _mapper;
    private readonly IImageStorageService _imageStorageService;

    public UserCreatingService(IMapper mapper, IImageStorageService imageStorageService)
    {
        _mapper = mapper;
        _imageStorageService = imageStorageService;
    }
    
    public User Initialize(RegisterRequestDto registerRequestDto)
    {
        var user = _mapper.Map<User>(registerRequestDto);
        
        SetHashPasswordToUser(user, registerRequestDto.Password);
        
        if (registerRequestDto.Image != null)
        {
            SetImageToUser(user, registerRequestDto.Image);
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
}