using System;
namespace Models.Video
{
    public class FiltersVideoModel
    {
        public string NameVideoOrArtist { get; set; } = string.Empty;
        public Pagination Pagination { get; set; } = new();
    }
}
