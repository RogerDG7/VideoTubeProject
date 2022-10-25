using System;
using Common.Utilities.ResponseModels;
using Models.User;
using Models.Video;

namespace Bussines.Contract;

public interface IVideoActions
{
    Task<Response<VideoModel>>CreateVideo(VideoRequestModel videoRequest);
    Task<Response<VideoModel>>GetByIdVideo(Guid id);
    Task<Response<ListVideoModel>>GetAllVideosFilter(FiltersVideoModel filters);
    Task<Response<List<VideoModel>>> GetVideosRamdon();
    Task<Response<long>>LikeDislikeVideo(LikeOrDislikeModel likeOrDislikeModel);
}
