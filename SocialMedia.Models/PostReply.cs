using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class PostReply
    {
        public int CommentId { get; set; }
        public string Reply { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
