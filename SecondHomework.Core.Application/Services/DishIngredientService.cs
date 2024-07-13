

using AutoMapper;
using SecondHomework.Core.Application.Core;
using SecondHomework.Core.Application.Dtos.EntitiesDtos;
using SecondHomework.Core.Application.Interfaces.Contracts;
using SecondHomework.Core.Application.Interfaces.Repositories;
using SecondHomework.Core.Domain.Entities;

namespace SecondHomework.Core.Application.Services
{
	public class DishIngredientService : BaseService<GetDishIngridientDto, SaveDishIngredientDto, UpdateDishIngredientDto, DishIngridient>, IDishIngredientService
	{
		private readonly IDishIngridientRepository _dishIngridientRepository;
		private readonly IMapper _mapper;

		public DishIngredientService(IDishIngridientRepository dishIngridientRepository, IMapper mapper) : base(dishIngridientRepository, mapper)
		{
			_dishIngridientRepository = dishIngridientRepository;
			_mapper = mapper;
		}

		public async Task<Result<GetDishIngridientDto>> DeleteAsync(SaveDishIngredientDto saveDto)
		{
			Result<GetDishIngridientDto> result = new();
			try
			{
				DishIngridient dishIngridientToBeDeleted = await _dishIngridientRepository.GetByDishId(saveDto.DishId, saveDto.IngridientId);

				return await DeleteAsync(dishIngridientToBeDeleted.Id);
			}
			catch
			{
				result.IsSucces = false;
				result.Message = "Critical error deleting the ingridient from the dish";
				return result;
			}
		}
	}
}
