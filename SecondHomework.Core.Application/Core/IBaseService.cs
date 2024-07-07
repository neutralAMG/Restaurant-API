

namespace SecondHomework.Core.Application.Core
{
	public interface IBaseService<TGetDto, TSaveDto, TUpdateDto, TEntity>
		where TGetDto : class
		where TSaveDto : class
		where TUpdateDto : class
		where TEntity : class
	{
		Task<Result<List<TGetDto>>> GetAllAsync();
		Task<Result<TGetDto>> GetByIdAsync(Guid id);
		Task<Result<TSaveDto>> SaveAsync(TSaveDto entity);
		Task<Result<TUpdateDto>> UpdateAsync(TUpdateDto entity);
		Task<Result<TGetDto>> DeleteAsync(Guid id);
	}
}
