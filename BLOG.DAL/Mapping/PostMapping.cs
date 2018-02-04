using BLOG.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.DAL.Mapping
{
    public class PostMapping : EntityTypeConfiguration<Post>
    {
        public PostMapping()
        {
            HasKey<int>(x => x.Id);

            Property(x => x.Title).
                IsRequired().
                IsUnicode().
                HasColumnType("nvarchar").
                HasMaxLength(100);

            Property(x => x.Tag).
                IsOptional().
                HasColumnType("nvarchar").
                HasMaxLength(20);

            Property(x => x.PostDate).
                IsRequired().
                HasColumnType("date");

            Property(x => x.Description).
                HasColumnType("nvarchar").
                IsOptional();

            Property(x => x.UserId).
                HasColumnType("int").
                IsOptional();

            Property(x => x.CategoryId).
                IsRequired().
                HasColumnType("int");

            Property(x => x.Summary).
                HasColumnType("nvarchar").
                HasMaxLength(200).
                IsOptional();

            Property(x => x.IsDeleted).
                HasColumnType("bit").
                IsOptional();

            Property(x => x.LikeCount).
                HasColumnType("int").
                IsOptional();
            Property(x => x.DislikeCount).
                HasColumnType("int").
                IsOptional();
            Property(x => x.PostPic).
                IsOptional().
                HasColumnType("nvarchar(max)");
            
        }
    }
}
