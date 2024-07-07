

using SecondHomework.Core.Application.Core;
using SecondHomework.Core.Application.Dtos.EntitiesDtos;
using SecondHomework.Core.Domain.Entities;

namespace SecondHomework.Core.Application.Interfaces.Contracts
{
	public interface ITableService : IBaseService<GetTableDto, SaveTableDto, Table>
	{
		Task<Result<GetOrderDto>> GetTableOrderAsync(Guid id);
		Task<Result<GetTableDto>> ChangeTableStatusAsync(Guid id, int status);
	}
}
