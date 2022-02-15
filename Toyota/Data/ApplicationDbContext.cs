using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Toyota.Data.Entities;

namespace Toyota.Data
{
    public class ApplicationDbContext : IdentityDbContext<MyIdentityUser>
    {
        public DbSet<Model> Models { get; set; }
        public DbSet<Modification> Modifications { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Callback> Callbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Callback>()
                .Property(b => b.CreateAt)
                .HasDefaultValueSql("getdate()");
        }
        public DbSet<ModificationColors> ModificationColors { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
