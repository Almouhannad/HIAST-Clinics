using Domain.Entities.People.Doctors;

namespace Application.Employees.Queries.GetAvailable;

public class GetAvailableDoctorsResponse
{
    public class GetAvailableDoctorsResponseItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
    public ICollection<GetAvailableDoctorsResponseItem> AvailableDoctors { get; set; } = null!;

    public static GetAvailableDoctorsResponse GetResponse(ICollection<Doctor> doctors)
    {
        List<GetAvailableDoctorsResponseItem> response = new();
        foreach (var doctor in doctors)
        {
            var responseItem = new GetAvailableDoctorsResponseItem
            {
                Id = doctor.Id,
                Name = doctor.PersonalInfo.FullName
            };
            response.Add(responseItem);
        }
        return new GetAvailableDoctorsResponse
        {
            AvailableDoctors = response
        };
    }
}
