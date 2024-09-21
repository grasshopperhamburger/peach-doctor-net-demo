using MediatR;
using Microsoft.EntityFrameworkCore;
using PeachDoctor.Api.Features.Doctors.Models;
using PeachDoctor.Shared.Data;

namespace PeachDoctor.Api.Features.Doctors.Queries.GetDoctorById
{
    public class GetDoctorByIdHandler : IRequestHandler<GetDoctorById, DoctorDto>
    {
        private readonly PeachDoctorContext _context;

        public GetDoctorByIdHandler(PeachDoctorContext context)
        {
            _context = context;
        }

        public async Task<DoctorDto> Handle(GetDoctorById request, CancellationToken cancellationToken)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);
            if (doctor == null)
                return null;

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
