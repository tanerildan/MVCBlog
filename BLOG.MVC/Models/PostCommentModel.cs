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
        public Post Gonderi { get; set; }
        public IEnumerable<Comments> Yorumlar { get; set; }
        public Users Kullanicilar { get; set; }
    }
}