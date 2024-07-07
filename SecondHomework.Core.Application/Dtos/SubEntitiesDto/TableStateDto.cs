

namespace SecondHomework.Core.Application.Dtos.SubEntitiesDto
{
	public record GetTableStateDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public record SaveTableStateDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
