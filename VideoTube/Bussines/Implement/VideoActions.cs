using System;
using AutoMapper;
using Bussines.Contract;
using Common.Helpers;
using Common.Utilities.ResponseModels;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Models.User;
using Models.Video;
using Services.VideoService.Contracts;

namespace Bussines.Implement;

public class VideoActions : IVideoActions
{
    private readonly IVideoServiceRepository _videoService;
    private readonly IMapper _mapper;

    public VideoActions(IVideoServiceRepository videoRepository, IMapper mapper)
    {
        _videoService = videoRepository;
        _mapper = mapper;
    }

    public async Task<Response<VideoModel>> CreateVideo(VideoRequestModel videoRequest)
    {
        var result = await _videoService.CreateVideo(videoRequest);
        Response<VideoModel> response = new()
        {
            Status = result.Status,
            Message = result.Message,
            ObjectResponse = result.ObjectResponse != null ?
                _mapper.Map<VideoModel>(result.ObjectResponse) : null
        };
        return response;
    }

    public async Task<Response<ListVideoModel>> GetAllVideosFilter(FiltersVideoModel filters)
    {
        var result = await _videoService.GetAllVideosFilter(filters);
        ListVideoModel listVideoModel = new();
        if (result.ObjectResponse != null)
        {
            IQueryable<Video> videosResponse = result.ObjectResponse.AsQueryable().AsNoTracking();
            if (filters.Pagination.IsPaginable)
            {
                double pages =  QueryableExtension.TotalRow(videosResponse, filters.Pagination.ItemsPerPage);
                listVideoModel.PaginationResponse.TotalItems =  videosResponse.Count();
                listVideoModel.PaginationResponse.TotalPages = (int)pages;
                listVideoModel.VideoModels.AddRange(_mapper.Map<List<Video>, List<VideoModel>>(videosResponse.Paginate(filters.Pagination).ToList()));
            }
            else
            {
                listVideoModel.PaginationResponse.TotalItems = videosResponse.Count(); ;
                listVideoModel.PaginationResponse.TotalPages = 1;
                listVideoModel.VideoModels.AddRange(_mapper.Map<List<Video>, List<VideoModel>>(videosResponse.ToList()));
            }
        }
        Response<ListVideoModel> response = new()
        {
            Status = result.Status,
            Message = result.Message,
            ObjectResponse = listVideoModel
        };

        return response;
    }

    public async Task<Response<VideoModel>> GetByIdVideo(Guid id)
    {
        var result = await _videoService.GetByIdVideo(id);
        Response<VideoModel> response = new()
        {
            Status = result.Status,
            Message = result.Message,
            ObjectResponse = result.ObjectResponse != null ?
                _mapper.Map<VideoModel>(result.ObjectResponse) : null
        };
        return response;
    }

    public async Task<Response<List<VideoModel>>> GetVideosRamdon()
    {
        var result = await _videoService.GetVideosRamdon();

        Response<List<VideoModel>> response = new()
        {
            Status = result.Status,
            Message = result.Message,
            ObjectResponse = result.ObjectResponse != null ?
                _mapper.Map<List<VideoModel>>(result.ObjectResponse) : null
        };
        return response;
    }

    public async Task<Response<long>> LikeDislikeVideo(LikeOrDislikeModel likeOrDislikeModel)
    {
        var result = await _videoService.LikeDislikeVideo(likeOrDislikeModel);
        Response<long> response = new()
        {
            Status = result.Status,
            Message = result.Message,
            ObjectResponse = result.ObjectResponse
        };
        return response;
    }
}
