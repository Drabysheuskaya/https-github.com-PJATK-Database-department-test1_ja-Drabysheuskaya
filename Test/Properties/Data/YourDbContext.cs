namespace Test.Properties.Data
{
    using Microsoft.EntityFrameworkCore;
    using Test.Properties.Models.Prescription;
    using Test.Properties.Models.Patient;
    using Test.Properties.Models.Medication;
    using global::Test.Properties.Models.Medication;
    using global::Test.Properties.Models.Prescription;
    using global::Test.Controllers.Patientscontroller;

    namespace Test.Data
    {
        public class YourDbContext : DbContext
        {
            public YourDbContext(DbContextOptions<YourDbContext> options) : base(options)
            {
            }
            public DbSet<Prescription> Prescriptions { get; set; }

            public DbSet<Patient> Patients { get; set; }

         
            public DbSet<Medication> Medications { get; set; }

            
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
              
            }
        }
    }
}