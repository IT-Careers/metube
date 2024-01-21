using MeTube.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MeTube.Data.Repository;

public class BaseRepository<TEntity> 
    where TEntity : BaseEntity
{
    protected MeTubeDbContext _dbContext;

    public BaseRepository(MeTubeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TEntity> Create(TEntity entity)
    {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> GetById(string id)
    {
        return await _dbContext.Set<TEntity>()
            .FirstAsync(e => e.Id == id);
    }

    public async Task<TEntity> Edit(TEntity entity)
    {
        _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> DeleteById(string id)
    {
        TEntity entity = await GetById(id);
        return await Delete(entity);
    }
    
    public async Task<TEntity> Delete(TEntity entity)
    {
        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }
}