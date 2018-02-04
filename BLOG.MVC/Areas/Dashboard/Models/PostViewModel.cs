using BLOG.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLOG.MVC.Areas.Dashboard.Models
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public HttpPostedFileBase PostedPicture { get; set; }
    }
}