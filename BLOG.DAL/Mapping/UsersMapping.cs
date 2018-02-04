using BLOG.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.DAL.Mapping
{
  public  class UsersMapping:EntityTypeConfiguration<Users>
    {
        public UsersMapping()
        {
            HasKey<int>(x => x.Id);

            Property(x => x.Name).
                IsRequired().
                HasColumnType("nvarchar").
                HasMaxLength(50);

            Property(x => x.LastName).
                IsRequired().
                HasColumnType("nvarchar").
                HasMaxLength(50);

            Property(x => x.Email).
                IsRequired().
                IsUnicode().
                HasColumnType("nvarchar").
                HasMaxLength(50);

            Property(x => x.Password).
                IsUnicode().
                IsRequired().
                HasColumnType("nvarchar").
                HasMaxLength(12);

            Property(x => x.PasswordConfirm).
               IsUnicode().
               IsRequired().
               HasColumnType("nvarchar").
               HasMaxLength(12);

            Property(x => x.IsDeleted).
                IsRequired().
                HasColumnType("bit");

            Property(x => x.IsAccepted).
                IsRequired().
                HasColumnType("bit");

            Property(x => x.ProfilPic).
                IsOptional().
                HasColumnType("nvarchar");

            Property(x => x.Code).
                IsOptional().
                IsUnicode().
                HasColumnType("nvarchar");

            Property(x => x.RoleId).
                IsRequired().
                HasColumnType("int");

          //  Property(x => x.RememberMe).
              //  IsOptional().
             //   HasColumnType("bit");

        }
    }
}
