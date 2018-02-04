using BLOG.BLL.Services.Abstracts;
using BLOG.BLL.Services.Concretes;
using BLOG.DAL.Context;
using BLOG.Repository.Abstracts;
using BLOG.Repository.Concretes;
using BLOG.Repository.UOW.Abstract;
using BLOG.Repository.UOW.Concrete;
using System;
using System.Data.Entity;
using Unity;

namespace BLOG.MVC
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<DbContext, ProjectContext>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<ICommentsRepository, CommentsRepository>();
            container.RegisterType<IPostRepository, PostRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IUsersRepository, UsersRepository>();
            container.RegisterType<IUnitofWork, UnitofWork>();
            container.RegisterType<IMessageService, MessageService>();
            container.RegisterType<IMediaUploadRepository, MediaUploadRepository>();
        }
    }
}