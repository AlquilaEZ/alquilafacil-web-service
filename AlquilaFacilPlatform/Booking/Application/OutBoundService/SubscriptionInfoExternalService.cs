using AlquilaFacilPlatform.Subscriptions.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Subscriptions.Interfaces.ACL;

namespace AlquilaFacilPlatform.Booking.Application.OutBoundService;

public class SubscriptionInfoExternalService(ISubscriptionContextFacade subscriptionContextFacade) : ISubscriptionInfoExternalService
{
    public async Task<IEnumerable<Subscription>> GetSubscriptionByUserIdsList(List<int> userIdsList)
    {
        return await subscriptionContextFacade.GetSubscriptionByUserIdsList(userIdsList);
    }
}