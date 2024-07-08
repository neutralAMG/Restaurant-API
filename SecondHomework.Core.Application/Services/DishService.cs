

using AutoMapper;
using SecondHomework.Core.Application.Core;
using SecondHomework.Core.Application.Dtos.EntitiesDtos;
using SecondHomework.Core.Application.Interfaces.Contracts;
using SecondHomework.Core.Application.Interfaces.Repositories;
using SecondHomework.Core.Domain.Entities;

namespace SecondHomework.Core.Application.Services
{
	public class DishService : BaseService<GetDishDto, SaveDishDto, UpdateDishDto, Dish>, IDishService
	{
		private readonly IDishRepository _dishRepository;
		private readonly IDishIngredientService _dishIngridientService;
		private readonly IMapper _mapper;

		public DishService(IDishRepository dishRepository, IDishIngredientService dishIngridientService, IMapper mapper) : base(dishRepository, mapper)
		{
			_dishRepository = dishRepository;
			_dishIngridientService = dishIngridientService;
			_mapper = mapper;
		}

		public async Task<Result<SaveDishDto>> UpdateDishAsync(int Operation, SaveDishIngredientDto saveDishIngredientDto)
		{
			Result<SaveDishDto> result = new();
			try
			{
				if (saveDishIngredientDto == null)
				{
					result.IsSucces = false;
					result.Message = "The ingredient to use cant be empty";
					return result;
				}

				if (Operation == (int)Enums.Operation.Create)
				{

					await _dishIngridientService.SaveAsync(saveDishIngredientDto);
					result.Message = "Ingridient was aded to the dish";
				}
				else if (Operation == (int)Enums.Operation.Delete)
				{
					await _dishIngridientService.DeleteAsync(saveDishIngredientDto.Id);
					result.Message = "Ingredient was Deleted from the dish";
				}

				return result;
			}
			catch
			{
				result.IsSucces = false;
				result.Message = "Error doing the operation";
				return result;
			}
		}
	}
}
