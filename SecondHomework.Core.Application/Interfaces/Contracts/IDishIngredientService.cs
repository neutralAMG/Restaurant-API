
using SecondHomework.Core.Application.Core;
using SecondHomework.Core.Application.Dtos.EntitiesDtos;
using SecondHomework.Core.Domain.Entities;

namespace SecondHomework.Core.Application.Interfaces.Contracts
{
	public interface IDishIngredientService : IBaseService<GetDishIngridientDto, SaveDishIngredientDto, UpdateDishIngredientDto, DishIngridient>
	{
		Task<Result<GetDishIngridientDto>> DeleteAsync(SaveDishIngredientDto saveDto);
	}
}
