using Microsoft.EntityFrameworkCore;
using PeachDoctor.Shared.Models;
using System.Collections.Generic;

namespace PeachDoctor.Shared.Data
{
    public class PeachDoctorContext : DbContext
    {
        public PeachDoctorContext(DbContextOptions<PeachDoctorContext> options) : base(options) { }

        //public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
    }
}
