namespace PeachDoctor.Api.Features.Appointments.Commands.CreateAppointment
{
    public class CreateAppointment
    {
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime AppointmentDateUtc { get; set; }
    }
}
