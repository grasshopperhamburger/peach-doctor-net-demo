using MediatR;
using PeachDoctor.Api.Features.Doctors.Models;

namespace PeachDoctor.Api.Features.Doctors.Queries.GetDoctors
{
    public class GetDoctors : IRequest<IEnumerable<DoctorDto>>
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Name { get; set; }
        public string ClinicName { get; set; }
        public string Specialization { get; set; }
    }
}
