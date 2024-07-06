
using SecondHomework.Core.Application.Core;
using SecondHomework.Core.Application.Dtos;
using SecondHomework.Core.Application.Dtos.Account;
using SecondHomework.Core.Domain.Entities;

namespace SecondHomework.Core.Application.Interfaces.Contracts
{
	public interface IUserService 
	{
		Task<Result<AuthenticationResponse>> LoginUserAsync(AuthenticationRequest logingRequest);

		Task<Result<RegisterResponse>> RegisterBasicUserAsync(RegisterRequest register);

		Task<Result<RegisterResponse>> RegisterAdminUserAsync(RegisterRequest register);

		Task<Result<bool>> SingOutAsync(RegisterRequest register);

	}
}
