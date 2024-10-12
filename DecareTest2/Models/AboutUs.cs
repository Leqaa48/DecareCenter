using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecareCenter.Models
{
    public class AboutUs
    {
        public int AboutUsId { get; set; }
        public string AboutUsTitle { get; set; }
        [Required(ErrorMessage = "Enter about us details")]
        [DataType(DataType.MultilineText)]
        public string AboutUsDetails { get; set; }
        [DataType(DataType.MultilineText)]
        public string AboutUsDetails2 { get; set; }
        public string? Image { get; set; }
        [NotMapped] // This will prevent EF from mapping this property to the database
        public IFormFile ImageFile { get; set; } // For the uploaded file
        [ForeignKey("Center")]
        public int CenterId { get; set; }
        public Center? Center { get; set; }


    }
}
