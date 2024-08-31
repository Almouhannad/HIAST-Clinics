using Domain.Entities.People.Doctors;

namespace Application.Doctors.Queries.GetPhonesByUserId;

public class GetDoctorPhonesByUserIdResponse
{
    public class GetDoctorPhonesByUserIdResponseItem
    {
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
    public ICollection<GetDoctorPhonesByUserIdResponseItem> Phones { get; set; } = null!;

    public static GetDoctorPhonesByUserIdResponse GetResponse(Doctor doctor)
    {
        List<GetDoctorPhonesByUserIdResponseItem> response = new();
        foreach (var doctorPhone in doctor.Phones)
        {
            response.Add(new GetDoctorPhonesByUserIdResponseItem
            {
                Name = doctorPhone.Name!,
                Phone = doctorPhone.Phone,
            });
        }
        return new GetDoctorPhonesByUserIdResponse
        {
            Phones = response
        };
    }
}
