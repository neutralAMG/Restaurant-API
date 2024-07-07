

using SecondHomework.Core.Domain.Core;

namespace SecondHomework.Core.Domain.Entities
{
	public class TableState : BaseNameEntity<int>
	{
		public IList<Table> Tables {  get; set; }
	}
}
