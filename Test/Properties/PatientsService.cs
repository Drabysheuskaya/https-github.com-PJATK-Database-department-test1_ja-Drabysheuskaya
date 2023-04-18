
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Models; 
using Test.Data;
using Microsoft.EntityFrameworkCore; 
using Test.Controllers.Patientscontroller;

namespace Test.Properties.Services.PatientService
{
    public class PatientsService : IPatientsService
    {
        private readonly YourDbContext _context; 

        public PatientsService(YourDbContext context) { 
            _context = context;
        }

        public async Task<List<Patient>> GetPatientsAsync(string lastName)
        {
           
            var patients = await _context.Patients
                .Where(p => string.IsNullOrEmpty(lastName) || p.LastName.ToLower() == lastName.ToLower())
                .ToListAsync();

            return patients;
        }
    }

    public interface IPatientsService
    {
        Task<List<Patient>> GetPatientsAsync(string lastName);
    }
}