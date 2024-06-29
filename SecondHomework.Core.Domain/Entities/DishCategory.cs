
using SecondHomework.Core.Domain.Core;

namespace SecondHomework.Core.Domain.Entities
{
	public class DishCategory : BaseNameEntity<int>
	{
		public IList<Dish> Dishes { get; set; }
	}
}
