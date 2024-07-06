

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SecondHomework.Core.Application.Dtos.Account
{
	public record LoginDto
	{
		public string Email { get; set; }

		public string Password { get; set; }

		public bool HasError { get; set; }

		public string Error { get; set; }
	}
}
