using Microsoft.EntityFrameworkCore;


namespace OlivetVehicleTracking.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //public DbSet<Supplier> Supplier { get; set; }
        

    }
}
