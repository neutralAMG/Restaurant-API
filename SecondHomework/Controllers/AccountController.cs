using Microsoft.AspNetCore.Mvc;
using SecondHomework.Core.Application.Dtos.Account;
using SecondHomework.Core.Application.Interfaces.Contracts;

namespace SecondHomework.Presentation.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
			_accountService = accountService;

		}
		[HttpPost("Authenticate")]
		public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
		{
			return Ok( await _accountService.AuthenticateAsync(request));
		}

		[HttpPost("RegisterBasicUser")]
		public async Task<IActionResult> RegisterBasicUserAsync(RegisterRequest request)
		{
			return Ok(await _accountService.RegisterBasicUserAsync(request));
		}

		[HttpPost("RegisterAdminUser")]
		public async Task<IActionResult> RegisterAdminUserAsync(RegisterRequest request)
		{
			return Ok(await _accountService.RegisterAdminUserAsync(request));
		}
	}
}
