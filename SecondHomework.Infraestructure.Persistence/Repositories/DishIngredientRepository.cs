using Microsoft.EntityFrameworkCore;
using SecondHomework.Core.Application.Interfaces.Repositories;
using SecondHomework.Core.Domain.Entities;
using SecondHomework.Infraestructure.Persistence.Context;
using SecondHomework.Infraestructure.Persistence.Core;


namespace SecondHomework.Infraestructure.Persistence.Repositories
{
	public class DishIngredientRepository : BaseRepository<DishIngridient>, IDishIngridientRepository
	{
		private readonly SecondHomeworkContext _context;

		public DishIngredientRepository(SecondHomeworkContext context) : base(context)
		{
			_context = context;
		}

		public virtual async Task<List<DishIngridient>> GetAllAsync()
		{
			try
			{
				return await _context.DishIngridients.Include(d => d.Ingredient).ToListAsync();
			}
			catch
			{
				throw;
			}
		}

		public async Task<DishIngridient> GetByIdAsync(Guid id)
		{
			try
			{
				return await _context.DishIngridients.Include(d => d.Ingredient).Where(d => d.Id == id).FirstOrDefaultAsync();
			}
			catch
			{
				throw;
			}
		}

		public virtual async Task<DishIngridient> Save(DishIngridient entity)
		{
			if (await ExistAsync(d => d.IngridientId == entity.IngridientId && d.DishId == entity.DishId)) return null;

			return await base.Save(entity);
		}

		public virtual async Task<DishIngridient> Update(DishIngridient entity)
		{
			if (!await ExistAsync(d => d.Id == entity.Id )) return null;

			DishIngridient DishIngredientToUpdate = await GetByIdAsync(entity.Id);

		 return	await base.Update(DishIngredientToUpdate);
		}

		public virtual async Task<bool> Delete(DishIngridient entity)
		{
			DishIngridient DishIngredientToBeDelete = await GetByIdAsync(entity.Id);
			return await base.Delete(DishIngredientToBeDelete);

		}

		public async Task<DishIngridient> GetByDishId(Guid dishId, Guid IngridientDto)
		{
		  return await _context.DishIngridients.Where( d => d.DishId == dishId && d.IngridientId == IngridientDto).FirstOrDefaultAsync();	
		}
	}
}
