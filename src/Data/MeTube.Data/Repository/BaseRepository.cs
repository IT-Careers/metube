using MeTube.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MeTube.Data.Repository;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly MeTubeDbContext _dbContext;

    public BaseRepository(MeTubeDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await this._dbContext.AddAsync(entity);
        await this._dbContext.SaveChangesAsync();
        return entity;
    }

    public IQueryable<TEntity> GetAll()
    {
        return this._dbContext.Set<TEntity>().AsQueryable();
    }

    public IQueryable<TEntity> GetAllAsNoTracking()
    {
        return this._dbContext.Set<TEntity>().AsNoTracking();
    }

    public async Task<TEntity> EditAsync(TEntity entity)
    {
        this._dbContext.Update(entity);
        await this._dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        this._dbContext.Remove(entity);
        await this._dbContext.SaveChangesAsync();
        return entity;
    }
}