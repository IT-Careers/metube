using MeTube.Data.Models;
using MeTube.Data.Repository;
using MeTube.Service.Models;

namespace MeTube.Service;

public class AttachmentService : IAttachmentService
{
    private readonly AttachmentRepository _attachmentRepository;

    public AttachmentService(AttachmentRepository repository)
    {
        _attachmentRepository = repository;
    }
    
    public async Task<AttachmentDto> GetById(string id)
    {
        Attachment attachment = await _attachmentRepository.GetById(id);
        
        return AttachmentDto.fromEntity(attachment); 
    }

    public async Task<AttachmentDto> Create(AttachmentDto attachmentDto)
    {
        Attachment attachment = AttachmentDto.toEntity(attachmentDto);
        
        return AttachmentDto.fromEntity(await _attachmentRepository.Create(attachment));
    }

    public async Task<AttachmentDto> Edit(AttachmentDto attachmentDto)
    {
        Attachment attachment = AttachmentDto.toEntity(attachmentDto);
        
        return AttachmentDto.fromEntity(await _attachmentRepository.Edit(attachment));
    }

    public async Task<AttachmentDto> DeleteById(string id)
    {
        return AttachmentDto.fromEntity(await _attachmentRepository.DeleteById(id));
    }
}