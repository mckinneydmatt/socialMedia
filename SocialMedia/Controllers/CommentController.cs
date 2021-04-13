using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SocialMedia.Controllers
{
    public class CommentController : ApiController
    {

        private readonly SocialMediaDbContext _context = new SocialMediaDbContext();

        public async Task<IHttpActionResult> CreateComment([FromBody]CommentController model)
        {
            if (model is null)
                return BadRequest("Your comment cannot be empty,");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var PostEntity = await _context.Post.FindAsync(model.PostId);
            if (PostEntity is null)
                return BadRequest($"The target post with the ID of {model.PostId} does not exist.");


            postEntity.Comments.Add(model);
            if (await _context.SaveChangesAsync() == 1)
                return Ok($"You commented on post {restaurantEntity.Name} successfully!");

            return InternalServerError();




            //CommentService commentService = CreateCommentService();
            //var comment = commentService.GetCategory();
            //return Ok(comment)
        }

    }
}