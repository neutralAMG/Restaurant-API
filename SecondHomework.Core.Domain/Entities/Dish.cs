

using SecondHomework.Core.Domain.Core;
using System.Data.SqlTypes;

namespace SecondHomework.Core.Domain.Entities
{
	public class Dish : BaseNameEntity<Guid>
	{
 
        public SqlMoney Price { get; set; }
		public int AmountOfPeople { get; set; }

		public int DishCategoryId { get; set; }

		public DishCategory DishCategory { get; set; }
		public IList<DishIngridient> DishIngridients { get;	set; }
		public IList<OrderDish> OrderDishes { get;	set; }

	}
}
