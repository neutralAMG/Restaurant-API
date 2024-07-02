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
				return await base.GetAllAsync();
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
				return await base.GetByIdAsync(id);
			}
			catch
			{
				throw;
			}
		}

		public virtual async Task<DishIngridient> Save(DishIngridient entity)
		{

			return await base.Save(entity);
		}

		public virtual async Task<DishIngridient> Update(DishIngridient entity)
		{
			DishIngridient DishIngredientToUpdate = await GetByIdAsync(entity.Id);

		 return	await base.Update(DishIngredientToUpdate);
		}

		public virtual async Task<bool> Delete(DishIngridient entity)
		{
			DishIngridient DishIngredientToBeDelete = await GetByIdAsync(entity.Id);
			return await base.Delete(DishIngredientToBeDelete);

		}
	}
}
