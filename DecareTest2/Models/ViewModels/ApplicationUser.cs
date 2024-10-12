using Microsoft.AspNetCore.Identity;

namespace DecareCenter.Models.ViewModels
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
