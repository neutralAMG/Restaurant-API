using SecondHomework.Core.Application.Interfaces.Repositories;
using SecondHomework.Core.Domain.Entities;
using SecondHomework.Infraestructure.Persistence.Context;
using SecondHomework.Infraestructure.Persistence.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHomework.Infraestructure.Persistence.Repositories
{
	public class OrderDishRepository : BaseRepository<OrderDish>, IOrderDishRepository
	{
		private readonly SecondHomeworkContext _context;

		public OrderDishRepository(SecondHomeworkContext context) : base(context)
		{
			_context = context;
		}

		public virtual async Task<List<OrderDish>> GetAllAsync()
		{
			try
			{
				return await base.GetAllAsync();
			}
			catch
			{
				throw;
			}
		}

		public async Task<OrderDish> GetByIdAsync(Guid id)
		{
			try
			{
				return await base.GetByIdAsync(id);
			}
			catch
			{
				throw;
			}
		}

		public virtual async Task<OrderDish> Save(OrderDish entity)
		{

			return await base.Save(entity);
		}

		public virtual async Task<OrderDish> Update(OrderDish entity)
		{
			OrderDish OrderDishToUpdate = await GetByIdAsync(entity.Id);

			return await base.Update(OrderDishToUpdate);
		}

		public virtual async Task<bool> Delete(OrderDish entity)
		{
			OrderDish OrderDishToBeDelete = await GetByIdAsync(entity.Id);
			return await base.Delete(OrderDishToBeDelete);

		}
	}
}
