namespace MeTube.Data.Models.Reactions
{
    public abstract class Reaction : BaseEntity
    {
        public MeTubeUser User { get; set; }

        public ReactionType Type { get; set; }
        
        // TODO discuss if we can avoid inheritance
        // public ReactionEnum EntityReactionEnum { get; set; }
        //
        // public string entityId { get; set; }
    }
}
