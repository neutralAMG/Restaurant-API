


using AutoMapper;

namespace SecondHomework.Core.Application.Core
{
	public class BaseService<TGetDto, TSaveDto, TEntity> : IBaseService<TGetDto, TSaveDto, TEntity>
		where TGetDto : class
		where TSaveDto : class
		where TEntity : class
	{
		private readonly IBaseRepository<TEntity> _baseRepository;
		private readonly IMapper _mapper;

		public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
        {
			_baseRepository = baseRepository;
			_mapper = mapper;
		}

        public virtual async Task<Result<List<TGetDto>>> GetAllAsync()
		{
			Result<List<TGetDto>> result = new();
			try
			{
				List<TEntity> EntitiesGetted = await _baseRepository.GetAllAsync();

				if (EntitiesGetted == null) {
					result.IsSucces = false;
					result.Message = "Error Getting the entities";
					return result;
				}

				result.Data = _mapper.Map<List<TGetDto>>(EntitiesGetted);

				if (result.Data == null)
				{
					result.IsSucces = false;
					result.Message = "Error Getting the entities";
					return result;
				}

				result.Message = "Entities Get was succesfully";
				return result;	
			}
			catch
			{
				result.IsSucces = false;
				result.Message = "Critical error Getting the entities";
				return result;
			}
		}

		public virtual async Task<Result<TGetDto>> GetByIdAsync(Guid id)
		{
			Result<TGetDto> result = new();	
			try
			{
				TEntity EntityGettd = await _baseRepository.GetByIdAsync(id);

				if (EntityGettd == null) {
					result.IsSucces = false;
					result.Message = "Error getting the entity";
					return result;
				}

				result.Data = _mapper.Map<TGetDto>(EntityGettd);

				if(result.Data == null)
				{
					result.IsSucces = false;
					result.Message = "Error getting the entity";
					return result;
				}

				result.Message = "Entity get was succesfully";
				return result;

			}
			catch
			{
				result.IsSucces = false;
				result.Message = "Critical error getting the entity";
				return result;
			}
		}

		public virtual async Task<Result<TSaveDto>> Save(TSaveDto entity)
		{
			Result<TSaveDto> result = new();
			try
			{
				if (entity == null) {
					result.IsSucces = false;
					result.Message = "The entity to be saved can not be empty";
					return result;
				}

				TEntity EntityToBeSave = _mapper.Map<TEntity>(entity);

				if (EntityToBeSave == null)
				{
					result.IsSucces = false;
					result.Message = "Error saving the entity";
					return result;
				}
				TEntity EntitySaved = await _baseRepository.Save(EntityToBeSave);
				
				result.Data = _mapper.Map<TSaveDto>(EntityToBeSave);

				if (result.Data == null)
				{
					result.IsSucces = false;
					result.Message = "Error saving the entity";
					return result;
				}

				result.Message = "Entity Saved was a succes";
				return result;
			}
			catch
			{
				result.IsSucces = false;
				result.Message = "Critical error saving the entity";
				return result;
			}
		}

		public virtual async Task<Result<TSaveDto>> Update(TSaveDto entity)
		{
			Result<TSaveDto> result = new();
			try
			{
				if (entity == null)
				{
					result.IsSucces = false;
					result.Message = "The entoty to be updated can not be empty";
					return result;
				}

				TEntity EntityToBeUpdated = _mapper.Map<TEntity>(entity);

				if(EntityToBeUpdated == null)
				{
					result.IsSucces = false;
					result.Message = "Error Updating the entity";
					return result;
				}
				TEntity EntityUpdated = await _baseRepository.Update(EntityToBeUpdated);

				if (EntityUpdated == null)
				{
					result.IsSucces = false;
					result.Message = "Error Updating the entity";
					return result;
				}

				result.Data = _mapper.Map<TSaveDto>(EntityUpdated);

				if (result.Data == null)
				{
					result.IsSucces = false;
					result.Message = "Error Updating the entity";
					return result;
				}

				result.Message = "Entity updated was a success";
				return result;
			}
			catch
			{
				result.IsSucces = false;
				result.Message = "Critical error Updating the entity";
				return result;
			}
		}
		
		public virtual async Task<Result<TGetDto>> Delete(Guid id)
		{
			Result<TGetDto> result = new();
			try
			{
				TEntity EntityToBeDeleted = await _baseRepository.GetByIdAsync(id);

				if (EntityToBeDeleted == null)
				{
					result.IsSucces = false;
					result.Message = "Error Deleting the entity";
					return result;
				}

				bool IsDeleteSuccesfull = await _baseRepository.Delete(EntityToBeDeleted);

				if (IsDeleteSuccesfull == false)
				{
					result.IsSucces = false;
					result.Message = "Error Deleting the entity";
					return result;
				}

				result.Message = "Entity delete was succes";
				return result;
			}
			catch
			{
				result.IsSucces = false;
				result.Message = "Critical error Deleting the entity";
				return result;
			}
		}

	}
}
