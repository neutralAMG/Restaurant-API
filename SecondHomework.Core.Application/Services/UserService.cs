

using AutoMapper;
using SecondHomework.Core.Application.Core;
using SecondHomework.Core.Application.Dtos;
using SecondHomework.Core.Application.Dtos.Account;
using SecondHomework.Core.Application.Interfaces.Contracts;


namespace SecondHomework.Core.Application.Services
{
	public class UserService :  IUserService
	{
		private readonly IAccountService _accountService;
		private readonly IMapper _mapper;

		public UserService(IAccountService accountService, IMapper mapper)
		{
			_accountService = accountService;
			_mapper = mapper;
		}

		public async Task<Result<AuthenticationResponse>> LoginUserAsync(AuthenticationRequest logingRequest)
		{
			Result<AuthenticationResponse> result = new();

			//AuthenticationRequest logingRequest = _mapper.Map<AuthenticationRequest>(loginDto);

			result.Data  = await _accountService.AuthenticateAsync(logingRequest);

			result.Message = "Log in  was succesfull";
			return result;
		}

		public async Task<Result<RegisterResponse>> RegisterBasicUserAsync(RegisterRequest register)
		{
			Result<RegisterResponse> result = new();


			result.Data = await _accountService.RegisterBasicUserAsync(register);

			result.Message = "Register basic user was succesfull";
			return result;
		}
		public async Task<Result<RegisterResponse>> RegisterAdminUserAsync(RegisterRequest register)
		{
			Result<RegisterResponse> result = new();


			result.Data = await _accountService.RegisterAdminUserAsync(register);

			result.Message = "Register Admin user was succesfull";
			return result;
		}

		public async Task<Result<bool>> SingOutAsync(RegisterRequest register)
		{
			Result<bool> result = new();

		    await _accountService.SignOutAsync();

			result.Message = "Sign out was succesfull";
			result.Data = true;
			return result;
		}
	}
}
