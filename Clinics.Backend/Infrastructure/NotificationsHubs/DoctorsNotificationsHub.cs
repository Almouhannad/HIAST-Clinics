using Microsoft.AspNetCore.SignalR;
using NotificationsService.Abstractions;

namespace NotificationsService.NotificationsHubs;

public class DoctorsNotificationsHub : Hub<INotificationClient>
{
}
