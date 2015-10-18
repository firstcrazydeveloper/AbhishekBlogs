using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AbhishekBlogsBusinessLayer;
using AbhishekBlogs.Repository;

namespace AbhishekBlogs.Controllers
{
    public class BaseController : Controller
    {
        private IBlogTypeRepository blogTyperepo = new BlogTypeRepository();
        private IBlogKeywordsRepository blogKeywordsrepo = new BlogKeywordsRepository();
        readonly IBlogRepository repo = new BlogRepository();
        // GET: Base
        public BaseController()  
        {
           
            var blogtypeList = blogTyperepo.GetBlogTypeResult().OrderByDescending(btype => btype.Total);
            var bloglist = repo.GetAll().Where(blog => blog.IsPublished == true).OrderByDescending(r => r.CreateDate).Take(20);
            var blogtrend = bloglist.Take(5);
            //string metakeyword = "Abhishek Kumar,first crazy developer,firstcrazydeveloper, Javascript, Angularjs, coding, C# Tutorials, JavaScript, AngularJs, MVC, WebApi, WCF, ASP.Net, OOPS, SQL Server, MySQL, DesignPatterns";
            //string metadescrption = "Abhishek Kumar,first crazy developer";
            //foreach (var blogtype in blogtypeList)
            //{
            //    metakeyword = metakeyword + "," + blogtype.Name;
            //}
            //foreach (var blog in bloglist)
            //{
            //    metadescrption = metadescrption + "," + blog.Name.Replace("-"," ");
            //}
           
            ViewBag.blogtype = blogtypeList;
            ViewBag.blog = blogtrend;
            
        }
    }
}