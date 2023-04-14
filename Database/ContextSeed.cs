using Assignment2.Models;
using Microsoft.AspNetCore.Identity;

namespace Assignment2.Database
{
	public class ContextSeed
	{
		public static async Task SeedRolesAsync(UserManager<ApplicationUser>userManager,RoleManager<IdentityRole> roleManager)
		{
			await roleManager.CreateAsync(new IdentityRole(Enum.Roles.SuperAdmin.ToString()));
			await roleManager.CreateAsync(new IdentityRole(Enum.Roles.Admin.ToString()));
			await roleManager.CreateAsync(new IdentityRole(Enum.Roles.Moderator.ToString()));
			await roleManager.CreateAsync(new IdentityRole(Enum.Roles.Basic.ToString()));
		}
	}
}
