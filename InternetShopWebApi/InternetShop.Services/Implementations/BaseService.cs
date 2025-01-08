using InternetShop.Repositories.Interfaces;
using AutoMapper;
using InternetShop.Services.Interfaces;

namespace InternetShop.Services.Implementations
{
	public class BaseService<TModel, TDto> : IBaseService<TDto>
		where TModel : class
		where TDto : class
	{
		protected readonly IBaseRepository<TModel> _repository;
		protected readonly IMapper _mapper;

		public BaseService(IBaseRepository<TModel> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public virtual async Task<List<TDto>> GetAllAsync()
		{
			var entities = await _repository.GetAllAsync();
			return _mapper.Map<List<TDto>>(entities);
		}

		public virtual async Task<TDto?> GetByIdAsync(int id)
		{
			var entity = await _repository.GetByIdAsync(id);
			if (entity == null) return null;
			return _mapper.Map<TDto>(entity);
		}

		public virtual async Task<TDto> CreateAsync(TDto dto)
		{
			var model = _mapper.Map<TModel>(dto);
			var created = await _repository.CreateAsync(model);
			return _mapper.Map<TDto>(created);
		}

		public virtual async Task<TDto?> UpdateAsync(int id, TDto dto)
		{
			var existing = await _repository.GetByIdAsync(id);
			if (existing == null) return null;

			_mapper.Map(dto, existing);
			var updated = await _repository.UpdateAsync(existing);
			return _mapper.Map<TDto>(updated);
		}

		public virtual async Task<bool> DeleteAsync(int id)
		{
			return await _repository.DeleteByIdAsync(id);
		}
	}

}
