using Microsoft.EntityFrameworkCore;
using SecondHomework.Core.Application.Interfaces.Repositories;
using SecondHomework.Core.Domain.Entities;
using SecondHomework.Infraestructure.Persistence.Context;
using SecondHomework.Infraestructure.Persistence.Core;

namespace SecondHomework.Infraestructure.Persistence.Repositories
{
	public class DishRepository : BaseRepository<Dish>, IDishRepository
	{
		private readonly SecondHomeworkContext _context;

		public DishRepository(SecondHomeworkContext context) : base(context)
		{
			_context = context;
		}

		public virtual async Task<List<Dish>> GetAllAsync()
		{
			try
			{
				return  await _context.Dishes
					.Include(o => o.DishCategory)
					.Include(o => o.DishIngridients).ThenInclude( i =>  i.Ingredient).ToListAsync();
			}
			catch
			{
				throw;
			}
		}

		public async Task<Dish> GetByIdAsync(Guid id)
		{
			try
			{
				return await _context.Dishes
					.Include(o => o.DishCategory)
					.Include(o => o.DishIngridients).ThenInclude(i => i.Ingredient)
					.Where(t => t.Id == id).FirstOrDefaultAsync();
			}
			catch
			{
				throw;
			}
		}

		public virtual async Task<Dish> Save(Dish entity)
		{

			return await base.Save(entity);
		}

		public virtual async Task<Dish> Update(Dish entity)
		{
			if (!await ExistAsync(d => d.Id == entity.Id)) return null;

			Dish DishToUpdate = await GetByIdAsync(entity.Id);

		 return	await base.Update(DishToUpdate);
		}

		public virtual async Task<bool> Delete(Dish entity)
		{
			Dish DishToBeDelete = await GetByIdAsync(entity.Id);
			return await base.Delete(DishToBeDelete);

		}
	}
}
