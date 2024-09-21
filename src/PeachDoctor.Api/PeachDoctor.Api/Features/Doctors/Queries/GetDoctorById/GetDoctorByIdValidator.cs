using FluentValidation;

namespace PeachDoctor.Api.Features.Doctors.Queries.GetDoctorById
{
    public class GetDoctorByIdValidator : AbstractValidator<GetDoctorById>
    {
        public GetDoctorByIdValidator()
        {
            RuleFor(q => q.Id).Empty().WithMessage("Doctor ID must be greater than zero.");
        }
    }
}
