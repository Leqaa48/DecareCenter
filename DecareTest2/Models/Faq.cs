using DecareCenter.Models.CommonProp;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecareCenter.Models
{
    public class Faq : SharedProp
    {
        public int FaqId { get; set; }
        [Required(ErrorMessage = "Enter Question")]
        [DataType(DataType.MultilineText)]
        public string Question { get; set; }
        [Required(ErrorMessage = "Enter Answer")]
        [DataType(DataType.MultilineText)]
        public string Answer { get; set; }
        
        [ForeignKey("Center")]
        public int CenterId { get; set; }
        public Center? Center { get; set; }

    }
}
