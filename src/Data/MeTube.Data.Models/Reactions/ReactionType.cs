namespace MeTube.Data.Models.Reactions;

public class ReactionType : BaseEntity
{
    public Attachment ReactionIcon { get; set; }

    public string Type { get; set; }
}
