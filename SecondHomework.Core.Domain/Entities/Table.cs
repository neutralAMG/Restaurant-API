
using SecondHomework.Core.Domain.Core;
using SecondHomework.Core.Domain.Enums;

namespace SecondHomework.Core.Domain.Entities
{
	public class Table : BaseEntity<Guid>
	{
        public Table()
        {
			TableStateId = (int)StateEnums.Available;
        }
        public int AmountOfPeople { get; set; }
		public string Description {  get; set; }
		public int TableStateId { get; set; }

		public TableState TableState { get; set; }

		public IList<Order> Orders { get; set; }
	}
}
