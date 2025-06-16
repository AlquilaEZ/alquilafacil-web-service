namespace AlquilaFacilPlatform.Profiles.Application.Internal.OutboundServices;

public interface ISubscriptionExternalService
{
    Task<string> GetSubscriptionStatusByUserId(int userId);
}