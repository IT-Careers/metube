﻿namespace MeTube.Data.Models.Comments;

public abstract class Comment : MetadataBaseEntity
{
    public string Content { get; set; }
}
