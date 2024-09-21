using MediatR;

namespace PeachDoctor.Api.Features.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctor : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ClinicName { get; set; }
        public string Specialization { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
