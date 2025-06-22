using System.Net;
using AutoMapper;
using WebRoutes.Dtos.ResponseDtos;
using WebRoutes.Dtos.ResponseDtos.User;

namespace WebRoutes.Services.Subscriptions.Implementation;

public class SubscriptionService : ISubscriptionService
{
    private readonly IMapper _mapper;
    private readonly ISubscriptionDataService _subscriptionDataService;
    private readonly ISubscriptionValidationService _subscriptionValidationService;

    public SubscriptionService(
        IMapper mapper,
        ISubscriptionDataService subscriptionDataService,
        ISubscriptionValidationService subscriptionValidationService)
    {
        _mapper = mapper;
        _subscriptionDataService = subscriptionDataService;
        _subscriptionValidationService = subscriptionValidationService;
    }
    
    public async Task<IEnumerable<SubscriptionResponseDto>> GetAllSubscriptionsAsync(int userId)
    {
        var subscriptions = await _subscriptionDataService.GetSubscriptionsAsync(userId);
        
        return subscriptions.Select(s => new SubscriptionResponseDto
        {
            SubscriberId = s.SubscriberId,
            FolloweeId = s.FolloweeId,
            SubscriberInfoResponse = _mapper.Map<UserInfoResponseDto>(s.Followee)
        });
    }

    public async Task<IEnumerable<SubscriptionResponseDto>> GetAllFollowersAsync(int userId)
    {
        var followers = await _subscriptionDataService.GetFollowersAsync(userId);
        
        return followers.Select(s => new SubscriptionResponseDto
        {
            SubscriberId = s.SubscriberId,
            FolloweeId = s.FolloweeId,
            SubscriberInfoResponse = _mapper.Map<UserInfoResponseDto>(s.Subscriber)
        });
    }

    public async Task<HttpResponseMessage> CreateSubscriptionAsync(int subscriberId, int followeeId)
    {
        var isValid = await _subscriptionValidationService.IsValidSubscription(subscriberId, followeeId);
            
        if (!isValid)
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        await _subscriptionDataService.CreateSubscriptionAsync(subscriberId, followeeId);
        
        return new HttpResponseMessage(HttpStatusCode.Created);
    }

    public async Task<HttpResponseMessage> DeleteSubscriptionAsync(int userId, int followedUserId)
    {
        var subscriptionToDelete = await _subscriptionValidationService.GetExistingSubscription(userId, followedUserId);
            
        if (subscriptionToDelete == null)
        {
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
        
        await _subscriptionDataService.DeleteSubscriptionAsync(subscriptionToDelete);
        
        return new HttpResponseMessage(HttpStatusCode.NoContent);
    }
}