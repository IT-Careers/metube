using MeTube.Service.Models;

namespace MeTube.Service;

public interface IAttachmentService
{
    Task<AttachmentDto> GetById(string id);
    Task<AttachmentDto> Create(AttachmentDto attachmentDto);
    Task<AttachmentDto> Edit(AttachmentDto attachmentDto);
    Task<AttachmentDto> DeleteById(string id);
}