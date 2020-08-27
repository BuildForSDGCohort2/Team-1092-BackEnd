using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OlivetVehicleTracking.Entities;
using System;

namespace OlivetVehicleTracking.Models
{
    public class IdentityContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {       

        public IdentityContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // For Guid Primary Key
            builder.Entity<ApplicationUser>().Property(p => p.Id).ValueGeneratedOnAdd();

            // For int Primary Key
            //builder.Entity<ApplicationUser>().Property(p => p.Id).UseSqlServerIdentityColumn();
        }
    }
}
