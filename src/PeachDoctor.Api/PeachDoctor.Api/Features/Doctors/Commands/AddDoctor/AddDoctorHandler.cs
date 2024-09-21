using MediatR;
using PeachDoctor.Api.Features.Doctors.Models;
using PeachDoctor.Shared.Data;
using PeachDoctor.Shared.Models;

namespace PeachDoctor.Api.Features.Doctors.Commands.AddDoctor
{
    public class AddDoctorHandler : IRequestHandler<AddDoctor, DoctorDto>
    {
        private readonly PeachDoctorContext _context;

        public AddDoctorHandler(PeachDoctorContext context)
        {
            _context = context;
        }

        public async Task<DoctorDto> Handle(AddDoctor request, CancellationToken cancellationToken)
        {
            var doctor = new Doctor
            {
                FullName = request.FullName,
                ClinicName = request.ClinicName,
                Specialization = request.Specialization,
                Latitude = request.Latitude,
                Longitude = request.Longitude
            };

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync(cancellationToken);

            return new DoctorDto
            {
                Id = doctor.Id.ToString(),
                FullName = doctor.FullName,
                ClinicName = doctor.ClinicName,
                Specialization = doctor.Specialization,
                Latitude = doctor.Latitude,
                Longitude = doctor.Longitude
            };
        }
    }
}
