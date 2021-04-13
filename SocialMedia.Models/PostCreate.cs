using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class PostCreate
    {
        [Required]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "There are too many characters in this field.")]
        public string Text { get; set; }

    }
}
