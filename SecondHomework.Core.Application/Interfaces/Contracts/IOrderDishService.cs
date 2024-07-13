
using SecondHomework.Core.Application.Core;
using SecondHomework.Core.Application.Dtos.EntitiesDtos;
using SecondHomework.Core.Domain.Entities;

namespace SecondHomework.Core.Application.Interfaces.Contracts
{
	public interface IOrderDishService : IBaseService<GetOrderDishDto, SaveOrderDishDto, UpdateOrderDishDto, OrderDish>
	{
	 Task<Result<GetOrderDishDto>> DeleteAsync(SaveOrderDishDto saveDto);
	}
}
