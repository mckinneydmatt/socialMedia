using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
   public class Comment
    {
        [Key]

        public int CommentId { get; set; }

        [ForeignKey]

        public int PostId { get; set; }

        [Required,MaxLength(250)]
        public string Comments { get; set; }




    }
}
