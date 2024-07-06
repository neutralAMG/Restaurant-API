

using AutoMapper;
using SecondHomework.Core.Application.Core;
using SecondHomework.Core.Application.Dtos.EntitiesDtos;
using SecondHomework.Core.Application.Interfaces.Contracts;
using SecondHomework.Core.Application.Interfaces.Repositories;
using SecondHomework.Core.Domain.Entities;

namespace SecondHomework.Core.Application.Services
{
	public class DishIngredientService : BaseService<GetDishIngriedientDto, SaveDishIngredientDto, DishIngridient>, IDishIngridientService
	{
		private readonly IDishIngridientRepository _dishIngridientRepository;
		private readonly IMapper _mapper;

		public DishIngredientService(IDishIngridientRepository dishIngridientRepository, IMapper mapper) : base(dishIngridientRepository, mapper)
		{
			_dishIngridientRepository = dishIngridientRepository;
			_mapper = mapper;
		}
	}
}
