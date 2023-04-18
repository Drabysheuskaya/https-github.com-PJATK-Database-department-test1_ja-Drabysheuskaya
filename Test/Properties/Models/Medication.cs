
   using System.ComponentModel.DataAnnotations;

namespace Test.Properties.Models.Medication

{
        public class Medication
        {
            public int Id { get; set; }

            [Required]
            [MaxLength(50)]
            public string Name { get; set; }
        }
    }
