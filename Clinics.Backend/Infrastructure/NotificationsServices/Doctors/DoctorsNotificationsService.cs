using Application.Abstractions.Notifications.Doctors;
using Application.Abstractions.Notifications.Doctors.NewVisitNotifications;
using Infrastructure.Abstractions;
using Infrastructure.NotificationsHubs;
using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.NotificationsServices.Doctors;

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
