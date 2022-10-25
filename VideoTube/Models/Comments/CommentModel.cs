using Models.User;

namespace Models.Comments;

public class CommentModel
{
    public Guid Id { get; set; }
    public Guid VideoId { get; set; }
    public Guid UserId { get; set; }
    public string? Text { get; set; }
    public DateTime PublishDate { get; set; }

    public UserModel? Users { get; set; }
}
