using System;
using Models.Comments;
using Models.User;

namespace Services.CommentService.Implements
{
    public class CommentServiceRepository : ICommentServiceRepository
    {
        private readonly VideoTubeContext _context;

        public CommentServiceRepository(VideoTubeContext context)
        {
            _context = context;
        }

        public async Task<Response<object>> CreateComment(CommentRequestModel commentModel)
        {
            Response<Object> response = new();
            try
            {
                Comment comment = new()
                {
                    Id = Guid.NewGuid(),
                    VideoId = commentModel.VideoId,
                    UserId = commentModel.UserId,
                    Text = commentModel.Text,
                    PublishDate = DateTime.UtcNow
                };
                _context.Add(comment);
                _context.SaveChanges();
                response = new()
                {
                    Message = MessageExtension.AddMessageList("Datos insertados correctamente"),
                    ObjectResponse = comment,
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

        public async Task<Response<object>> GetCommentsVideo(Guid idVideo)
        {
            Response<Object> response = new();
            try
            {
                List<Comment> comment = await _context.Comments.Where(x => x.VideoId == idVideo)
                                                 .OrderBy(x => x.PublishDate)
                                                 .Include(x => x.Users)
                                                 .ToListAsync();

                response = new()
                {
                    Message = MessageExtension.AddMessageList("Consulta Exitosa"),
                    ObjectResponse = comment,
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
    }
}

