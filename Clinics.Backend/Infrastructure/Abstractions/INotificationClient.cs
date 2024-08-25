using Application.Abstractions.Notifications;

namespace Infrastructure.Abstractions;

public interface INotificationClient
{
    Task ReceiveNotification(INotification notification);

}
