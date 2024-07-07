
using SecondHomework.Core.Application.Dtos.SubEntitiesDto;
using SecondHomework.Core.Domain.Entities;

namespace SecondHomework.Core.Application.Dtos.EntitiesDtos
{
	public record BaseTableDto
	{
		public int AmountOfPeople { get; set; }
		public string Description { get; set; }
		
	}
	public record GetTableDto
	{


		public GetTableStateDto TableState { get; set; }

		public List<GetOrderDto> Orders { get; set; }
	}

	public record SaveTableDto : BaseTableDto
	{
	}

	public record UpdateTableDto  : BaseTableDto
	{
		public int TableStateId { get; set; }
		public Guid Id { get; set; }
	}
}
