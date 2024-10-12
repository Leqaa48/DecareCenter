using System.ComponentModel.DataAnnotations;

namespace DecareCenter.Models.ViewModels
{
    public class CreateRoleViewModel
    {
            [Required]
            public string RoleName { get; set; }
        
    }
}
