using Microsoft.AspNet.Identity;
using SocialMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialMedia.Controllers
{
    [Authorize]
    public class CommentsController : ApiController
    {
        //private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // Create new comments
        // POST api/Comment
        // [HttpPost]
        public IHttpActionResult Get()
        {
            CommentServices commentServices = CreateCommentService();
            var comment = commentServices.GetComment();
            return Ok(comment);
        }
        public IHttpActionResult Get(int commentId)
        {
            CommentServices commentServices = CreateCommentService();
            var comment = commentServices.GetCommentById(commentId);
            return Ok(comment);
        }
        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCommentService();
            if (!service.CreateComment(comment))
                return InternalServerError();
            return Ok();
        }
        private CommentServices CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentServices(userId);
            return commentService;
        }
        public IHttpActionResult Put(CommentEdit comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCommentService();
            if (!service.UpdateComments(comment))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int commentId)
        {
            var service = CreateCommentService();
            if (!service.DeleteComment(commentId))
                return InternalServerError();
            return Ok();
        }
    }
}
    //    {
    //        // Check if model is null
    //        if (model is null)
    //            return BadRequest("Your request body cannot be empty.");
    //        // Check if ModelState is Invalid
    //        if (!ModelState.IsValid)
    //            return BadRequest(ModelState);
    //        // Find the Post by the model.PostID and see that it exists
    //        var PostEntity = await context.Post.FindAsync(model.PostId);
    //        if (PostEntity is null)
    //            return BadRequest($"The target post with the ID of {model.PostId} does not exist.");
    //    }
    //}
