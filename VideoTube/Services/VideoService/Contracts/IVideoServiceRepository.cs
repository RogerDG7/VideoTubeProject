using System;
using Models.User;
using Models.Video;

namespace Services.VideoService.Contracts
{
    public interface IVideoServiceRepository
    {
        Task<Response<object>> CreateVideo(VideoRequestModel videoRequest);
        Task<Response<object>> GetByIdVideo(Guid id);
        Task<Response<List<Video>>> GetAllVideosFilter(FiltersVideoModel filters);
        Task<Response<List<Video>>> GetVideosRamdon();
        Task<Response<long>> LikeDislikeVideo(LikeOrDislikeModel likeOrDislikeModel);
    }
}

