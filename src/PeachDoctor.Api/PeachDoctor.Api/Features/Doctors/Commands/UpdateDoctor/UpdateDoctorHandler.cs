using MediatR;
using Microsoft.EntityFrameworkCore;
using PeachDoctor.Shared.Data;

namespace PeachDoctor.Api.Features.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorHandler : IRequestHandler<UpdateDoctor, bool>
    {
        private readonly PeachDoctorContext _context;

        public UpdateDoctorHandler(PeachDoctorContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateDoctor request, CancellationToken cancellationToken)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);
            if (doctor == null)
                return false;

            doctor.FullName = request.Name;
            doctor.ClinicName = request.ClinicName;
            doctor.Specialization = request.Specialization;
            doctor.Latitude = request.Latitude;
            doctor.Longitude = request.Longitude;

            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
