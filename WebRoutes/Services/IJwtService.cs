using WebRoutes.Models;

namespace WebRoutes.Services;

public interface IJwtService
{
    string GenerateToken(User user);
}