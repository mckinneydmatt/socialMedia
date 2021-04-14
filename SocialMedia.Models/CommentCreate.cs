using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class CommentCreate
    {
        [Required]
        public int CommentId { get; set; }
        public string Comment { get; set; }
       public int PostId { get; set; }
    }
}
