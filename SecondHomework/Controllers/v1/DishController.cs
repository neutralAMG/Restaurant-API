using Asp.Versioning;
using AutoMapper;
using SecondHomework.Core.Application.Interfaces.Contracts;



namespace SecondHomework.Presentation.WebApi.Controllers.v1
{
	[ApiVersion("1.0")]
	public class DishController : BaseController
	{
		private readonly IDishService _dishService;

		public DishController(IDishService dishService) 
		{
			
			_dishService = dishService;
		}

	}
}
