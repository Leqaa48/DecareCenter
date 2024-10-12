using DecareCenter.Models.CommonProp;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecareCenter.Models
{
    public class GalleryImage : SharedProp
    {
        public int GalleryImageId { get; set; }
        public string? Image { get; set; }
        [NotMapped] // This will prevent EF from mapping this property to the database
        public IFormFile ImageFile { get; set; } // For the uploaded file
        [ForeignKey("Center")]
        public int CenterId { get; set; }
        public Center? Center { get; set; }
    }
}
