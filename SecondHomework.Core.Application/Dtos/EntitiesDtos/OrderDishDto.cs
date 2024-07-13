

using SecondHomework.Core.Domain.Entities;

namespace SecondHomework.Core.Application.Dtos.EntitiesDtos
{
	public record BaseOrderDishDto
	{		
		public Guid DishId { get; set; }
		public Guid OrderId { get; set; }
	}
	public record GetOrderDishDto 
	{
		public Guid Id { get; set; }
	//	public GetOrderDto Order { get; set; }
		public GetDishDto Dish { get; set; }
	}

	public record SaveOrderDishDto : BaseOrderDishDto
	{
	
	}
	public record UpdateOrderDishDto : BaseOrderDishDto
	{
		
	}

}
