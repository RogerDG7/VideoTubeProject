using System;
using AutoMapper;
using Bussines.Contract;
using Common.Utilities.ResponseModels;
using Entities.Entities;
using Models.Comments;
using Models.User;
using Services.CommentService;

namespace Bussines.Implement;

public class CommentActions : ICommentActions
{
    private readonly ICommentServiceRepository _commentService;
    private readonly IMapper _mapper;

    public CommentActions(ICommentServiceRepository commentService, IMapper mapper)
    {
        _commentService = commentService;
        _mapper = mapper;
    }

    public async Task<Response<CommentModel>> CreateComment(CommentRequestModel comment)
    {
        var result = await _commentService.CreateComment(comment);
        Response<CommentModel> response = new()
        {
            Status = result.Status,
            Message = result.Message,
            ObjectResponse = result.ObjectResponse != null ?
                _mapper.Map<CommentModel>(result.ObjectResponse) : null
        };
        return response;
    }

    public async Task<Response<List<CommentModel>>> GetCommentsVideo(Guid idVideo)
    {
        var result = await _commentService.GetCommentsVideo(idVideo);
        Response<List<CommentModel>> response = new()
        {
            Status = result.Status,
            Message = result.Message,
            ObjectResponse = result.ObjectResponse != null ?
                _mapper.Map<List<CommentModel>>(result.ObjectResponse) : null
        };
        return response;
    }
}
