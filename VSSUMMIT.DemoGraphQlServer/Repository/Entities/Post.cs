using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VSSUMMIT.Demo00
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
    }
}
