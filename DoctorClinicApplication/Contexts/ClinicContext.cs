using DoctorClinicApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorClinicApplication.Contexts
{
    public class ClinicContext: DbContext
    {
        public ClinicContext(DbContextOptions options) : base(options)//constructor chaining dbContext class-parent class
        {
            
        }

        #region CollectionToTable
        public DbSet<Doctor> doctor { get; set; }
        public DbSet<Patient> patient { get; set; }
        public DbSet<Appointment> appointment { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seeding/Initializing data
            modelBuilder.Entity<Doctor>().HasData(
            new Doctor
            {
                Id = 101,
                Name = "Rishav",
                Experience = 10,
                Speciality = "Neurology",
                Phone = "1234567898",
                Email = "rish.kum@xyz.com",
                Pic = "/images/doctor1.jpg"
            },
                new Doctor
                {
                    Id = 102,
                    Name = "Anjali",
                    Experience = 15,
                    Speciality = "Surgery",
                    Phone = "1555567877",
                    Email = "anj.jha@xyz.com",
                    Pic = "/images/doctor2.jpg"
                }
                  );
            modelBuilder.Entity<Patient>().HasData(
          new Patient
          {
              Id = 1,
              Name = "Shivam",
              Age = 26,
              Phone = "9199292870",
              Email = "xys.kum@xyz.com"
          },
          new Patient
          {
              Id = 2,
              Name = "Nishant",
              Age = 28,
              Phone = "9078101884",
              Email = "abc.hjk@xyz.com"
          }
              );
        }
    }
}
