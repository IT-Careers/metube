namespace MeTube.Data.Models.Reactions
{
    public abstract class Reaction : BaseEntity
    {
        public MeTubeUser User { get; set; }

        public ReactionType Type { get; set; }
    }
}
