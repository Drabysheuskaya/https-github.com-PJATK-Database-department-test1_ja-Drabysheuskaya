
using System;
using System.ComponentModel.DataAnnotations;
namespace Test.Properties.Models.Patient

{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
