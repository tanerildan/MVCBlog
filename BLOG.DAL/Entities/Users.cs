using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.DAL.Entities
{
  public  class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public Boolean IsDeleted { get; set; }
        public Boolean IsAccepted { get; set; }
        public string ProfilPic { get; set; }
        public string Code { get; set; }
        public int RoleId { get; set; }
       // public bool RememberMe { get; set; }

        public virtual Role Role { get; set;}
        public virtual ICollection<Post> UserPostes { get; set; }
        public virtual ICollection<Comments> SharedCommends { get; set; }
    }
}
