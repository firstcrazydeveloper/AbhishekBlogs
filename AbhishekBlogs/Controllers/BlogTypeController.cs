using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AbhishekBlogsDataEntities;
using AbhishekBlogsBusinessLayer;
using AbhishekBlogs.Repository;
using AbhishekBlogs.Helpers;

namespace AbhishekBlogs.Controllers
{
    public class BlogTypeController : BaseController
    {
        readonly IBlogTypeRepository repo;
        public BlogTypeController(IBlogTypeRepository blogData)  
        {
           
            this.repo = blogData;  
        }  
        // GET: BlogType
        public ActionResult Index()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login","Account");
            }
            return View(repo.GetAll());
        }

        // GET: BlogType/Details/5
        public ActionResult Details(int id)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(repo.Get(id));
        }

        // GET: BlogType/Create
        public ActionResult Create()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        // POST: BlogType/Create
        [HttpPost]
        public ActionResult Create(Blog_TypeEntity blogType)
        {
            try
            {
                if (!Request.IsAuthenticated)
                {
                    return RedirectToAction("Login", "Account");
                }
                // TODO: Add insert logic here
                repo.Add(blogType);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogType/Edit/5
        public ActionResult Edit(int id)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            Blog_TypeEntity blog = repo.Get(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: BlogType/Edit/5
        [HttpPost]
        public ActionResult Edit(Blog_TypeEntity blog)
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
                    repo.Update(blog);
                    return RedirectToAction("Index");
                }
                return View(blog);
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogType/Delete/5
        public ActionResult Delete(int id)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            Blog_TypeEntity blog = repo.Get(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: BlogType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
            catch
            {
                return View();
            }
        }
        public ActionResult Bloglist(int id = 0, string typename = "All")
        {
            return RedirectToAction("Bloglist", "Home", new { id = id, typename = typename });

        }
    }
}
