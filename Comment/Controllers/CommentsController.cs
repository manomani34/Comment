using Comment.Models;
using Comment.Sevices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comment.Controllers
{
    [Route("api/users/{userId}/comments")]
    public class CommentsController : Controller
    {
        ICommentRepository _commentRepository;
        public CommentsController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public IActionResult GetComments(int userId)
        {
            if(!_commentRepository.IsUserExist(userId))
            {
                return NoContent();
            }

            var commentEntity = _commentRepository.GetCommnets(userId);
            var commentForAdd = new List<CommentDto>();
            foreach (var comment in commentEntity)
            {
                commentForAdd.Add(new CommentDto()
                {
                    Id = comment.Id,
                    Title = comment.Title,
                    Description = comment.Description
                });

            }

            return Ok(commentForAdd);
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int userId , int id)
        {
            if(!_commentRepository.IsUserExist(userId))
            {
                return NotFound();
            }

            var commentEntity = _commentRepository.GetComment(userId, id);

            if (commentEntity == null)
            {
                return NotFound();
            }
            var commentForAdd = new CommentDto()
            {
                Id = commentEntity.Id,
                Title = commentEntity.Title,
                Description = commentEntity.Description
            };

            return Ok(commentForAdd);
            
        }

    }
}
