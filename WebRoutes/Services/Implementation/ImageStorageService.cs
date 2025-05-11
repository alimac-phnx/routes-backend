using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using dotenv.net;

namespace WebRoutes.Services.implementation;

public class ImageStorageService : IImageStorageService
{
    public string UploadImageAsync(IFormFile image)
    {
        DotEnv.Load(options: new DotEnvOptions(probeForEnv: true));
        var cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
        cloudinary.Api.Secure = true;
        
        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(image.FileName, image.OpenReadStream()),
            UseFilename = true,
            UniqueFilename = false,
            Overwrite = true
        };
        var uploadResult = cloudinary.Upload(uploadParams);
        
        return uploadResult.SecureUri.AbsoluteUri;
    }
}