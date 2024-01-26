using MeTube.Data.Models;

namespace MeTube.Data.Repository;

public class MetadataBaseRepository<TEntity> : BaseRepository<TEntity>
    where TEntity : MetadataBaseEntity
{
    public MetadataBaseRepository(MeTubeDbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<TEntity> Create(TEntity entity)
    {
        entity.CreatedOn = DateTime.Now;
        return await base.Create(entity);
    }

    public async Task<TEntity> Edit(TEntity entity)
    {
        entity.UpdatedOn = DateTime.Now;
        return await base.Edit(entity);
    }

    public async Task<TEntity> Delete(TEntity entity)
    {
        entity.DeletedOn = DateTime.Now;
        return await base.Delete(entity);
    }
}