using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
   public class CommentServices
    {
        //private readonly Guid _userId; <== Need to know what ID is used for new Users

        public CommentServices(Guid userId)
        {
           // _userId - userId; <= Also depends on what property is used for new users
        }

        public bool CreateComment(CommentCreate model)//<== How is the model(Or what is used in the other classes
        {
            var entity = new CommentServices()
            {
                CommentId = model.CommentId,
                Comments = model.Comments
            }
        }
    }
}
