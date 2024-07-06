using SecondHomework.Core.Application.Dtos.Account;


namespace SecondHomework.Core.Application.Interfaces.Contracts
{
	public interface IAccountService
	{
		Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);

		Task SignOutAsync();

		Task<RegisterResponse> RegisterBasicUserAsync(RegisterRequest request);


		Task<RegisterResponse> RegisterAdminUserAsync(RegisterRequest request);

	}
}
