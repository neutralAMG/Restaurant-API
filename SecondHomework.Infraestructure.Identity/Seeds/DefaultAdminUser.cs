using Microsoft.AspNetCore.Identity;
using SecondHomework.Infraestructure.Identity.Entities;
using SecondHomework.Infraestructure.Identity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHomework.Infraestructure.Identity.Seeds
{
	public static class DefaultAdminUser
	{
		public static async Task SeedAsync(UserManager<AplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			AplicationUser DefaultUser = new();
			DefaultUser.UserName = "adminUserName";
			DefaultUser.FirstName = "Joe";
			DefaultUser.LastName = "Doe";
			DefaultUser.Email = "adminEmail@gmail.com";
			DefaultUser.EmailConfirmed = true;
			DefaultUser.PhoneNumberConfirmed = true;


			if (userManager.Users.All(u => u.Id != DefaultUser.Id))
			{
				var user = await userManager.FindByEmailAsync(DefaultUser.Email);
				if (user is null)
				{
					await userManager.CreateAsync(DefaultUser, "123Pasword!");
					await userManager.AddToRoleAsync(DefaultUser, Roles.Admin.ToString());
				}


			}
		}
	}
}
