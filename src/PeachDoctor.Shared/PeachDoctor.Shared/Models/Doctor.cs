using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeachDoctor.Shared.Models
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string ClinicName { get; set; }
        public string Specialization { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
