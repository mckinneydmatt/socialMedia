using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class CommentCreate
    {
        public int CommentId { get; set; }
        public string Comment { get; set; }
        public int PostId { get; set; }

    }
}
