namespace MeTube.Data.Repository;

public interface IBaseRepository<TEntity>
{
    Task<TEntity> CreateAsync(TEntity entity);

    IQueryable<TEntity> GetAll();

    IQueryable<TEntity> GetAllAsNoTracking();

    Task<TEntity> EditAsync(TEntity entity);

    Task<TEntity> DeleteAsync(TEntity entity);
}
