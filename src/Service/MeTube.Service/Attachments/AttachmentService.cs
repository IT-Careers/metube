using MeTube.Data.Models;
using MeTube.Data.Repository;
using MeTube.Model.Mappings;
using MeTube.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace MeTube.Service.Attachments;

public class AttachmentService : IAttachmentService
{
    private readonly AttachmentRepository _attachmentRepository;

    public AttachmentService(AttachmentRepository repository)
    {
        _attachmentRepository = repository;
    }

    public async Task<AttachmentDto> GetByIdAsync(string id)
    {
        Attachment attachment = await GetByIdInternalAsync(id);

        return attachment.ToDto();
    }
    public IQueryable<AttachmentDto> GetAll()
    {
        return _attachmentRepository.GetAllAsNoTracking().Select(attachment => attachment.ToDto());
    }

    public async Task<AttachmentDto> CreateAsync(AttachmentDto attachmentDto)
    {
        Attachment attachment = attachmentDto.ToEntity();

        return (await _attachmentRepository.CreateAsync(attachment)).ToDto();
    }

    public async Task<AttachmentDto> EditAsync(AttachmentDto attachmentDto)
    {
        Attachment attachment = attachmentDto.ToEntity();

        return (await _attachmentRepository.EditAsync(attachment)).ToDto();
    }

    public async Task<AttachmentDto> DeleteByIdAsync(string id)
    {
        return (await GetByIdInternalAsync(id)).ToDto();
    }

    private async Task<Attachment> GetByIdInternalAsync(string id)
    {
        return await _attachmentRepository
            .GetAll()
            .SingleOrDefaultAsync(attachment => attachment.Id == id);
    }

    public AttachmentDto CreateAttachmentFromCloudinaryPayload(Dictionary<string, object> payload)
    {
        AttachmentDto attachmentDto = new AttachmentDto();

        attachmentDto.CloudURL = payload["url"].ToString();

        return attachmentDto;
    }
}