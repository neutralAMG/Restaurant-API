

using SecondHomework.Core.Domain.Core;

namespace SecondHomework.Core.Domain.Entities
{
	public class DishIngridient : BaseEntity<Guid>
	{
		public Guid DishId { get; set; }
		public Guid IngridientId { get; set; }

		public Dish Dish { get; set; }
		public Ingredient Ingredient { get; set; }
	}
}
