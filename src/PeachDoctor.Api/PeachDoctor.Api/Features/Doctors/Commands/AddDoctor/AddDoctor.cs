using MediatR;
using PeachDoctor.Api.Features.Doctors.Models;

namespace PeachDoctor.Api.Features.Doctors.Commands.AddDoctor
{
    public class AddDoctor : IRequest<DoctorDto>
    {
        public string FullName { get; set; }
        public string ClinicName { get; set; }
        public string Specialization { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
