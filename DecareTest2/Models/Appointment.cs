using DecareCenter.Models.CommonProp;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecareCenter.Models
{
    public class Appointment :SharedProp
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="You need to enter your first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "You need to enter your last name")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "You need to enter your phone number")]

        public string PhoneNumber { get; set; }
        public string Service { get; set; }
        public string Doctor { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
        [Required(ErrorMessage = "You need to pick date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "You need to pick time")]
        [DataType(DataType.Time)]
        public TimeSpan Time { get; set; }
        [ForeignKey("Center")]
        public int CenterId { get; set; }
        public Center? Center { get; set; }

    }
}
