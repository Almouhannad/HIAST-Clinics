using Infrastructure.Abstractions;
using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.NotificationsHubs;

public class DoctorsNotificationsHub : Hub<INotificationClient>
{
}
