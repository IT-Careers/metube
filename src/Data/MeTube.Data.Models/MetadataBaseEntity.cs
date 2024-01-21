namespace MeTube.Data.Models;

public class MetadataBaseEntity : BaseEntity
{
   public DateTime CreatedOn { get; set; }
 
   public DateTime UpdatedOn { get; set; }
   
   public DateTime DeletedOn { get; set; }
   
   public MeTubeUser? CreatedBy { get; set; }
   
   public MeTubeUser? UpdatedBy { get; set; }
   
   public MeTubeUser? DeletedBy { get; set; }
}