using Comment.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Comment.Sevices
{
    public interface ICommentRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(int userId , bool returnComment);
        IEnumerable<Commnet> GetCommnets(int commentId);
        Commnet GetComment(int userId, int commentId);
        bool IsUserExist(int userId);
    }
}
