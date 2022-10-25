using System;
using Microsoft.EntityFrameworkCore;
using Models.User;
using Models.Video;
using Services.VideoService.Contracts;

namespace Services.VideoService.Implements;

public class VideoServiceRepository : IVideoServiceRepository
{
    private readonly VideoTubeContext _context;

    public VideoServiceRepository(VideoTubeContext context)
    {
        _context = context;
    }

    public async Task<Response<object>> CreateVideo(VideoRequestModel videoRequest)
    {
        Response<Object> response = new();
        try
        {
            Video video = new()
            {
                Id = Guid.NewGuid(),
                Title = videoRequest.Title,
                Description = videoRequest.Description,
                Likes = 0,
                Dislikes = 0,
                ThumbnailUrl = videoRequest.ThumbnailUrl,
                UloapDate = DateTime.UtcNow,
                UserID = videoRequest.UserID,
                Url = videoRequest.Url
            };
            _context.Add(video);
            _context.SaveChanges();
            response = new()
            {
                Message = MessageExtension.AddMessageList("Datos insertados correctamente"),
                ObjectResponse = video,
                Status = true
            };

            return await Task.FromResult(response);
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.ObjectResponse = null;
            response.Message = MessageExtension.AddMessageList(ex.Message);
            return response;
        }
    }

    public async Task<Response<List<Video>>> GetAllVideosFilter(FiltersVideoModel filters)
    {
        Response<List<Video>> response = new();
        try
        {
            List<Video> lstVideos = await _context.videos.Where(x => x.Title.ToUpper().Contains(filters.NameVideoOrArtist.ToUpper())
                                                                || x.Users.Name.ToUpper().Contains(filters.NameVideoOrArtist.ToUpper()))
                                                         .Include(x => x.Users)
                                                         .OrderBy(x => x.Title)
                                                         .ToListAsync();
            response = new()
            {
                Message = MessageExtension.AddMessageList("Consulta Exitosa"),
                ObjectResponse = lstVideos,
                Status = true
            };

            return await Task.FromResult(response);
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.ObjectResponse = null;
            response.Message = MessageExtension.AddMessageList(ex.Message);
            return response;
        }
    }

    public async Task<Response<object>> GetByIdVideo(Guid id)
    {
        Response<Object> response = new();
        try
        {
            Video? video = await _context.videos.Where(x => x.Id == id)
                                              .Include(x => x.Users)
                                              .FirstOrDefaultAsync();

            if (video == null)
                throw new Exception("El video no existe o no es valido");

            response = new()
            {
                Message = MessageExtension.AddMessageList("Consulta Exitosa"),
                ObjectResponse = video,
                Status = true
            };

            return await Task.FromResult(response);
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.ObjectResponse = null;
            response.Message = MessageExtension.AddMessageList(ex.Message);
            return response;
        }
    }

    public async Task<Response<List<Video>>> GetVideosRamdon()
    {
        Response<List<Video>> response = new();
        try
        {
            List<Video> lstVideos = await _context.videos.Include(x => x.Users)
                                                         .ToListAsync();
            response = new()
            {
                Message = MessageExtension.AddMessageList("Consulta Exitosa"),
                ObjectResponse = lstVideos,
                Status = true
            };

            return await Task.FromResult(response);
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.ObjectResponse = null;
            response.Message = MessageExtension.AddMessageList(ex.Message);
            return response;
        }
    }

    public async Task<Response<long>> LikeDislikeVideo(LikeOrDislikeModel likeOrDislikeModel)
    {
        Response<long> response = new();
        try
        {
            Video? video = await _context.videos.Where(x => x.Id == likeOrDislikeModel.VideoId)
                                              .FirstOrDefaultAsync();

            if (video == null)
                throw new Exception("El video no existe o no es valido");

            if (likeOrDislikeModel.IsLike)
            {
                video.Likes += 1;
            }
            else
            {
                video.Dislikes += 1;
            }
            _context.Update(video);
            _context.SaveChanges();

            response = new()
            {
                Message = MessageExtension.AddMessageList("Consulta Exitosa"),
                ObjectResponse = likeOrDislikeModel.IsLike ? video.Likes : video.Dislikes,
                Status = true
            };

            return await Task.FromResult(response);
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.ObjectResponse = 0;
            response.Message = MessageExtension.AddMessageList(ex.Message);
            return response;
        }
    }
}

