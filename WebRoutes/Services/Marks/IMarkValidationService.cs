using WebRoutes.Models;

namespace WebRoutes.Services.Marks;

public interface IMarkValidationService
{
    Task<bool> IsMarkValid(Mark mark);
}