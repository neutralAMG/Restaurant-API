
using SecondHomework.Core.Domain.Core;

namespace SecondHomework.Core.Domain.Entities
{
	public class OrderDish : BaseEntity<Guid>
	{
		public Guid OrderId { get; set; }
		public Guid DishId { get; set; }

		public Order Order { get; set; }
		public Dish Dish { get; set; }
	}
}
