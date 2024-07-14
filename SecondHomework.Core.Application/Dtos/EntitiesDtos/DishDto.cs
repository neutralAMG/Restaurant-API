

using SecondHomework.Core.Application.Dtos.SubEntitiesDto;
using SecondHomework.Core.Domain.Entities;
using System.Data.SqlTypes;

namespace SecondHomework.Core.Application.Dtos.EntitiesDtos
{
	 public record BaseDishDto
	{
		public string Name { get; set; }
		public double Price { get; set; }
		public int AmountOfPeople { get; set; }
	}
	public record GetDishDto 
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public int AmountOfPeople { get; set; }
		public GetDishCategoryDto DishCategory { get; set; }
		public List<GetDishIngridientDto> DishIngridients { get; set; }
	}
	public record SaveDishDto : BaseDishDto
	{
		public int DishCategoryId { get; set; }
	}

	public record UpdateDishDto : BaseDishDto
	{
		public Guid Id { get; set; }
	}
}
