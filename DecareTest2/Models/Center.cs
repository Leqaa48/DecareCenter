using DecareCenter.Models.CommonProp;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecareCenter.Models
{
    public class Center :SharedProp
    {
        public int CenterId { get; set; }
        [Required]
        public string CenterName { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string BriefDescription { get; set; }
        public String WorkDaysStart { get; set; }
        public String WorkDaysEnd { get; set; }
        public String WorkHours { get; set; }

        [Required(ErrorMessage = "Enter Address")]
        public string CenterAddress { get; set; }
        [Required(ErrorMessage = "Enter Phone Number")]
        public string CenterPhoneNumber { get; set; }
        public string CenterSecondPhoneNumber { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress]
        public string CenterEmail { get; set; }
        public string? Image { get; set; }
        [NotMapped] // This will prevent EF from mapping this property to the database
        public IFormFile ImageFile { get; set; } // For the uploaded file
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string LogoUrl { get; set; }
        public string Place {  get; set; }
        public int YearsOfExperience {  get; set; }
        
    }
}
