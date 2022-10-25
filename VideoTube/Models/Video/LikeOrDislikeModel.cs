using System;
namespace Models.Video
{
    public class LikeOrDislikeModel
    {
        public Guid VideoId { get; set; }
        public bool IsLike { get; set; }
    }
}

