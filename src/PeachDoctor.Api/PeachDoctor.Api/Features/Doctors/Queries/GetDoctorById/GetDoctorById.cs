using MediatR;
using PeachDoctor.Api.Features.Doctors.Models;

namespace PeachDoctor.Api.Features.Doctors.Queries.GetDoctorById
{
    public class GetDoctorById : IRequest<DoctorDto>
    {
        public Guid Id { get; set; }
    }
}
