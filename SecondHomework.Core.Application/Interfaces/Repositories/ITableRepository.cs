using SecondHomework.Core.Application.Core;
using SecondHomework.Core.Domain.Entities;

namespace SecondHomework.Core.Application.Interfaces.Repositories
{
	public interface ITableRepository : IBaseRepository<Table>
	{
		Task<Order> GetTableOrderAsync(Guid id);
	}
}
