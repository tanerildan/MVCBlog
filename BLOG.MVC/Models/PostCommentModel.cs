using BLOG.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLOG.MVC.Models
{
    public class PostCommentModel
    {
        public Post Posts { get; set; }
        public Comments Comment { get; set; }
    }
}