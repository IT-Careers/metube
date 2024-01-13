namespace MeTube.Data.Models
{
    public abstract class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        // TODO: Add Timestamps (Created_On, Updated_On, Deleted_On, Created_By, Updated_By, Deleted_By)
        // TODO: Think of where to put these properties.
    }
}
