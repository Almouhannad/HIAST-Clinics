using Domain.Entities.People.Doctors;

namespace Application.Doctors.Queries.GetAllDoctors;

public class GetAllDoctorsResponse
{
    public class GetAllDoctorsResponseItem
    {
        public string FullName { get; set; } = null!;
        public string Status { get; set; } = null!;
        public ICollection<PhoneItem> Phones { get; set; } = null!;
    }

    public class PhoneItem
    {
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }

    public ICollection<GetAllDoctorsResponseItem> Doctors { get; set; } = null!;

    public static GetAllDoctorsResponse GetResponse(ICollection<Doctor> doctors)
    {
        List<GetAllDoctorsResponseItem> response = new();

        foreach (var doctor in doctors)
        {
            List<PhoneItem> phones = new();
            foreach (var phone in doctor.Phones)
            {
                phones.Add(new PhoneItem
                {
                    Name = phone.Name!,
                    Phone = phone.Phone,
                });
            }

            response.Add(new GetAllDoctorsResponseItem
            {
                FullName = doctor.PersonalInfo.FullName,
                Status = doctor.Status.Name,
                Phones = phones
            });
        }
        return new GetAllDoctorsResponse
        {
            Doctors = response
        };
    }
}
