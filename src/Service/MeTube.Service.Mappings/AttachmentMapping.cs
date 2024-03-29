﻿using MeTube.Data.Models;
using MeTube.Service.Models;

namespace MeTube.Service.Mappings;

public static class AttachmentMapping
{
    public static Attachment ToAttachmentEntity(this AttachmentDto attachmentDto)
    {
        Attachment attachment = new Attachment();

        attachment.Id = attachmentDto.Id ?? attachment.Id;
        attachment.CloudURL = attachmentDto.CloudURL;
        attachment.BackupURL = attachmentDto.BackupURL;
        
        return attachment;
    }

    public static AttachmentDto ToAttachmentDto(this Attachment attachment)
    {
        AttachmentDto attachmentDto = new AttachmentDto();
        
        attachmentDto.Id = attachment.Id;
        attachmentDto.CloudURL = attachment.CloudURL;
        attachmentDto.BackupURL = attachment.BackupURL;
        
        return attachmentDto;
    }
}