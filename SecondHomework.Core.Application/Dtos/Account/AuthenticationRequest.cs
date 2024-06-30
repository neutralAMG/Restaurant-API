

namespace SecondHomework.Core.Application.Dtos.Account
{
	public record AuthenticationRequest
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
