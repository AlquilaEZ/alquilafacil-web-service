using AlquilaFacilPlatform.Subscriptions.Interfaces.ACL;

namespace AlquilaFacilPlatform.Profiles.Application.Internal.OutboundServices;

public class SubscriptionExternalService(ISubscriptionContextFacade subscriptionContextFacade) : ISubscriptionExternalService
{
    public async Task<string> GetSubscriptionStatusByUserId(int userId)
    {
        return await subscriptionContextFacade.GetSubscriptionStatusByUserId(userId);
    }
}