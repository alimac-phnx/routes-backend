using WebRoutes.Models;
using WebRoutes.Repositories;

namespace WebRoutes.Services.Marks.Implementation;

public class MarkDataService : IMarkDataService
{
    private readonly IMarkRepository _markRepository;

    public MarkDataService(IMarkRepository markRepository)
    {
        _markRepository = markRepository;
    }

    public async Task<Mark?> GetMarkByIdAsync(int id)
    {
        return await _markRepository.GetByIdAsync(id);
    }
        
    public async Task<IEnumerable<Mark>> GetMarksByUserAsync(int userId)
    {
        return await _markRepository.GetMarksByUserIdAsync(userId);
    }

    public async Task<IEnumerable<Mark>> GetMarksByRouteAsync(int routeId)
    {
        return await _markRepository.GetMarksByRouteIdAsync(routeId);
    }

    public async Task CreateMarkAsync(Mark mark)
    {
        await _markRepository.AddAsync(mark);
        await _markRepository.SaveChangesAsync();
    }

    public async Task DeleteMarkAsync(Mark mark)
    {
        _markRepository.Delete(mark);
        await _markRepository.SaveChangesAsync();
    }
}