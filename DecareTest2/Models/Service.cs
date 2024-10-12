using DecareCenter.Models.CommonProp;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecareCenter.Models
{
    public class Service :SharedProp
    {
        public int ServiceId { get; set; }
        [Required(ErrorMessage ="Enter service name")]
        public string ServiceName { get; set; }
        [Required(ErrorMessage = "Enter service description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DataType(DataType.MultilineText)]
        public string Why { get; set; }
        [Required(ErrorMessage = "Enter service session duration")]
        public string SessionDuration { get; set; }
        public string? Image { get; set; }
        [NotMapped] // This will prevent EF from mapping this property to the database
        public IFormFile ImageFile { get; set; } // For the uploaded file

        [ForeignKey("Center")]
        public int CenterId { get; set; }
        public Center? Center { get; set; }
    }
}
