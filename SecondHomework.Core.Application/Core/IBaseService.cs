

namespace SecondHomework.Core.Application.Core
{
	public interface IBaseService<TGetDto, TSaveDto, TEntity>
		where TGetDto : class
		where TSaveDto : class
		where TEntity : class
	{
		Task<Result<List<TGetDto>>> GetAllAsync();
		Task<Result<TGetDto>> GetByIdAsync(Guid id);
		Task<Result<TSaveDto>> Save(TSaveDto entity);
		Task<Result<TSaveDto>> Update(TSaveDto entity);
		Task<Result<TGetDto>> Delete(Guid id);
	}
}
