using DecareCenter.Models.CommonProp;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecareCenter.Models
{
    public class Doctor :SharedProp
    {
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "Enter Doctor name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Doctor specialist")]
        public string Specialist { get; set; }
        [Required(ErrorMessage = "Enter Doctor Info")]
        [DataType(DataType.MultilineText)]
        public string Info { get; set; }
        [Required(ErrorMessage = "Enter Doctor email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Doctor phone number")]
        public string Phone { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string? DoctorImage { get; set; }
        [NotMapped] // This will prevent EF from mapping this property to the database
        public IFormFile ImageFile { get; set; } // For the uploaded file

        [ForeignKey("Center")]
        public int CenterId { get; set; }
        public Center? Center { get; set; }
    }
}
