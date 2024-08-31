using Application.Notifications.Doctors;
using Application.Notifications.Doctors.NewVisitNotifications;
using Microsoft.AspNetCore.SignalR;
using NotificationsService.Abstractions;
using NotificationsService.NotificationsHubs;

namespace NotificationsService.NotificationsServices.Doctors;

public class DoctorsNotificationsService : IDoctorsNotificationService
{
    #region CTOR DI
    private readonly IHubContext<DoctorsNotificationsHub, INotificationClient> _context;

    public DoctorsNotificationsService(IHubContext<DoctorsNotificationsHub, INotificationClient> context)
    {
        _context = context;
    }
    #endregion

    public async Task SendNewVisitNotification(NewVisitNotification notification)
    {
        await _context.Clients.All.ReceiveNotification(notification);
    }

}
