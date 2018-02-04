using BLOG.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.DAL.Mapping
{
   public class CommentMapping:EntityTypeConfiguration<Comments>
    {
        public CommentMapping()
        {
            HasKey<int>(x => x.Id);

            Property(x => x.PostCommend).
               IsUnicode().
               HasColumnType("nvarchar").
               IsOptional();

            Property(x => x.CommendDate).
                IsRequired().
                HasColumnType("date");

            Property(x => x.UserId).
                IsRequired().
                HasColumnType("int");

            Property(x => x.PostId).
                IsRequired().
                HasColumnType("int");

            Property(x => x.IsDeleted).
                IsOptional().
                IsRequired().
                HasColumnType("bit");

            Property(x => x.LikeCount).
                IsOptional().
                HasColumnType("int");

            Property(x => x.DislikeCount).
                IsOptional().
                HasColumnType("int");
               
        }
    }
}
