using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.DAL.Entities
{
  public  class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Tag { get; set; }
        public DateTime PostDate { get; set; }
        public string PostPic { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Summary { get; set; }
        
        public Boolean IsDeleted { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }

        public virtual Users User { get; set; }
        public virtual Category SharedCategory { get; set; }
        public virtual ICollection<Comments> SharedComments { get; set; }
    }
}
