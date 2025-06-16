namespace AlquilaFacilPlatform.Booking.Application.OutBoundService;

public interface INotificationReservationExternalService
{
    Task<int> CreateNotification(
        string title,
        string description,
        int userId
    );
}