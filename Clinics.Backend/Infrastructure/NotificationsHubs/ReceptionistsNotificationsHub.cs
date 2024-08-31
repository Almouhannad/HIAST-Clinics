using Microsoft.AspNetCore.SignalR;
using NotificationsService.Abstractions;

namespace NotificationsService.NotificationsHubs;

public class ReceptionistsNotificationsHub : Hub<INotificationClient>
{
}
