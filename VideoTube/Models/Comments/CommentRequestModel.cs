namespace Models.Comments;

public class CommentRequestModel
{
    [Required]
    public Guid VideoId { get; set; }
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public string? Text { get; set; }
}

