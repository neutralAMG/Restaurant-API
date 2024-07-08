

using SecondHomework.Core.Domain.Entities;
using System.Data.SqlTypes;

namespace SecondHomework.Core.Application.Dtos.EntitiesDtos
{
	public record BaseOrderDto
	{		
		public double SubAmount { get; set; }
		public bool IsCompleted { get; set; }

	}
	public record GetOrderDto 
	{
		public Guid Id { get; set; }
		public double SubAmount { get; set; }
		public bool IsCompleted { get; set; }
		public GetTableDto Table { get; set; }
		public List<GetOrderDishDto> OrderDishes { get; set; }
	}
	public record SaveOrderDto : BaseOrderDto
	{
		public Guid TableThatOrderIsFor { get; set; }
	}
	public record UpdateOrderDto : BaseOrderDto
	{
		public Guid Id { get; set; }
	}
}
