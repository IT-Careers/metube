namespace MeTube.Data.Models.Comments
{
    public abstract class Comment : BaseEntity
    {
        public string Content { get; set; }

        public MeTubeUser Poster { get; set; }
    }
}
