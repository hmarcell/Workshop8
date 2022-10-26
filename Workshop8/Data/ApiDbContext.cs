using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workshop8.Models;

namespace Workshop8.Data
{
    public class ApiDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<FolderEvent> FolderEvents { get; set; }
        
        public ApiDbContext(DbContextOptions<ApiDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "Admin" },
                new { Id = "2", Name = "User", NormalizedName = "USER" }
                );
            PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
            AppUser admin = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = "admin@admin.com",
                UserName = "admin",
                NormalizedUserName = "ADMIN"
            };
            admin.PasswordHash = ph.HashPassword(admin, "admin");
            builder.Entity<AppUser>().HasData(admin);
            base.OnModelCreating(builder);
        }
    }
}
