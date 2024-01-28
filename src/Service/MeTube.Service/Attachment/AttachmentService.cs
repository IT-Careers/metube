using MeTube.Data.Models;
using MeTube.Data.Repository;
using MeTube.Model.Mappings;
using MeTube.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace MeTube.Service;

public class AttachmentService : IAttachmentService
{
    private readonly AttachmentRepository _attachmentRepository;

    public AttachmentService(AttachmentRepository repository)
    {
        this._attachmentRepository = repository;
    }
    
    public async Task<AttachmentDto> GetByIdAsync(string id)
    {
        Attachment attachment = await this.GetByIdInternalAsync(id);
        
        return attachment.ToDto(); 
    }
    public IQueryable<AttachmentDto> GetAll()
    {
        return this._attachmentRepository.GetAllAsNoTracking().Select(attachment => attachment.ToDto());
    }

    public async Task<AttachmentDto> CreateAsync(AttachmentDto attachmentDto)
    {
        Attachment attachment = attachmentDto.ToEntity();
        
        return (await this._attachmentRepository.CreateAsync(attachment)).ToDto();
    }

    public async Task<AttachmentDto> EditAsync(AttachmentDto attachmentDto)
    {
        Attachment attachment = attachmentDto.ToEntity();
        
        return (await this._attachmentRepository.EditAsync(attachment)).ToDto();
    }

    public async Task<AttachmentDto> DeleteByIdAsync(string id)
    {
        return (await this.GetByIdInternalAsync(id)).ToDto();
    }

    private async Task<Attachment> GetByIdInternalAsync(string id)
    {
        return await this._attachmentRepository
            .GetAll()
            .SingleOrDefaultAsync(attachment => attachment.Id == id);
    }
}