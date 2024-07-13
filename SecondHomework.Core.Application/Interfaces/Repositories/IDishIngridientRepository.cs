
using SecondHomework.Core.Application.Core;
using SecondHomework.Core.Domain.Entities;

namespace SecondHomework.Core.Application.Interfaces.Repositories
{
	public interface IDishIngridientRepository : IBaseRepository<DishIngridient>
	{
		Task<DishIngridient> GetByDishId(Guid dishId,  Guid IngridientDto);
	}
}
