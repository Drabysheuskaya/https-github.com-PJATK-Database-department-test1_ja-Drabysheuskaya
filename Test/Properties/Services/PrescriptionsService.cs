using System;
using System.Threading.Tasks;
using Test.Properties.Models.Prescription; 
using Test.Data;
using Microsoft.EntityFrameworkCore;
using Test.Properties.Models.Patient;
using Test.Properties.Services.PatientService;
using Test.Properties.Models.Medication;


namespace Test.Properties.Services.PrescriptiontsService
{
    public class PrescriptionsService : IPrescriptionsService
    {
        private readonly YourDbContext _context; 

        public PrescriptionsService(YourDbContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> AddPrescriptionAsync(Prescription prescription)
        {
       
            var doctor = await _context.Doctors.FindAsync(prescription.DoctorId);
            if (doctor == null)
                throw new Exception("Doctor not found");

            var patient = await _context.Patients.FindAsync(prescription.PatientId);
            if (patient == null)
                throw new Exception("Patient not found");

            var medication = await _context.Medications.FirstOrDefaultAsync(m => m.Name.ToLower() == prescription.Medicine.ToLower());
            if (medication == null)
            {
              
                medication = new Medication { Name = prescription.Medicine };
                _context.Medications.Add(medication);
                await _context.SaveChangesAsync();
            }

    
            prescription.MedicineId = medication.Id;
            prescription.CreatedAt = DateTime.Now;
            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();

            return prescription.Id;
        }
    }

    public interface IPrescriptionsService
    {
        Task<int> AddPrescriptionAsync(Prescription prescription);
    }
}