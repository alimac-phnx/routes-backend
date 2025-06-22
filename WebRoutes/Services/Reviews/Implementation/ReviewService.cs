using System.Net;
using AutoMapper;
using WebRoutes.Dtos.RequestDtos.Reviews;
using WebRoutes.Dtos.ResponseDtos.Reviews;
using WebRoutes.Models;

namespace WebRoutes.Services.Reviews.Implementation;

public class ReviewService : IReviewService
{
    private readonly IReviewDataService _reviewDataService;
    private readonly IReviewValidationService _reviewValidationService;
    private readonly IMapper _mapper;

    public ReviewService(
        IReviewDataService reviewDataService,
        IReviewValidationService reviewValidationService,
        IMapper mapper)
    {
        _reviewDataService = reviewDataService;
        _reviewValidationService = reviewValidationService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReviewResponseDto>> GetReviewsByRouteAsync(int routeId)
    {
        var reviews = await _reviewDataService.GetReviewsByRouteAsync(routeId);
        
        return _mapper.Map<IEnumerable<ReviewResponseDto>>(reviews);
    }
    
    public async Task<HttpResponseMessage> CreateReviewAsync(ReviewCreateRequestDto reviewCreateRequest)
    {
        var review = _mapper.Map<Review>(reviewCreateRequest);
        if (!await _reviewValidationService.IsReviewValid(review))
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
        
        await _reviewDataService.CreateReviewAsync(review);
        
        return new HttpResponseMessage(HttpStatusCode.Created);
    }
    
    public async Task DeleteReviewAsync(int id)
    {
        var review = await _reviewDataService.GetReviewByIdAsync(id);
        
        if (review != null)
        {
            await _reviewDataService.DeleteReviewAsync(review);
        }
    }
}