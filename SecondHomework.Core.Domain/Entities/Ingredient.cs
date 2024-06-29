using SecondHomework.Core.Domain.Core;

namespace SecondHomework.Core.Domain.Entities
{
	public class Ingredient : BaseNameEntity<Guid>
	{
		IList<DishIngridient> DishIngridients { get; set; }
	}
}
