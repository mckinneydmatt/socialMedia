using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    
    
        public class CommentServices
        {

            private readonly Guid _userId;

            public CommentServices(Guid userId)
            {
                _userId = userId;
            }


            public bool CreateComment(CommentCreate model)
            {
                var entity =
                    new Comments()
                    {

                        CommentId = model.CommentId,
                        Comment = model.Comment,
                        PostId = model.PostId,
                    };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Comments.Add(entity);
                    return ctx.SaveChanges() == 1;
                }

            }
            public IEnumerable<CommentListItem> GetComment()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx

                           .Comments
                            .Where(e => e.CommentId == e.CommentId)
                            .Select(
                                e =>
                                    new CommentListItem
                                    {

                                        CommentId = e.CommentId,
                                        Comment = e.Comment,

                                    }
                            );

                    return query.ToArray();
                }
            }

            public CommentDetail GetCommentById(int commentId)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx

                            .Comments
                            .Single
                            (e => e.CommentId == commentId);

                    return
                        new CommentDetail
                        {

                            CommentId = entity.CommentId,
                            Comment = entity.Comment

                        };
                }
            }

            public bool UpdateComments(CommentEdit model)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                           .Comments
                            .Single(e => e.CommentId == model.CommentId);

                    entity.CommentId = model.CommentId;
                    entity.Comment = model.Comment;


                    return ctx.SaveChanges() == 1;
                }
            }

            public bool DeleteComment(int commentId)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Comments
                            .Single(e => e.CommentId == commentId);

                    ctx.Comments.Remove(entity);

                    return ctx.SaveChanges() == 1;

                }


            }

        }
    
}
