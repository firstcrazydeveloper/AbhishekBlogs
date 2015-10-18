using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using AbhishekBlogs.Repository;
using Microsoft.AspNet.Identity;
using AbhishekBlogs.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using AbhishekBlogs.Controllers;
namespace AbhishekBlogs.Helpers
{
    public class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here  
            //This is the important line to edit  
            container.RegisterType<IBlogRepository, BlogRepository>();
            container.RegisterType<IBlogTypeRepository, BlogTypeRepository>();
            container.RegisterType<ISubscribedRepository, SubscribedRepository>();
            container.RegisterType(typeof(UserManager<>),
            new InjectionConstructor(typeof(IUserStore<>)));
            container.RegisterType<Microsoft.AspNet.Identity.IUser>(new InjectionFactory(c => c.Resolve<Microsoft.AspNet.Identity.IUser>()));
            container.RegisterType(typeof(IUserStore<>), typeof(UserStore<>));
            container.RegisterType<IdentityUser, ApplicationUser>(new ContainerControlledLifetimeManager());
            container.RegisterType<DbContext, ApplicationDbContext>(new ContainerControlledLifetimeManager());

            container.RegisterType<DbContext, ApplicationDbContext>(
    new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<ApplicationUser>>(
                new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(
                new HierarchicalLifetimeManager());

            container.RegisterType<AccountController>(
                new InjectionConstructor());
            RegisterTypes(container);
            return container;
        }
        public static void RegisterTypes(IUnityContainer container)
        {

        }   
    }
}