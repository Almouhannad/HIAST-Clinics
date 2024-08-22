using Infrastructure.NotificationsService;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Infrastructure.BackgroundServices.Notifications;

public class ServerTimeNotifier : BackgroundService
{
    private static readonly TimeSpan Period = TimeSpan.FromSeconds(3);

    #region CTOR DI
    private readonly ILogger<ServerTimeNotifier> _logger;
    private readonly IHubContext<NotificationHub, INotificationClient> _context;

    public ServerTimeNotifier(ILogger<ServerTimeNotifier> logger, IHubContext<NotificationHub, INotificationClient> context)
    {
        _logger = logger;
        _context = context;
    }
    #endregion


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(Period);

        while (!stoppingToken.IsCancellationRequested &&
            await timer.WaitForNextTickAsync(stoppingToken))
        {
            var dateTime = DateTime.Now;

            _logger.LogInformation("Executing {Service} {Time}", nameof(ServerTimeNotifier), dateTime);

            await _context.Clients.All.ReceiveNotification($"Server time = {dateTime}");
        }
    }
}
