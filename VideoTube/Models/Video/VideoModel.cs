using System;
using Models.User;

namespace Models.Video;

public class VideoModel
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public long Likes { get; set; }
    public long Dislikes { get; set; }
    public string? ThumbnailUrl { get; set; }
    public DateTime UloapDate { get; set; }
    public Guid UserId { get; set; }
    public string? Url { get; set; }

    public UserModel? Users { get; set; }
}
