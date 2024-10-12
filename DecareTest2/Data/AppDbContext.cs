using DecareCenter.Models;
using DecareCenter.Models.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DecareCenter.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Center> Centers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Doctor> Doctors { get; set; } 
        public DbSet<Faq> Faq { get; set; } 
        public  DbSet<Appointment> Appointments {  get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
    

}
