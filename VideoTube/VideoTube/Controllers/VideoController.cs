using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Video;

namespace VideoTube.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideoController : ControllerBase
{
    private readonly IVideoActions _videoActions;

    public VideoController(IVideoActions videoActions)
    {
        _videoActions = videoActions;
    }

    /// <summary>
    /// create Video
    /// </summary>
    /// <returns>Response model CommentModel</returns>
    [HttpPost]
    [Route("[action]")]
    public async Task<Response<VideoModel>> CreateVideo(VideoRequestModel videoModel)
    {
        Response<VideoModel> response = new();
        try
        {
            response = await _videoActions.CreateVideo(videoModel);
            return response;
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Message = MessageExtension.AddMessageList(ex.Message);
            return response;
        }
    }

    /// <summary>
    /// Get all videos with filters
    /// </summary>
    /// <returns>Response ListVideoModel</returns>
    [HttpPost]
    [Route("[action]")]
    public async Task<Response<ListVideoModel>> GetAllVideosFilter(FiltersVideoModel filtersVideoModel)
    {
        Response<ListVideoModel> response = new();
        try
        {
            response = await _videoActions.GetAllVideosFilter(filtersVideoModel);
            return response;
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Message = MessageExtension.AddMessageList(ex.Message);
            return response;
        }
    }

    /// <summary>
    /// Get Video by ID
    /// </summary>
    /// <returns>Response model UserModel</returns>
    [HttpGet]
    [Route("[action]")]
    public async Task<Response<VideoModel>> GetByIdVideo(Guid id)
    {
        Response<VideoModel> response = new();
        try
        {
            response = await _videoActions.GetByIdVideo(id);
            return response;
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Message = MessageExtension.AddMessageList(ex.Message);
            return response;
        }
    }

    /// <summary>
    /// Get all Videos Ramdon
    /// </summary>
    /// <returns>Response list model VideoModel</returns>
    [HttpGet]
    [Route("[action]")]
    public async Task<Response<List<VideoModel>>> GetVideosRandom()
    {
        Response<List<VideoModel>> response = new();
        try
        {
            response = await _videoActions.GetVideosRamdon();
            return response;
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Message = MessageExtension.AddMessageList(ex.Message);
            return response;
        }
    }

    /// <summary>
    /// Like or dislike video
    /// </summary>
    /// <returns>Response list model VideoModel</returns>
    [HttpPost]
    [Route("[action]")]
    public async Task<Response<long>> LikeOrDislikeVideo(LikeOrDislikeModel likeOrDislikeModel)
    {
        Response<long> response = new();
        try
        {
            response = await _videoActions.LikeDislikeVideo(likeOrDislikeModel);
            return response;
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Message = MessageExtension.AddMessageList(ex.Message);
            return response;
        }
    }


}
