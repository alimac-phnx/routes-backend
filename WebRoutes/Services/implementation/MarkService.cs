using WebRoutes.Models;
using WebRoutes.Repositories;

namespace WebRoutes.Services.implementation
{
    public class MarkService : IMarkService
    {
        private readonly IMarkRepository _markRepository;

        public MarkService(IMarkRepository markRepository)
        {
            _markRepository = markRepository;
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

        public async Task DeleteMarkAsync(int userId, int routeId)
        {
            var marks = await _markRepository.GetMarksByUserIdAsync(userId);
            var markToDelete = marks.FirstOrDefault(m => m.TripId == routeId);
            if (markToDelete != null)
            {
                _markRepository.Delete(markToDelete);
                await _markRepository.SaveChangesAsync();
            }
        }
    }
}