using System;
using System.Collections.Generic;
using System.Linq;
using VSSUMMIT.Demo00.Repository;

namespace VSSUMMIT.Demo00
{
    public class FollowerRepository : Repository<Follower>
    {
        public FollowerRepository(DemoContext context) : base(context) { }

        public List<Follower> GetAll()
        {
            return Get().ToList();
        }

        public List<Follower> GetPostByFollowedUserId(int id)
        {
            return Get().Where(x => x.FollowUserId.Equals(id)).ToList();
        }
    }
}
