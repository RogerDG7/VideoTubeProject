using System;
namespace Models.Video
{
    public class ListVideoModel
    {
        public List<VideoModel> VideoModels { get; set; } = new();
        public PaginationResponse PaginationResponse { get; set; } = new();
    }
}

