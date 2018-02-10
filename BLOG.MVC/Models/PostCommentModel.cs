using BLOG.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLOG.MVC.Models
{
    public class PostCommentModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Comments> Comment { get; set; }
    }
}