using FluentValidation;

namespace PeachDoctor.Api.Features.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentValidator : AbstractValidator<CreateAppointment>
    {
        public CreateAppointmentValidator()
        {
            RuleFor(x => x.DoctorId).NotEmpty();
            RuleFor(x => x.PatientId).NotEmpty();
            RuleFor(x => x.AppointmentDateUtc).NotEmpty();
        }
    }
}
