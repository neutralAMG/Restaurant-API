

using Microsoft.AspNetCore.Identity;
using SecondHomework.Core.Application.Dtos.Account;
using SecondHomework.Core.Application.Interfaces.Contracts;
using SecondHomework.Infraestructure.Identity.Entities;
using SecondHomework.Infraestructure.Identity.Enums;

namespace SecondHomework.Infraestructure.Identity.Services
{
	public class AccountService
	{
		private readonly UserManager<AplicationUser> _userManager;
		private readonly SignInManager<AplicationUser> _signInManager;
		private readonly IEmailService _emailService;
        public AccountService(UserManager<AplicationUser> userManager, SignInManager<AplicationUser> signInManager, IEmailService emailService )
        {
			_userManager = userManager;
			_signInManager = signInManager;
			_emailService = emailService;
		}

		public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
		{
			AuthenticationResponse responce = new();

			AplicationUser user = await _userManager.FindByEmailAsync(request.Email);

			if (user == null) {
				responce.HasError = true;
				responce.Error = $"No Account exit's with the Email {request.Email}";
				return responce;
			}

			SignInResult result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

			if (!result.Succeeded) {

				responce.HasError = true;
				responce.Error = $"Invalid credential for {request.Email}";
				return responce;
			}


			//if (!user.EmailConfirmed)
			//{
			//	responce.HasError = true;
			//	responce.Error = $"Acount not confirmed for {request.Email}";
			//	return responce;
			//}

			responce.Id = user.Id;
			responce.UserName = user.UserName;
			responce.Email = user.Email;
			var RolList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
			responce.Roles = RolList.ToList();
			responce.IsVerified = user.EmailConfirmed;

			return responce;
		}

		public async Task SignOutAsync()
		{
			await _signInManager.SignOutAsync();
		}

		public async Task<RegisterResponse> RegisterBasicUserAsync(RegisterRequest request)
		{
			RegisterResponse responce = new();
			responce.HasError = false;

			AplicationUser userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);

			if (userWithSameUserName != null) {
				responce.HasError = true;
				responce.Error = $"There's already a user with the username {request.UserName}";
				return responce;
			}

			AplicationUser userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);

			if (userWithSameUserName != null)
			{
				responce.HasError = true;
				responce.Error = $"There's already a user with the email {request.UserName}";
				return responce;
			}

			AplicationUser user = new()
			{
				Email = request.Email,
				UserName = request.UserName,	
				FirstName = request.FirstName,
				LastName = request.LastName,
			};

			IdentityResult result = await _userManager.CreateAsync(user, request.Password);

			if (!result.Succeeded) { 
				responce.HasError = true;	
				responce.Error = result.Errors.First().Description;	
				return responce;
			}

			user.EmailConfirmed = true;
			user.PhoneNumberConfirmed = true;
			await _userManager.AddToRoleAsync(user, Roles.waiter.ToString());

			return responce;
		}


		public async Task<RegisterResponse> RegisterAdminUserAsync(RegisterRequest request)
		{
			RegisterResponse responce = new();
			responce.HasError = false;

			AplicationUser userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);

			if (userWithSameUserName != null)
			{
				responce.HasError = true;
				responce.Error = $"There's already a user with the username {request.UserName}";
				return responce;
			}

			AplicationUser userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);

			if (userWithSameUserName != null)
			{
				responce.HasError = true;
				responce.Error = $"There's already a user with the email {request.UserName}";
				return responce;
			}

			AplicationUser user = new()
			{
				Email = request.Email,
				UserName = request.UserName,
				FirstName = request.FirstName,
				LastName = request.LastName,
			};

			IdentityResult result = await _userManager.CreateAsync(user, request.Password);

			if (!result.Succeeded)
			{
				responce.HasError = true;
				responce.Error = result.Errors.First().Description;
				return responce;
			}

			user.EmailConfirmed = true;
			user.PhoneNumberConfirmed = true;
			await _userManager.AddToRoleAsync(user, Roles.Admin.ToString());

			return responce;
		}
	}
}
