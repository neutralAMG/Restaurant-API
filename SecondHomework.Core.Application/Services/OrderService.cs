
using AutoMapper;
using SecondHomework.Core.Application.Core;
using SecondHomework.Core.Application.Dtos.EntitiesDtos;
using SecondHomework.Core.Application.Interfaces.Contracts;
using SecondHomework.Core.Application.Interfaces.Repositories;
using SecondHomework.Core.Domain.Entities;

namespace SecondHomework.Core.Application.Services
{
	public class OrderService : BaseService<GetOrderDto, SaveOrderDto, UpdateOrderDto, Order>, IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IMapper _mapper;
		private readonly IOrderDishService _orderDishService;
		private readonly IOrderDishRepository _orderDishRepository;

		public OrderService(IOrderRepository orderRepository, IMapper mapper, IOrderDishService orderDishService) : base(orderRepository, mapper)
		{
			_orderRepository = orderRepository;
			_mapper = mapper;
			_orderDishService = orderDishService;
		}

		public async Task<Result<SaveOrderDto>> UpdateOrderAsync(int Operation, SaveOrderDishDto saveOrderDishDto)
		{
			Result<SaveOrderDto> result = new();
			try
			{
				if (saveOrderDishDto == null)
				{
					result.IsSucces = false;
					result.Message = "The Dish to use cant be empty";
					return result;
				}

				if (Operation == (int)Enums.Operation.Create)
				{
					await _orderDishService.SaveAsync(saveOrderDishDto);
					result.Message = "Dish was aded to the order";
				}
				else if (Operation == (int)Enums.Operation.Delete)
				{
					await _orderDishService.DeleteAsync(saveOrderDishDto);
					result.Message = "Dish was Deleted from the order";
				}

				Order orderToBeUpdate = await _orderRepository.GetByIdAsync(saveOrderDishDto.OrderId);

				await _orderRepository.Update(orderToBeUpdate);

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
