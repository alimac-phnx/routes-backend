namespace WebRoutes.Services;

public interface IImageStorageService
{
    string UploadImageAsync(IFormFile image);
}