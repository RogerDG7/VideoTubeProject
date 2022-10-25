using System;
namespace Entities.Entities
{
    public class Comment
    {
#nullable disable
        public Guid Id { get; set; }
        public Guid VideoId { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }

        //Foreign
        public virtual User Users { get; set; }
        public virtual Video Videos { get; set; }
    }
}
