using Infrastructure.Abstractions;
using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.NotificationsHubs;

public class ReceptionistsNotificationsHub : Hub<INotificationClient>
{
}
