

using AutoMapper;
using SecondHomework.Core.Application.Core;
using SecondHomework.Core.Application.Dtos.EntitiesDtos;
using SecondHomework.Core.Application.Interfaces.Contracts;
using SecondHomework.Core.Application.Interfaces.Repositories;
using SecondHomework.Core.Domain.Entities;

namespace SecondHomework.Core.Application.Services
{
	public class TableService : BaseService<GetTableDto, SaveTableDto, Table>, ITableService
	{
		private readonly ITableRepository _tableRepository;
		private readonly IMapper _mapper;

		public TableService(ITableRepository tableRepository, IMapper mapper) : base(tableRepository, mapper)
		{
			_tableRepository = tableRepository;
			_mapper = mapper;
		}

		public async Task<Result<GetOrderDto>> GetTableOrderAsync(Guid id)
		{
			Result<GetOrderDto> result = new();
			try
			{
				Order OrderGeted = await _tableRepository.GetTableOrderAsync(id);

				if (OrderGeted == null) {
					result.IsSucces = true;
					result.Message = "Error getting the order";
					return result;
				}

				result.Data = _mapper.Map<GetOrderDto>(OrderGeted);

				result.Message = "Order get was succesfull";

				return result;
			}
			catch
			{
				result.IsSucces = true;
				result.Message = "Critical error getting the order";
				return result;
			}
		}
	}
}
