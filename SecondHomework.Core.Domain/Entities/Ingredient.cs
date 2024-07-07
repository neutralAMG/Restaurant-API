using SecondHomework.Core.Domain.Core;

namespace SecondHomework.Core.Domain.Entities
{
	public class Ingredient : BaseNameEntity<Guid>
	{
	 public	IList<DishIngridient> DishIngridients { get; set; }
	}
}
