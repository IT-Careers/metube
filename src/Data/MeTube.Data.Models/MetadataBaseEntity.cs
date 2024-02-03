using MeTube.Data.Models.Channels;

namespace MeTube.Data.Models;

public class MetadataBaseEntity : BaseEntity
{
   public DateTime CreatedOn { get; set; }
 
   public DateTime UpdatedOn { get; set; }
   
   public DateTime DeletedOn { get; set; }
   
   public Channel? CreatedBy { get; set; }
   
   public Channel? UpdatedBy { get; set; }
   
   public Channel? DeletedBy { get; set; }
}