using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectB.Models;

namespace ProjectB.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<DanceEvent> DanceEvents { get; set; }
        //public DbSet<Photographer> Photographer { get; set; }
        //public DbSet<PhotographerEvent> PhotographerEvent { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<PhotographerEvent>().HasKey(x => new { x.EventId, x.PhotographerId });
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
