using BLOG.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.DAL.Mapping
{
   public class RoleMapping:EntityTypeConfiguration<Role>
    {
        public RoleMapping()
        {
            HasKey<int>(x => x.Id);

            Property(x => x.RoleName).
                IsRequired().
                HasColumnType("nvarchar").
                HasMaxLength(10).
                IsUnicode();
        }
    }
}
