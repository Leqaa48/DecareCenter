using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecareCenter.Models
{
    public class Patient
    {

        public int PatientId { get; set; }
        [Required(ErrorMessage = "Enter First Name")]
        
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter Age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Enter Phone Number")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]
        public Gender? PatientGender { get; set; }

        public decimal Balance { get; set; }

        public decimal TotalPrice { get; set; }
        [DataType(DataType.MultilineText)]
        public string Status { get; set; }

        public enum Gender
        {
            Male, Female
        }
        [ForeignKey("Center")]
        public int CenterId { get; set; }
        public Center? Center { get; set; }
    }
}
