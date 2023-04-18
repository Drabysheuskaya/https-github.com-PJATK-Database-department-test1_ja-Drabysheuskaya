using Test.Properties.Models.Prescription;
using Test.Services.PrescriptionService;
using Test.Controllerts.Perscriptionscontroller;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test.Properties.Models.Doctor
{
    public class Doctor
    {
        private ICollection<Prescription>? prescriptions;

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(255)]
        public string Specialization { get; set; }

   
        public ICollection<Prescription> GetPrescriptions()
        {
            return prescriptions;
        }

        public void SetPrescriptions(ICollection<Prescription> value)
        {
            prescriptions = value;
        }
    }
}