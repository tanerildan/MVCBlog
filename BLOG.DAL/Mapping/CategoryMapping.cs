using BLOG.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.DAL.Mapping
{
   public class CategoryMapping:EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            HasKey<int>(x => x.Id);

            Property(x => x.Name).
                IsRequired().
                HasColumnType("nvarchar").
                IsUnicode().
                HasMaxLength(20);

            Property(x => x.Description).
                  IsUnicode().
                  HasColumnType("nvarchar").
                  IsOptional().
                  HasMaxLength(100);

            Property(x => x.PostCount).
                HasColumnType("int").
                IsRequired();
        }
    }
}
