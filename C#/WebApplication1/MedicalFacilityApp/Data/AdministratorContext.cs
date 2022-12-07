using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class AdministratorContext : DbContext
    {
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Schedule> schedule { get; set; }
        
        

        public AdministratorContext(DbContextOptions<AdministratorContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }





    }
}
