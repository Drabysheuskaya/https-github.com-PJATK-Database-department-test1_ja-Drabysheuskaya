using System.ComponentModel.DataAnnotations;
namespace Test.Properties.Models.Prescription
{
    public class Prescription
        {
            public int Id { get; set; }

            [Required]
            public int DoctorId { get; set; }

            [Required]
            public int PatientId { get; set; }

            [Required]
            public decimal Amount { get; set; }

            [Required]
            public DateTime CreatedAt { get; set; }

            [Required]
            public int MedicineId { get; set; }

        private Patient patient;

        public Patient GetPatient()
        {
            return patient;
        }

        
        public void SetPatient(Patient value)
        {
            patient = value;
        }

        public Medication Medication { get; private set; }
        public object MedicationId { get; internal set; }
        public object Doctor { get; internal set; }

        public Medication GetMedication() => Medication;

        public void SetMedication(Medication value) => Medication = value;
        }
    }