using Microsoft.EntityFrameworkCore;
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
	public class OrderRepository : BaseRepository<Order>, IOrderRepository
	{
		private readonly SecondHomeworkContext _context;

		public OrderRepository(SecondHomeworkContext context) : base(context)
		{
			_context = context;
		}

		public virtual async Task<List<Order>> GetAllAsync()
		{
			try
			{
				return await _context.Orders.Include(o => o.Table).Include(o => o.OrderDishes).ThenInclude(o => o.Dish).ToListAsync();
			}
			catch
			{
				throw;
			}
		}

		public async Task<Order> GetByIdAsync(Guid id)
		{
			try
			{
				return await _context.Orders.Include(o => o.Table).Include(o => o.OrderDishes).ThenInclude(o => o.Dish)
					.Where(t => t.Id == id).FirstOrDefaultAsync();
			}
			catch
			{
				throw;
			}
		}

		public virtual async Task<Order> Save(Order entity)
		{

			return await base.Save(entity);
		}

		public virtual async Task<Order> Update(Order entity)
		{
			if (!await ExistAsync(d => d.Id == entity.Id)) return null;


			Order OrderToBeUpdate = await GetByIdAsync(entity.Id);

			OrderToBeUpdate.SubAmount = OrderToBeUpdate.OrderDishes.Select(o => o.Dish.Price).Sum();

			return await base.Update(OrderToBeUpdate);
		}

		public virtual async Task<bool> Delete(Order entity)
		{
			Order OrderToBeDelete = await GetByIdAsync(entity.Id);

			bool DeleteOperation = await base.Delete(OrderToBeDelete);

			if (DeleteOperation)
			{
				List<OrderDish> OrderDishesToDelete = await _context.OrderDishes.Where(o => o.OrderId == entity.Id).ToListAsync();

				_context.OrderDishes.RemoveRange(OrderDishesToDelete);

				await _context.SaveChangesAsync();
			}
			return DeleteOperation;

		}
	}
}
