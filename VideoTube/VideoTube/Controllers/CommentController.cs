using Models.Comments;

namespace VideoTube.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentActions _commentActions;

    public CommentController(ICommentActions commentActions)
    {
        _commentActions = commentActions;
    }

    /// <summary>
    /// create Comment
    /// </summary>
    /// <returns>Response model CommentModel</returns>
    [HttpPost]
    [Route("[action]")]
    public async Task<Response<CommentModel>> CreateComment(CommentRequestModel commentModel)
    {
        Response<CommentModel> response = new();
        try
        {
            response = await _commentActions.CreateComment(commentModel);
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
    /// Get all Comments by video
    /// </summary>
    /// <returns>Response list model CommentModel</returns>
    [HttpGet]
    [Route("[action]")]
    public async Task<Response<List<CommentModel>>> GetCommentsVideo(Guid idVideo)
    {
        Response<List<CommentModel>> response = new();
        try
        {
            response = await _commentActions.GetCommentsVideo(idVideo);
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
