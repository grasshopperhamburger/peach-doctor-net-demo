using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeachDoctor.Shared.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }    
        public Guid DoctorId { get; set; }     
        public DateTime AppointmentDateUtc { get; set; }
        public string Status { get; set; }     

        public User Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
