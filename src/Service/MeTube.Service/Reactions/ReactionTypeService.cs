using MeTube.Data.Models.Reactions;
using MeTube.Data.Repository.Reactions;
using MeTube.Service.Mappings.Reactions;
using MeTube.Service.Models.Reactions;
using Microsoft.EntityFrameworkCore;

namespace MeTube.Service.Reactions
{
    public class ReactionTypeService : IReactionTypeService
    {
        private readonly ReactionTypeRepository _reactionTypeRepository;

        public ReactionTypeService(ReactionTypeRepository reactionTypeRepository)
        {
            this._reactionTypeRepository = reactionTypeRepository;
        }

        public async Task<ReactionTypeDto> CreateAsync(ReactionTypeDto reactionTypeDto)
        {
            ReactionType reactionType = reactionTypeDto.ToReactionTypeEntity();

            return (await this._reactionTypeRepository.CreateAsync(reactionType)).ToReactionTypeDto();
        }

        public async Task<ReactionTypeDto> DeleteByIdAsync(string id)
        {
            ReactionType reactionType = await GetByIdInternalAsync(id);

            return (await _reactionTypeRepository.DeleteAsync(reactionType)).ToReactionTypeDto();
        }

        public async Task<ReactionTypeDto> EditAsync(string id, ReactionTypeDto reactionTypeDto)
        {
            ReactionType reactionType = reactionTypeDto.ToReactionTypeEntity();

            return (await this._reactionTypeRepository.EditAsync(reactionType)).ToReactionTypeDto();
        }

        public IQueryable<ReactionTypeDto> GetAll()
        {
            return this._reactionTypeRepository.GetAllAsNoTracking()
                .Include(reactionType => reactionType.ReactionIcon)
                .Select(reactionType => reactionType.ToReactionTypeDto());
        }

        public async Task<ReactionTypeDto> GetByIdAsync(string id)
        {
            return (await GetByIdInternalAsync(id)).ToReactionTypeDto();
        }

        private async Task<ReactionType> GetByIdInternalAsync(string id)
        {
            return await this._reactionTypeRepository.GetAll()
                .SingleOrDefaultAsync(reactionType => reactionType.Id == id);
        }
    }
}
