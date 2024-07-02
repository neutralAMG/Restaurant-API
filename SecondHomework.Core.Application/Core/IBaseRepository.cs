using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHomework.Core.Application.Core
{
	public interface IBaseRepository<TEntity> where TEntity : class
	{
		Task<bool> ExirsAsync(Func<TEntity, bool> filter);
		Task<List<TEntity>> GetAllAsync();
		Task<TEntity> GetByIdAsync(Guid id);
		Task<TEntity> Save(TEntity entity);
		Task<TEntity> Update(TEntity entity);
		Task<bool> Delete(TEntity entity);
	}
}
