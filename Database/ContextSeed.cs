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
			await roleManager.CreateAsync(new IdentityRole(Enum.Roles.Client.ToString()));
		}

		public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			var superadminUser = new ApplicationUser
			{
				UserName = "superadmin",
				Email = "superadmin@gmail.com",
				FirstName = "Super",
				LastName = "Admin",
				EmailConfirmed = true,
				PhoneNumberConfirmed = true,
			};


			if (userManager.Users.All(u => u.Id != superadminUser.Id))
			{
				var user = await userManager.FindByEmailAsync(superadminUser.Email);
				if (user == null)
				{
					await userManager.CreateAsync(superadminUser, "123Password1$");
					await userManager.AddToRoleAsync(superadminUser, Enum.Roles.SuperAdmin.ToString());
					await userManager.AddToRoleAsync(superadminUser, Enum.Roles.Admin.ToString());
					await userManager.AddToRoleAsync(superadminUser, Enum.Roles.Client.ToString());
				}
			}
		}

		public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			var adminUser = new ApplicationUser
			{
				UserName = "admin",
				Email = "admin@gmail.com",
				FirstName = "admin",
				LastName = "istrator",
				EmailConfirmed = true,
				PhoneNumberConfirmed = true,
			};


			if (userManager.Users.All(u => u.Id != adminUser.Id))
			{
				var user = await userManager.FindByEmailAsync(adminUser.Email);
				if (user == null)
				{
					await userManager.CreateAsync(adminUser, "123Password1$");
					await userManager.AddToRoleAsync(adminUser, Enum.Roles.Admin.ToString());

				}
			}
		}
		public static async Task SeedBuyerRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			var buyerUser = new ApplicationUser
			{
				UserName = "buyer",
				Email = "buyer@gmail.com",
				FirstName = "buyer",
				LastName = "buyer",
				EmailConfirmed = true,
				PhoneNumberConfirmed = true,
			};

			if (userManager.Users.All(u => u.Id != buyerUser.Id))
			{
				var user = await userManager.FindByEmailAsync(buyerUser.Email);
				if (user == null)
				{
					await userManager.CreateAsync(buyerUser, "123Password1$");
					await userManager.AddToRoleAsync(buyerUser, Enum.Roles.Client.ToString());
				}
			}
		}
		public static async Task SeedSellerRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			var sellerUser = new ApplicationUser
			{
				UserName = "seller",
				Email = "seller@gmail.com",
				FirstName = "seller",
				LastName = "seller",
				EmailConfirmed = true,
				PhoneNumberConfirmed = true,
			};
			if (userManager.Users.All(u => u.Id != sellerUser.Id))
			{
				var user = await userManager.FindByEmailAsync(sellerUser.Email);
				if (user == null)
				{
					await userManager.CreateAsync(sellerUser, "123Password1$");
					await userManager.AddToRoleAsync(sellerUser, Enum.Roles.Client.ToString());
				}
			}
		}
	}
}
