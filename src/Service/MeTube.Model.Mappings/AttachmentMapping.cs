using MeTube.Data.Models;
using MeTube.Service.Models;

namespace MeTube.Model.Mappings;

public static class AttachmentMapping
{
    public static Attachment ToEntity(AttachmentDto dto)
    {
        Attachment entity = new Attachment();

        entity.Id = dto.Id;
        entity.CloudURL = dto.CloudURL;
        entity.BackupURL = dto.BackupURL;
        
        return entity;
    }

    public static AttachmentDto ToDto(Attachment entity)
    {
        AttachmentDto dto = new AttachmentDto();
        
        dto.Id = entity.Id;
        dto.CloudURL = entity.CloudURL;
        dto.BackupURL = entity.BackupURL;
        
        return dto;
    }
}