using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrescriptionManagement.Data;
using Test.Properties.Models.Prescription;
using Test.Properties.Models.Medication;

namespace Test.Controllers.PrescriptionsController

{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionsController : ControllerBase
    {
        public PrescriptionsController(PrescriptionContext context)
        {
            Context1 = context;
        }

        public PrescriptionContext Context1 { get; }

        [HttpPost]
        public async Task<ActionResult<int>> AddPrescription(Prescription prescription)
        {
            
            if (prescription.Amount <= 0)
            {
                return BadRequest("Amount must be greater than 0.");
            }

           
            if (!await Context.Doctors.AnyAsync(d => d.Id == prescription.DoctorId) ||
                !await Context.Patients.AnyAsync(p => p.Id == prescription.PatientId))
            {
                return NotFound("Doctor or patient with given id does not exist.");
            }

           
            Medication medication = await Context.Medications.FirstOrDefaultAsync(m => m.Name == prescription.Medicine);
            if (medication == null)
            {
                medication = new Medication { Name = prescription.Medicine };
                Context.Medications.Add(medication);
            }

           
            prescription.CreatedAt = DateTime.Now;
            prescription.SetMedication(medication);
            Context.Prescriptions.Add(prescription);
            await Context.SaveChangesAsync();

            return prescription.Id;
        }
    }
}

