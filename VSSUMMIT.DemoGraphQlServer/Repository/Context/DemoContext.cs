using Microsoft.EntityFrameworkCore;
using System;

namespace VSSUMMIT.Demo00.Repository
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Follower> Followers { get; set; }
    }
}
