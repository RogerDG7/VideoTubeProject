using System;
using Models.Comments;
using Models.User;

namespace Services.CommentService
{
    public interface ICommentServiceRepository
    {
        Task<Response<object>> CreateComment(CommentRequestModel commentModel);
        Task<Response<object>> GetCommentsVideo(Guid idVideo);
    }
}
