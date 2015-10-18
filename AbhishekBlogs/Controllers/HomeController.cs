using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AbhishekBlogsDataEntities;
using AbhishekBlogsBusinessLayer;
using AbhishekBlogs.Repository;
using PagedList;
using System.Web.Configuration;

namespace AbhishekBlogs.Controllers
{
    public class HomeController : BaseController
    {
        readonly IBlogRepository repo;
        private IBlogKeywordsRepository blogKeywordsrepo;
       
        public HomeController(IBlogRepository blogData)  
        {
            this.repo = blogData;
            blogKeywordsrepo = new BlogKeywordsRepository();
        }
        public ActionResult Bloglist(int? page,int id = 0,string typename="All")
        {
            var blogKeywords = blogKeywordsrepo.GetByBlogTitle("HomePage");
            ViewBag.MetaKeywords = blogKeywords.Page_Keywords;
            ViewBag.MetaDescription = blogKeywords.Page_Description;
            var blogList = repo.GetAll();
          
           if (id==0)
           {
               blogList=(blogList.Where(blog => blog.IsPublished == true));
           }
           else
           {
               TempData["typeId"] = id;
               TempData["typename"] = typename;
               blogList=(blogList.Where(b => b.Blog_type_Id == id && b.IsPublished == true).ToList());


           }
            if(page==0 || page==null)
            {
                page = 1;
            }
            int pageSize = Convert.ToInt32(WebConfigurationManager.AppSettings["HomePageBlogLength"].ToString());
           int pageNumber = (page ?? 1);
           return View(blogList.ToPagedList(pageNumber, pageSize));
            
        }

        public ActionResult About()
        {
            var blogKeywords = blogKeywordsrepo.GetByBlogTitle("AboutMe");
            ViewBag.MetaKeywords = blogKeywords.Page_Keywords;
            ViewBag.MetaDescription = blogKeywords.Page_Description;
            ViewBag.Message = "Who Am I?";

            return View();
        }

        public ActionResult Contact()
        {
            var blogKeywords = blogKeywordsrepo.GetByBlogTitle("Contact");
            ViewBag.MetaKeywords = blogKeywords.Page_Keywords;
            ViewBag.MetaDescription = blogKeywords.Page_Description;
            ViewBag.Message = "My contact details.";

            return View();
        }
        public ActionResult BlogView(int id = 0, string typename = "")
        {

            return RedirectToAction("BlogView", "Blogs", new { id = id, typename = typename });

        }
    }
}