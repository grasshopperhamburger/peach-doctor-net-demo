using FluentValidation;
using PeachDoctor.Api.Features.Doctors.Queries.GetDoctorById;

namespace PeachDoctor.Api.Features.Doctors.Queries.GetDoctors
{
    public class GetDoctorsValidator : AbstractValidator<GetDoctors>
    {
        public GetDoctorsValidator()
        {
            When(q => q.Latitude.HasValue, () =>
            {
                RuleFor(q => q.Latitude.Value).InclusiveBetween(-90.0, 90.0);
            });

            When(q => q.Longitude.HasValue, () =>
            {
                RuleFor(q => q.Longitude.Value).InclusiveBetween(-180.0, 180.0);
            });

            RuleFor(q => q)
                .Must(q => q.Latitude.HasValue == q.Longitude.HasValue)
                .WithMessage("Both Latitude and Longitude must be provided together.");
        }
    }
}
