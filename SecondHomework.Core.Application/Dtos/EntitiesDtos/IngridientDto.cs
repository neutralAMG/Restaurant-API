

using SecondHomework.Core.Domain.Entities;

namespace SecondHomework.Core.Application.Dtos.EntitiesDtos
{
	public record BaseIngridientDto
	{
		public string Name { get; set; }
	}
	public record GetIngridientDto 
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public List<GetDishIngridientDto> DishIngridients { get; set; }
	}
	public record SaveIngridientDto : BaseIngridientDto
	{
	}
	public record UpdateIngridientDto : BaseIngridientDto
	{
		public Guid Id { get; set; }
	}
}
