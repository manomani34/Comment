using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comment.Entities
{
    public class CommentContext : DbContext
    {
        public CommentContext(DbContextOptions<CommentContext> options) : base (options)
        {
            Database.Migrate();
        }

        public DbSet<Commnet> commnets { get; set; }
        public DbSet<User>  users { get; set; }
    }
}
