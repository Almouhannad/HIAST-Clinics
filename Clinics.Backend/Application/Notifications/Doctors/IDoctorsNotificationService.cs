using Application.Notifications.Doctors.NewVisitNotifications;

namespace Application.Notifications.Doctors;

public interface IDoctorsNotificationService
{
    public Task SendNewVisitNotification(NewVisitNotification notification);
}
