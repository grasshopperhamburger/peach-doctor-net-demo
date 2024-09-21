
namespace PeachDoctor.Api.Features.Doctors.Models
{
    public class DoctorDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string ClinicName { get; set; }
        public string Address { get; set; }
        public string Specialization { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}

