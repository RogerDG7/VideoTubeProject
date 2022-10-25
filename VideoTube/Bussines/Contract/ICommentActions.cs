using System;
using Common.Utilities.ResponseModels;
using Models.Comments;

namespace Bussines.Contract;

public interface ICommentActions
{
    Task<Response<CommentModel>> CreateComment(CommentRequestModel comment);
    Task<Response<List<CommentModel>>> GetCommentsVideo(Guid idVideo);
}
