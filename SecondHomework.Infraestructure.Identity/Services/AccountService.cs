

using Microsoft.AspNetCore.Identity;
using SecondHomework.Core.Application.Interfaces.Contracts;
using SecondHomework.Infraestructure.Identity.Entities;

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
    }
}
