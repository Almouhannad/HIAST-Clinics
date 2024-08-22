using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.NotificationsService;

public class NotificationHub : Hub<INotificationClient>
{
    public override async Task OnConnectedAsync()
    {
        await Clients.Client(Context.ConnectionId).ReceiveNotification(
            $"Connected successfully { Context.User?.Identity?.Name}");

        await base.OnConnectedAsync();
    }
}


public interface INotificationClient
{
    Task ReceiveNotification(string message);
}