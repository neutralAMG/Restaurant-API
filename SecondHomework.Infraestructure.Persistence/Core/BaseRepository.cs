
using Microsoft.EntityFrameworkCore;
using SecondHomework.Core.Application.Core;
using SecondHomework.Infraestructure.Persistence.Context;

namespace SecondHomework.Infraestructure.Persistence.Core
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
	{
		private readonly SecondHomeworkContext _context;
		private readonly DbSet<TEntity> _entities;
		public BaseRepository(SecondHomeworkContext context)
		{
			_context = context;
			_entities = _context.Set<TEntity>();
		}

		public virtual async Task<bool> ExistAsync(Func<TEntity, bool> filter)
		{
			try
			{
				return _entities.Any(filter);
			}
			catch
			{
				throw;
			}
		}

		public virtual async Task<List<TEntity>> GetAllAsync()
		{
			try
			{
				return await _entities.ToListAsync();
			}
			catch
			{
				throw;
			}
		}

		public async Task<TEntity> GetByIdAsync(Guid id)
		{
			try
			{
				return await Task.FromResult(_entities.Find(id));
			}
			catch
			{
				throw;
			}
		}

		public virtual async Task<TEntity> Save(TEntity entity)
		{
			try
			{
				_entities.Add(entity);
				await _context.SaveChangesAsync();
				return entity;
			}
			catch
			{
				throw;
			}
		}

		public virtual async Task<TEntity> Update(TEntity entity)
		{
			try
			{
				_entities.Attach(entity);
				_entities.Entry(entity).State = EntityState.Modified;
				await _context.SaveChangesAsync();
				return entity;
			}
			catch
			{
				throw;
			}
		}

		public virtual async Task<bool> Delete(TEntity entity)
		{
			try
			{
				_entities.Remove(entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}

		}
	}
}
