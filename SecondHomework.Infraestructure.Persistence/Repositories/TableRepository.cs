using Microsoft.EntityFrameworkCore;
using SecondHomework.Core.Application.Interfaces.Repositories;
using SecondHomework.Core.Domain.Entities;
using SecondHomework.Infraestructure.Persistence.Context;
using SecondHomework.Infraestructure.Persistence.Core;
using System.Linq;

namespace SecondHomework.Infraestructure.Persistence.Repositories
{
	public class TableRepository : BaseRepository<Table>, ITableRepository
	{
		private readonly SecondHomeworkContext _context;

		public TableRepository(SecondHomeworkContext context) : base(context)
		{
			_context = context;
		}



		public virtual async Task<List<Table>> GetAllAsync()
		{
			try
			{
				return await _context.Tables.Include(t => t.TableState).Include(t => t.Orders).ToListAsync();
			}
			catch
			{
				throw;
			}
		}

		public async Task<Table> GetByIdAsync(Guid id)
		{
			try
			{
				return await _context.Tables.Include(t => t.TableState).Include(t => t.Orders)
					.Where(t => t.Id == id).FirstOrDefaultAsync();
			}
			catch
			{
				throw;
			}
		}

		public virtual async Task<Table> Save(Table entity)
		{
			entity.TableStateId = 1;
			return await base.Save(entity);
		}

		public virtual async Task<Table> Update(Table entity)
		{
			Table TableToUpdate = await GetByIdAsync(entity.Id);

			TableToUpdate.Description = entity.Description;
			TableToUpdate.AmountOfPeople = entity.AmountOfPeople;
		 return	await base.Update(entity);
		}

		public virtual async Task<bool> Delete(Table entity)
		{

			Table TableToBeDelete = await GetByIdAsync(entity.Id);
			return await base.Delete(TableToBeDelete);

		}

		public Task<Order> GetTableOrderAsync(Guid id)
		{
			try
			{
				return _context.Orders.Where(t => t.TableThatOrderIsFor == id && t.IsCompleted == false)
					.FirstOrDefaultAsync();
			}
			catch
			{
				throw;
			}
		}

		public async Task<Table> ChangeTableStatusAsync(Guid id, int status)
		{
			Table TableToBeUpdate =  await GetByIdAsync(id);

			TableToBeUpdate.TableStateId = status;
			
			await base.Update(TableToBeUpdate);

			return TableToBeUpdate;
		}
	}
}
