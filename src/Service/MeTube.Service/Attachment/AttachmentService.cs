using MeTube.Data.Models;
using MeTube.Data.Repository;
using MeTube.Model.Mappings;
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
        Attachment attachment = GetByIdInternal(id);
        
        return AttachmentMapping.ToDto(attachment); 
    }

    public async Task<AttachmentDto> Create(AttachmentDto attachmentDto)
    {
        Attachment attachment = AttachmentMapping.ToEntity(attachmentDto);
        
        return AttachmentMapping.ToDto(await _attachmentRepository.Create(attachment));
    }

    public async Task<AttachmentDto> Edit(AttachmentDto attachmentDto)
    {
        Attachment attachment = AttachmentMapping.ToEntity(attachmentDto);
        
        return AttachmentMapping.ToDto(await _attachmentRepository.Edit(attachment));
    }

    public async Task<AttachmentDto> DeleteById(string id)
    {
        return AttachmentMapping.ToDto(GetByIdInternal(id));
    }

    private Attachment GetByIdInternal(string id)
    {
        return _attachmentRepository.GetAll()
            .Result.First(attachment => attachment.Id == id);
    }
}