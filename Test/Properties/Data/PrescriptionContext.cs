
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Emit;
using Test.Properties.Models.Medication;
using Test.Properties.Models.Prescription;
using Test.Properties.Models.Medication; 
using Test.Controllers.Patientscontroller;
using Test.Properties.Models.Doctor;

namespace Test.Properties.Data
{
    public class PrescriptionContext : DbContext
    {
        public PrescriptionContext(DbContextOptions<PrescriptionContext> options)
        : base(options)
        {
        }

        public DbSet<Doctor> Doctors
        { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; } 
        public DbSet<Medication> Medications { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Doctor>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<Patient>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Prescription>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Medication>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.GetPatient())
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Doctor)
                .WithMany(d => d.Prescriptions)
                .HasForeignKey(p => p.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Medication)
                .WithMany()
                .HasForeignKey(p => p.MedicationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
