using Application.Abstractions.Notifications;

namespace Application.Notifications.Doctors.NewVisitNotifications;

public class NewVisitNotification : INotification
{
    private NewVisitNotification(int patientId, string patientFullName, int doctorId, int doctorUserId)
    {

        PatientId = patientId;
        PatientFullName = patientFullName;
        DoctorId = doctorId;
        DoctorUserId = doctorUserId;
    }
    public int PatientId { get; set; }
    public string PatientFullName { get; set; } = null!;
    public int DoctorId { get; set; }
    public int DoctorUserId { get; set; }

    public static NewVisitNotification Create(int patientId, string patientFullName, int doctorId, int doctorUserId)
    {
        return new NewVisitNotification(patientId, patientFullName, doctorId, doctorUserId);
    }
}
