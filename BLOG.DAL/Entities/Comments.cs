using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.DAL.Entities
{
   public class Comments
    {
        public int Id { get; set; }
        public string PostCommend { get; set; }
        public DateTime CommendDate { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public Boolean IsDeleted { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }

        public virtual Users UserComment { get; set; }
        public virtual Post PostComment { get; set; }
    }
}
