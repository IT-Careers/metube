using MeTube.Data.Models;

namespace MeTube.Service.Models;

public class AttachmentDto : BaseEntityDto
{
    public string CloudURL { get; set; }
        
    public string BackupURL { get; set; }

    
    public static AttachmentDto fromEntity(Attachment attachment)
    {
        AttachmentDto attachmentDto = new AttachmentDto();
        
        attachmentDto.Id = attachment.Id;
        attachmentDto.CloudURL = attachment.CloudURL;
        attachmentDto.BackupURL = attachment.BackupURL;
        
        return attachmentDto;
    }
    
    public static Attachment toEntity(AttachmentDto attachmentDto)
    {
        Attachment attachment = new Attachment();
        
        attachment.Id = attachmentDto.Id;
        attachment.CloudURL = attachmentDto.CloudURL;
        attachment.BackupURL = attachmentDto.BackupURL;
        
        return attachment;
    }
}