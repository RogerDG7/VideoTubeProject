using System;
namespace Entities.Entities
{
    public class User
    {
#nullable disable
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String UrlPicture { get; set; }

        //Foreign
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Video> Videos{ get; set; }
    }
}
