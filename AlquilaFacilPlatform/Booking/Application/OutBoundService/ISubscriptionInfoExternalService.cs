using AlquilaFacilPlatform.Subscriptions.Domain.Model.Aggregates;

namespace AlquilaFacilPlatform.Booking.Application.OutBoundService;

public interface ISubscriptionInfoExternalService
{
    Task<IEnumerable<Subscription>> GetSubscriptionByUserIdsList(List<int> usersId);
}