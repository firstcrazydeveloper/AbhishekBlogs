using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AbhishekBlogsDataEntities;
using AbhishekBlogsBusinessLayer;
using AbhishekBlogs.Repository;
using AbhishekBlogs.Helpers;
using AbhishekBlogs.EmailContent;
using PagedList;
using System.Web.Configuration;
using AbhishekBlogApplicationLog;

namespace AbhishekBlogs.Controllers
{
    public class BlogsController : BaseController
    {
        readonly IBlogRepository repo;
        private IBlogTypeRepository blogTyperepo = new BlogTypeRepository();
        public BlogsController(IBlogRepository blogData)  
        {
            this.repo = blogData;  
           
        }   
        // GET: Blogs
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "CreateDate" ? "date_desc" : "CreateDate";

            var blogList = repo.GetAll();
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                blogList = blogList.Where(r => r.Name.ToLower().Contains(searchString.ToLower()));
            }
            ViewBag.CurrentFilter = searchString;
            int pageSize = Convert.ToInt32(WebConfigurationManager.AppSettings["AdminPageBlogLength"].ToString());
            int pageNumber = (page ?? 1);
            
            switch (sortOrder)
            {
                case "name_desc":
                    blogList = blogList.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    blogList = blogList.OrderBy(s => s.CreateDate);
                    break;
                case "date_desc":
                    blogList = blogList.OrderByDescending(s => s.CreateDate);
                    break;
                default:
                    blogList = blogList.OrderByDescending(s => s.CreateDate);
                    break;
            }
            
            return View(blogList.ToPagedList(pageNumber, pageSize));
        }

        // GET: Blogs/Details/5
        public ActionResult Details(int id)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(repo.Get(id));
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            //ViewBag.BlogType = blogTyperepo.GetAll();
            var model = new BlogEntity();
            model.Blog_TypeList = blogTyperepo.GetAll();
            return View(model);
        }

        // POST: Blogs/Create
        [HttpPost]
        public ActionResult Create(BlogEntity blog)
        {
            try
            {
                if (!Request.IsAuthenticated)
                {
                    return RedirectToAction("Login", "Account");
                }
                // TODO: Add insert logic here
                blog.IsDeleted = false;
                blog.CreateDate = DateTime.Now;
                blog.UpdatedDate = DateTime.Now;
                blog.Blog_Id =Convert.ToString( Guid.NewGuid());
                var updateBlog=repo.Add(blog);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ApplicationLog.WriteTrace(ex);
                var model = new BlogEntity();
                model.Blog_TypeList = blogTyperepo.GetAll();
                return View(model);
            }
        }

        // GET: Blogs/Edit/5
        public ActionResult Edit(int id)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            BlogEntity blog = repo.Get(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            blog.Blog_TypeList = blogTyperepo.GetAll();
            return View(blog);
            
        }
        // GET: Blogs/Publish/5
        public ActionResult Publish(int id)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            try
            {
                var blog = repo.Publish(id);
                subscriptionEmailContent emailsend = new subscriptionEmailContent();
                emailsend.sendmail(blog);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ApplicationLog.WriteTrace(ex);
                return View();
            }
        }

        // POST: Blogs/Edit/5
        [HttpPost]
        public ActionResult Edit(BlogEntity blog)
        {
           
            try
            {
                
                if (!Request.IsAuthenticated)
                {
                    return RedirectToAction("Login", "Account");
                }
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {

                    blog.IsDeleted = blog.IsDeleted == null ? false : blog.IsDeleted;
                    blog.UpdatedDate =DateTime.Now ;
                    blog.Blog_type_Id = blog.Blog_type_Id == null ? 0 : blog.Blog_type_Id;
                    
                    repo.Update(blog);
                    return RedirectToAction("Index");
                }
                blog.Blog_TypeList = blogTyperepo.GetAll();
                return View(blog);
            }
            catch(Exception ex)
            {
                ApplicationLog.WriteTrace(ex);
                blog.Blog_TypeList = blogTyperepo.GetAll();
                return View(blog);
            }
        }

        // GET: Blogs/Delete/5
        public ActionResult Delete(int id)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            BlogEntity blog = repo.Get(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            blog.Blog_TypeList = blogTyperepo.GetAll();
            return View(blog);
        }

        // POST: Blogs/Delete/5
         [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (!Request.IsAuthenticated)
                {
                    return RedirectToAction("Login", "Account");
                }
                // TODO: Add delete logic here

                repo.Delete(id);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ApplicationLog.WriteTrace(ex);
                return View();
            }
        }
         public ActionResult BlogView(int id = 0, string typename = "")
         {
             BlogEntity blog = repo.Get(id);
             if (blog == null)
             {
                 return HttpNotFound();
             }
             if (blog.Page_Description != null && blog.Page_Description != "")
             {
                 ViewBag.MetaKeywords = blog.Page_Keywords;
                 ViewBag.MetaDescription = blog.Page_Description;
             }
             // Redirect to proper name
             if (typename != typename.ToSeoUrl())
             {
                 return RedirectToActionPermanent("BlogView", new { id = id, typename = typename.ToSeoUrl() });
             }

             return View(blog);
         }

         public ActionResult HomePage()
         {
             var id =Convert.ToInt32(TempData["typeId"]);
             var typename = Convert.ToString(TempData["typename"]);
             typename = typename == "" ? "All" : typename;
             return RedirectToAction("Bloglist", "Home", new {page=1, id = id, typename = typename });

         }
         public ActionResult Bloglist(int id = 0, string typename = "All")
         {
             return RedirectToAction("Bloglist", "Home", new {page=1, id = id, typename = typename });

         }

    }
}
