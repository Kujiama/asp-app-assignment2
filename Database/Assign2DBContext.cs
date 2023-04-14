using Microsoft.EntityFrameworkCore;
using Assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Runtime.ExceptionServices;

namespace Assignment2.Database
{
    public class Assign2DBContext : IdentityDbContext<ApplicationUser>
    {
        public Assign2DBContext(DbContextOptions options) : base(options)
        {
		
        }

        public DbSet<Item> Items { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
            });

			builder.Entity<IdentityRole>(entity =>
			{
				entity.ToTable(name: "Role");
			});
			builder.Entity<IdentityUserRole<string>>(entity =>
			{
				entity.ToTable(name: "UserRoles");
			});
			builder.Entity<IdentityUserClaim<string>>(entity =>
			{
				entity.ToTable(name: "UserClaims");
			});
			builder.Entity<IdentityUserLogin<string>>(entity =>
			{
				entity.ToTable(name: "UserLogins");
			});
			builder.Entity<IdentityRoleClaim<string>>(entity =>
			{
				entity.ToTable(name: "RoleClaims");
			});
			builder.Entity<IdentityUserToken<string>>(entity =>
			{
				entity.ToTable(name: "UserTokens");
			});
		}
	}
}
