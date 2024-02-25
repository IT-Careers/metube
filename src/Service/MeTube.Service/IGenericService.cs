namespace MeTube.Service;

public interface IGenericService<TEntity, TDto>
{
    IQueryable<TDto> GetAll();

    Task<TDto> GetByIdAsync(string id);

    Task<TDto> CreateAsync(TDto reactionTypeDto);

    Task<TDto> EditAsync(string id, TDto reactionTypeDto);

    Task<TDto> DeleteByIdAsync(string id);
}
