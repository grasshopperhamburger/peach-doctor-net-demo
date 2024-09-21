using FluentValidation;

namespace PeachDoctor.Api.Features.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorValidator : AbstractValidator<UpdateDoctor>
    {
        public UpdateDoctorValidator()
        {
            RuleFor(x => x.Id)
                 .NotEmpty().WithMessage("Doctor ID must be greater than zero.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Doctor name is required.")
                .MaximumLength(100).WithMessage("Doctor name cannot exceed 100 characters.");

            RuleFor(x => x.ClinicName)
                .NotEmpty().WithMessage("Clinic name is required.")
                .MaximumLength(100).WithMessage("Clinic name cannot exceed 100 characters.");

            RuleFor(x => x.Specialization)
                .NotEmpty().WithMessage("Specialization is required.")
                .MaximumLength(100).WithMessage("Specialization cannot exceed 100 characters.");

            RuleFor(x => x.Latitude)
                .InclusiveBetween(-90.0, 90.0).WithMessage("Latitude must be between -90 and 90 degrees.");

            RuleFor(x => x.Longitude)
                .InclusiveBetween(-180.0, 180.0).WithMessage("Longitude must be between -180 and 180 degrees.");
        }
    }
}
