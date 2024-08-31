using Application.Abstractions.Notifications;

namespace NotificationsService.Abstractions;

public interface INotificationClient
{
    Task ReceiveNotification(INotification notification);

}
