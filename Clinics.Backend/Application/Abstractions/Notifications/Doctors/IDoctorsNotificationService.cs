using Application.Abstractions.Notifications.Doctors.NewVisitNotifications;

namespace Application.Abstractions.Notifications.Doctors;

public interface IDoctorsNotificationService
{
    public Task SendNewVisitNotification(NewVisitNotification notification);
}
