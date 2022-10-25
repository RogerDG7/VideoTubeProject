using System;
namespace Entities.Entities;

public class Video
{
#nullable disable
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public long Likes { get; set; }
    public long Dislikes { get; set; }
    public string ThumbnailUrl { get; set; }
    public DateTime UloapDate { get; set; }
    public Guid UserID { get; set; }
    public string Url { get; set; }

    //foreign
    public virtual User Users { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
}
