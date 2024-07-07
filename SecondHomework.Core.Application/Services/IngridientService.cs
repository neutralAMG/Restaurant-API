
using AutoMapper;
using SecondHomework.Core.Application.Core;
using SecondHomework.Core.Application.Dtos.EntitiesDtos;
using SecondHomework.Core.Application.Interfaces.Contracts;
using SecondHomework.Core.Application.Interfaces.Repositories;
using SecondHomework.Core.Domain.Entities;

namespace SecondHomework.Core.Application.Services
{
	public class IngridientService : BaseService<GetIngridientDto, SaveIngridientDto, UpdateIngridientDto,Ingredient>, IIngredientService
	{
		private readonly IIngredientRepository _ingredientRepository;
		private readonly IMapper _mapper;

		public IngridientService(IIngredientRepository ingredientRepository, IMapper mapper) : base(ingredientRepository, mapper)
		{
			_ingredientRepository = ingredientRepository;
			_mapper = mapper;
		}
	}
}
