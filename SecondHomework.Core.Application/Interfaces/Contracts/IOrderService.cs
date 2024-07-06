

using SecondHomework.Core.Application.Core;
using SecondHomework.Core.Application.Dtos.EntitiesDtos;
using SecondHomework.Core.Domain.Entities;

namespace SecondHomework.Core.Application.Interfaces.Contracts
{
	public interface IOrderService : IBaseService<GetOrderDto, SaveOrderDto, Order>
	{
		Task<Result<SaveOrderDto>> UpdateOrderAsync(int Operation,SaveOrderDishDto saveDishDto);
	}
}
