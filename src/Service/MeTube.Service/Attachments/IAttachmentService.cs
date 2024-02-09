using MeTube.Service.Models;

namespace MeTube.Service.Attachments;

public interface IAttachmentService
{
    AttachmentDto CreateAttachmentFromCloudinaryPayload(Dictionary<string, object> payload);

    Task<AttachmentDto> GetByIdAsync(string id);

    IQueryable<AttachmentDto> GetAll();

    Task<AttachmentDto> CreateAsync(AttachmentDto attachmentDto);

    Task<AttachmentDto> EditAsync(AttachmentDto attachmentDto);

    Task<AttachmentDto> DeleteByIdAsync(string id);
}