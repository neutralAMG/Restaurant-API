using Microsoft.AspNetCore.Identity;
using SecondHomework.Infraestructure.Identity.Entities;
using SecondHomework.Infraestructure.Identity.Enums;

namespace SecondHomework.Infraestructure.Identity.Seeds
{
	public static class DefaultRols
	{
		public static async Task SeedAsync(UserManager<AplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			await roleManager.CreateAsync(new IdentityRole(Roles.superAdmin.ToString()));
			await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
			await roleManager.CreateAsync(new IdentityRole(Roles.waiter.ToString()));
		}
	}
}
