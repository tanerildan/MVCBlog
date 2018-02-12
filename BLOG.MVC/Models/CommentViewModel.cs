using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLOG.MVC.Models
{
    public class CommentViewModel
    {
        public string CommentBody { get; set; }
        public int UserId { get; set; }
        public string CommentDate { get; set; }
        public int PostId { get; set; }
    }
}