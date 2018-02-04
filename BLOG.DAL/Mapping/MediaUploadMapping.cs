using BLOG.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.DAL.Mapping
{
   public class MediaUploadMapping:EntityTypeConfiguration<MediaUpload>
    {
        public MediaUploadMapping()
        {
            HasKey<int>(x => x.Id);
            Property(x => x.Name).
                HasColumnType("nvarchar").
                HasMaxLength(30).
                IsRequired();
            Property(x => x.Path).
                IsUnicode();
        }
    }
}
