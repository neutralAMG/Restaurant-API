

namespace SecondHomework.Core.Application.Dtos.SubEntitiesDto
{
	public record GetDishCategoryDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
	public record SaveDishCategoryDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
