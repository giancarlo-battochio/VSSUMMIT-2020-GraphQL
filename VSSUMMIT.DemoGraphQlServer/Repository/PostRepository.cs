using System.Collections.Generic;
using System.Linq;
using VSSUMMIT.Demo00.Repository;

namespace VSSUMMIT.Demo00
{
    public class PostRepository : Repository<Post>
    {
        public PostRepository(DemoContext context) : base(context) { }

        public List<Post> GetAll()
        {
            return Get().ToList();
        }

        public Post GetPostById(int id)
        {
            return Get().FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<Post> GetPostByUserId(int id)
        {
            return Get().Where(x => x.UserId.Equals(id)).ToList();
        }
    }
}
