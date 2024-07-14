

using AutoMapper;
using SecondHomework.Core.Application.Core;
using SecondHomework.Core.Application.Dtos.EntitiesDtos;
using SecondHomework.Core.Application.Interfaces.Contracts;
using SecondHomework.Core.Application.Interfaces.Repositories;
using SecondHomework.Core.Domain.Entities;

namespace SecondHomework.Core.Application.Services
{
	public class OrderDishService : BaseService<GetOrderDishDto, SaveOrderDishDto, UpdateOrderDishDto, OrderDish>, IOrderDishService
	{

		private readonly IOrderDishRepository _orderDishRepository;
		private readonly IMapper _mapper;

		public OrderDishService(IOrderDishRepository orderDishRepository, IMapper mapper) : base(orderDishRepository, mapper)
		{

			_orderDishRepository = orderDishRepository;
			_mapper = mapper;
		}

		public async Task<Result<GetOrderDishDto>> DeleteAsync(SaveOrderDishDto saveDto)
		{
			Result<GetOrderDishDto> result = new();
			try
			{
				OrderDish orderDishToBeDeleted = await _orderDishRepository.GetByDishId(saveDto.DishId, saveDto.OrderId);

			 return	await DeleteAsync(orderDishToBeDeleted.Id);
			}
			catch
			{
				result.IsSucces = false;
				result.Message = "Critical error deleting the dish from the order";
				return result;	
			}
		}

	}
}
