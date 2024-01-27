namespace MeTube.Service.Models;

public class AttachmentDto : BaseEntityDto
{
    public string CloudURL { get; set; }
        
    public string BackupURL { get; set; }
}