using Microsoft.AspNet.Identity;
using SocialMedia.Models;
using SocialMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SocialMedia.Controllers
{
    [System.Web.Http.Authorize]
    public class PostController : ApiController
    {
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new PostService(userId);
            return noteService;
        }
        public IHttpActionResult Get()
        {
            PostService postService = CreatePostService();
            var posts = postService.GetNotes();
            return Ok(posts);
        }
        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.CreatePost(post))
                return InternalServerError();

            return Ok();
        }
        // GET: Post
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}