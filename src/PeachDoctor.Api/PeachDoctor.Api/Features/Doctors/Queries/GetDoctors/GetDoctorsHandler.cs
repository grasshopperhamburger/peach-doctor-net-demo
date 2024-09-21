using MediatR;
using Microsoft.EntityFrameworkCore;
using PeachDoctor.Api.Features.Doctors.Models;
using PeachDoctor.Api.Features.Doctors.Queries.GetDoctorById;
using PeachDoctor.Shared.Data;

namespace PeachDoctor.Api.Features.Doctors.Queries.GetDoctors
{
    public class GetDoctorsHandler : IRequestHandler<GetDoctors, IEnumerable<DoctorDto>>
    {
        private readonly PeachDoctorContext _context;

        public GetDoctorsHandler(PeachDoctorContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DoctorDto>> Handle(GetDoctors request, CancellationToken cancellationToken)
        {
            var query = _context.Doctors.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                query = query.Where(d => d.FullName.Contains(request.Name));
            }

            if (!string.IsNullOrWhiteSpace(request.ClinicName))
            {
                query = query.Where(d => d.ClinicName.Contains(request.ClinicName));
            }

            if (!string.IsNullOrWhiteSpace(request.Specialization))
            {
                query = query.Where(d => d.Specialization.Contains(request.Specialization));
            }

            if (request.Latitude.HasValue && request.Longitude.HasValue)
            {
                const double earthRadiusKm = 6371;
                double lat = request.Latitude.Value;
                double lon = request.Longitude.Value;

                query = query.Where(d =>
                    earthRadiusKm * 2 *
                    System.Math.Asin(System.Math.Sqrt(
                        System.Math.Pow(System.Math.Sin((System.Math.PI / 180 * (d.Latitude - lat)) / 2), 2) +
                        System.Math.Cos(System.Math.PI / 180 * lat) *
                        System.Math.Cos(System.Math.PI / 180 * d.Latitude) *
                        System.Math.Pow(System.Math.Sin((System.Math.PI / 180 * (d.Longitude - lon)) / 2), 2)
                    )) <= 10);
            }

            var doctors = await query.ToListAsync(cancellationToken);

            return doctors.Select(d => new DoctorDto
            {
                Id = d.Id.ToString(),
                FullName = d.FullName,
                ClinicName = d.ClinicName,
                Specialization = d.Specialization,
                Latitude = d.Latitude,
                Longitude = d.Longitude
            });
        }
    }
}
