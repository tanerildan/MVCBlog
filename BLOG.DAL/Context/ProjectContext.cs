using BLOG.DAL.Entities;
using BLOG.DAL.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.DAL.Context
{
   public  class ProjectContext:DbContext
    {
        public ProjectContext():base("name=dbConn")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProjectContext>());
        }
        public DbSet<Category> Kategoriler { get; set; }
        public DbSet<Comments> Yorumlar { get; set; }
        public DbSet<Post> Gonderiler { get; set; }
        public DbSet<Role> Roller { get; set; }
        public DbSet<Users> Kullaniciler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMapping());
            modelBuilder.Configurations.Add(new CommentMapping());
            modelBuilder.Configurations.Add(new RoleMapping());
            modelBuilder.Configurations.Add(new PostMapping());
            modelBuilder.Configurations.Add(new UsersMapping());

            modelBuilder.Conventions.Add(new PluralizingTableNameConvention());
        }
    }

}
