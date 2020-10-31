using System.ComponentModel.DataAnnotations;

namespace VSSUMMIT.Demo00
{
    public class Follower
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int FollowUserId { get; set; }
    }
}
