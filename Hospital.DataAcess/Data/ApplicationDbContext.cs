using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DataAcess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Patient> Patients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder .Entity<Patient>().HasData (
                new Patient { Id = 100,
                              Name = "Patient",
                              Email = "patient@gmail.com",
                              Phone = 1234567890,
                              Age = 25,
                              Gender = "Male",
                              Guardian = "Guardian",
                              Address = "Address",
                              Resion = "Resion",
                              Depatment = "Depatments"
                },
              
                new Patient { Id = 101,
                              Name = "Patient2",
                              Email = "2patient@gmail.com",
                              Phone = 1234567890,
                              Age = 25,
                              Gender = "2Male",
                              Guardian = "2Guardian",
                              Address = "2Address",
                              Resion = "2Resion",
                              Depatment = "2Depatments"
                }
            );
        }
    }
}
