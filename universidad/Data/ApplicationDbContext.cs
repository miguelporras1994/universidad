using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using universidad.Models;

namespace universidad.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<universidad.Models.Tercero> Tercero { get; set; }
        public DbSet<universidad.Models.Categoria> Categoria { get; set; }
        public DbSet <universidad.Models.ApplicationUser> ApplicationUser { get; set; }
        public DbSet<universidad.Models.Usuarios> Usuarios { get; set; }
        public DbSet<universidad.Models.Curso> Curso { get; set; }
    }
}
