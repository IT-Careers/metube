namespace MeTube.Data.Models
{
    public class Attachment : BaseEntity
    {
        public string CloudURL { get; set; }
        
        public string BackupURL { get; set; }
    }
}
