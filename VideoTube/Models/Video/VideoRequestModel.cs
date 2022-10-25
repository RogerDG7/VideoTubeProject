namespace Models.Video;

public class VideoRequestModel
{
    [Required]
    public string? Title { get; set; }
    public string Description { get; set; } = String.Empty;
    public string ThumbnailUrl { get; set; } = String.Empty;
    [Required]
    public Guid UserID { get; set; }
    [Required]
    public string? Url { get; set; }
}

