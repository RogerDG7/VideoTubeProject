namespace Models.User;

public class UserModel
{
    public Guid Id { get; set; }
    [Required]
    public String Name { get; set; } = String.Empty;
    [Required]
    public String UrlPicture { get; set; } = String.Empty;
}
