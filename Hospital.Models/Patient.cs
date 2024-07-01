using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Email { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }

        public string Guardian { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Resion { get; set; }
        [Required]
        public string Depatment { get; set; }
       

    }
}
