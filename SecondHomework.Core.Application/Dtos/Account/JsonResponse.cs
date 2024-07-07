using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHomework.Core.Application.Dtos.Account
{
	public record  JsonResponse
	{

		public bool HasError { get; set; }
		public string ErrorMessage { get; set; }
	}
}
