using MeTube.Data.Models;

namespace MeTube.Data.Repository;

public class MetadataBaseRepository<TEntity> : BaseRepository<TEntity>
    where TEntity : MetadataBaseEntity
{
    public MetadataBaseRepository(MeTubeDbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        entity.CreatedOn = DateTime.Now;
        return await base.CreateAsync(entity);
    }

    public async Task<TEntity> EditAsync(TEntity entity)
    {
        entity.UpdatedOn = DateTime.Now;
        return await base.EditAsync(entity);
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        entity.DeletedOn = DateTime.Now;
        return await base.DeleteAsync(entity);
    }
}