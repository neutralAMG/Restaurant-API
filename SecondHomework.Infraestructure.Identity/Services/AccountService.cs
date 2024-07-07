

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SecondHomework.Core.Application.Dtos.Account;
using SecondHomework.Core.Application.Interfaces.Contracts;
using SecondHomework.Core.Domain.Settings;
using SecondHomework.Infraestructure.Identity.Entities;
using SecondHomework.Infraestructure.Identity.Enums;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SecondHomework.Infraestructure.Identity.Services
{
	public class AccountService : IAccountService
	{
		private readonly UserManager<AplicationUser> _userManager;
		private readonly SignInManager<AplicationUser> _signInManager;
		private readonly JwtSettings _jwtSettings;

		public AccountService(UserManager<AplicationUser> userManager, SignInManager<AplicationUser> signInManager, IOptions<JwtSettings> jwtSettings)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_jwtSettings = jwtSettings.Value;
		}

		public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
		{
			AuthenticationResponse responce = new();

			AplicationUser user = await _userManager.FindByEmailAsync(request.Email);

			if (user == null)
			{
				responce.HasError = true;
				responce.Error = $"No Account exit's with the Email {request.Email}";
				return responce;
			}

			SignInResult result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

			if (!result.Succeeded)
			{

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
			JwtSecurityToken token = await GenerateJwtToken(user);

			
			responce.Id = user.Id;
			responce.UserName = user.UserName;
			responce.Email = user.Email;
			var RolList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
			responce.Roles = RolList.ToList();
			responce.IsVerified = user.EmailConfirmed;
			responce.JwtToken =  new JwtSecurityTokenHandler().WriteToken(token);
			var refreshToken = GenerateRefrehToken();
			responce.RefreshToken = refreshToken.Token;

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

		private async Task<JwtSecurityToken> GenerateJwtToken(AplicationUser user)
		{
			IList<Claim> userClaims = await _userManager.GetClaimsAsync(user);
			IList<string> userRoles = await _userManager.GetRolesAsync(user);

			List<Claim> roleClaims = userRoles.Select(r =>
			{
				return new Claim("Roles", r);

			}).ToList();

			var Claims = new[]{
				new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim("uId", user.Id),
			}.Union(userClaims).Union(roleClaims);

			SymmetricSecurityKey jwtSymeticSecurityKey = new(Encoding.UTF8.GetBytes(_jwtSettings.Key));

			SigningCredentials signInCredentials = new(jwtSymeticSecurityKey, SecurityAlgorithms.HmacSha256);

			JwtSecurityToken jwtSecurityToken = new(
			 issuer: _jwtSettings.Issuer,
			 audience: _jwtSettings.Audience,
			 claims: Claims,
			 expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
			 signingCredentials: signInCredentials
			 );

			return jwtSecurityToken;
		}

		private string RandomTokenStringGenerator()
		{
			using RNGCryptoServiceProvider rngCryptoServiceProvider  = new();

			var RandomByte = new byte[40];

			 rngCryptoServiceProvider.GetBytes(RandomByte);

			return new ByteConverter().ConvertToString(RandomByte).Replace("-", "");
		}

		private RefreshToken GenerateRefrehToken()
		{
			return new RefreshToken
			{
				Token = RandomTokenStringGenerator(),
				Expires = DateTime.UtcNow.AddDays(7),
				Created = DateTime.UtcNow,

			};
		}
	}
}
