﻿

using Microsoft.AspNetCore.Identity;
using SecondHomework.Infraestructure.Identity.Entities;
using SecondHomework.Infraestructure.Identity.Enums;

namespace SecondHomework.Infraestructure.Identity.Seeds
{
	public static class SuperAdminUser
	{
		public static async Task SeedAsync(UserManager<AplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			AplicationUser DefaultUser = new();
			DefaultUser.UserName = "SupperadminUserName";
			DefaultUser.FirstName = "Joe";
			DefaultUser.LastName = "Doe";
			DefaultUser.Email = "UsersuperadminEmail@gmail.com";
			DefaultUser.EmailConfirmed = true;
			DefaultUser.PhoneNumberConfirmed = true;

			if (userManager.Users.All(u => u.Id != DefaultUser.Id))
			{
				var user = await userManager.FindByEmailAsync(DefaultUser.Email);
				if (user is null)
				{
					await userManager.CreateAsync(DefaultUser, "123Pasword!");
					await userManager.AddToRoleAsync(DefaultUser, Roles.waiter.ToString());
					await userManager.AddToRoleAsync(DefaultUser, Roles.Admin.ToString());
					await userManager.AddToRoleAsync(DefaultUser, Roles.superAdmin.ToString());
				}


			}
		}
	}
}