

using Microsoft.EntityFrameworkCore;
using SecondHomework.Core.Application.Interfaces.Repositories;
using SecondHomework.Core.Domain.Entities;
using SecondHomework.Infraestructure.Persistence.Context;
using SecondHomework.Infraestructure.Persistence.Core;

namespace SecondHomework.Infraestructure.Persistence.Repositories
{
	public class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
	{
		private readonly SecondHomeworkContext _context;

		public IngredientRepository(SecondHomeworkContext context) : base(context)
		{
			_context = context;
		}

		public virtual async Task<List<Ingredient>> GetAllAsync()
		{
			try
			{
				return await _context.Ingredients.ToListAsync();
			}
			catch
			{
				throw;
			}
		}

		public async Task<Ingredient> GetByIdAsync(Guid id)
		{
			try
			{
				return await _context.Ingredients
					.Where(t => t.Id == id).FirstOrDefaultAsync();
			}
			catch
			{
				throw;
			}
		}

		public virtual async Task<Ingredient> Save(Ingredient entity)
		{

			return await base.Save(entity);
		}

		public virtual async Task<Ingredient> Update(Ingredient entity)
		{
			if (!await ExistAsync(d => d.Id == entity.Id)) return null;

			Ingredient IngredientToUpdate = await GetByIdAsync(entity.Id);
			IngredientToUpdate.Name = entity.Name;

			return await base.Update(IngredientToUpdate);
		}

		public virtual async Task<bool> Delete(Ingredient entity)
		{
			Ingredient IngredientsToBeDelete = await GetByIdAsync(entity.Id);
			return await base.Delete(IngredientsToBeDelete);

		}
	}
}
