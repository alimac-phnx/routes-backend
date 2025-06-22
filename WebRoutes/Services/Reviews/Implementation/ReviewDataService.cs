using WebRoutes.Models;
using WebRoutes.Repositories;

namespace WebRoutes.Services.Reviews.Implementation;

public class ReviewDataService : IReviewDataService
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewDataService(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<Review?> GetReviewByIdAsync(int id)
    {
        return await _reviewRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Review>> GetReviewsByRouteAsync(int routeId, int pageNumber, int pageSize)
    {
        return await _reviewRepository.GetReviewsByRouteIdAsync(routeId, pageNumber, pageSize);
    }

    public async Task CreateReviewAsync(Review review)
    {
        await _reviewRepository.AddAsync(review);
        await _reviewRepository.SaveChangesAsync();
    }

    public async Task DeleteReviewAsync(Review review)
    {
        _reviewRepository.Delete(review);
        await _reviewRepository.SaveChangesAsync();
    }
}