﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.DAL.Entities
{
   public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PostCount { get; set; }
        public virtual  ICollection<Post> SharedPosts { get; set; }
    }
}
