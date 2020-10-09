using Comment.Entities;
using Comment.Models;
using Comment.Sevices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comment.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        ICommentRepository _commentRepository;
        public UsersController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var usersEntity = _commentRepository.GetUsers();
            var usersToAdd = new List<UserDto>();

            foreach (var user in usersEntity)
            {
                var commEntity = _commentRepository.GetCommnets(user.Id);
                var commToAdd = new List<CommentDto>();
                foreach (var comment in commEntity)
                {
                    commToAdd.Add(new CommentDto()
                    {
                        Id = comment.Id,
                        Title = comment.Title,
                        Description = comment.Description
                    });
                }
                usersToAdd.Add(new UserDto()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Commnets = commToAdd
                });
            }
            return Ok(usersToAdd);

        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int Id, bool returnComment = false)
        {
            var userEntity = _commentRepository.GetUser(Id, returnComment);
            if (userEntity == null)
            {
                return NotFound();
            }

            if (returnComment)
            {
                var userToAdd = new UserDto()
                {
                    Id = userEntity.Id,
                    FirstName = userEntity.FirstName,
                    LastName = userEntity.LastName,
                    Email = userEntity.Email
                };
                foreach(var comm in userEntity.Commnets)
                {
                    userToAdd.Commnets.Add(new CommentDto()
                    {
                        Id = comm.Id,
                        Title = comm.Title,
                        Description = comm.Description
                    });
                }
                return Ok(userToAdd);
            }
            var userNoComment = new UserNoCommDto()
            {
                Id = userEntity.Id,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                Email = userEntity.Email
            };
            return Ok(userNoComment);
        }
    }
}
