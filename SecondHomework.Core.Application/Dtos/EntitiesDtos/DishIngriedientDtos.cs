
using SecondHomework.Core.Domain.Entities;

namespace SecondHomework.Core.Application.Dtos.EntitiesDtos
{
	public record BaseDishIngriedientDto
	{
		public Guid DishId { get; set; }
		public Guid IngridientId { get; set; }
	}
	public record  GetDishIngridientDto 
	{
		public Guid Id { get; set; }
	//	public GetDishDto Dish { get; set; }
		public GetIngridientDto Ingredient { get; set; }
	}
	public record SaveDishIngredientDto : BaseDishIngriedientDto
	{
		public Guid Id { get; set; }
	}
	public record UpdateDishIngredientDto : BaseDishIngriedientDto
	{
		public Guid Id { get; set; }
	}
}
