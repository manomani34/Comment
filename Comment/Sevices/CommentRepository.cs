using Comment.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comment.Sevices
{
    public class CommentRepository : ICommentRepository
    {
        CommentContext _ctx;
        public CommentRepository(CommentContext ctx)
        {
            _ctx = ctx;
        }
        public Commnet GetComment(int userId, int commentId)
        {
            return _ctx.commnets.FirstOrDefault(c => c.UserId == userId && c.Id == commentId);
        }
        
        public IEnumerable<Commnet> GetCommnets(int UserId)
        {
            return _ctx.commnets.Where(t => t.UserId == UserId);
        }

        public User GetUser(int userId , bool returnComment)
        {
            if(returnComment)
            {
                return _ctx.users.Include(u => u.Commnets).FirstOrDefault(u => u.Id == userId);
            }
            return _ctx.users.FirstOrDefault(u => u.Id == userId);
        }

        public IEnumerable<User> GetUsers()
        {
           return  _ctx.users.ToList();
        }

        public bool IsUserExist(int userId)
        {
            return _ctx.users.Any(u => u.Id == userId);
        }
    }
}
