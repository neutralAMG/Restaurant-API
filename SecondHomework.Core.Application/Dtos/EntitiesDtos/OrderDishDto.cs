

using SecondHomework.Core.Domain.Entities;

namespace SecondHomework.Core.Application.Dtos.EntitiesDtos
{
	public record BaseOrderDishDto
	{		
		public Guid DishId { get; set; }
	}
	public record GetOrderDishDto 
	{
		public Guid Id { get; set; }
	//	public GetOrderDto Order { get; set; }
		public GetDishDto Dish { get; set; }
	}

	public record SaveOrderDishDto : BaseOrderDishDto
	{
		public Guid OrderId { get; set; }
		public Guid Id { get; set; }
	}
	public record UpdateOrderDishDto : BaseOrderDishDto
	{
		public Guid Id { get; set; }
	}

}
