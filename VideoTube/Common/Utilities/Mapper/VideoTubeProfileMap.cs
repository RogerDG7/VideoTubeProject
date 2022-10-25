using System;
using AutoMapper;
using Entities.Entities;
using Models.Comments;
using Models.User;
using Models.Video;

namespace Common.Utilities.Mapper;

public class VideoTubeProfileMap : Profile
{
    public VideoTubeProfileMap()
    {
        CreateMap<User, UserModel>().ReverseMap();
        CreateMap<Comment, CommentModel>().ReverseMap();
        CreateMap<Video, VideoModel>().ReverseMap();
    }
}
