using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbhishekBlogs.Controllers
{
    public class SubscribedUserController : Controller
    {
        // GET: SubscribedUser
        public ActionResult Index()
        {
            return View();
        }

        // GET: SubscribedUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubscribedUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubscribedUser/Create
        [HttpPost]
        public ActionResult Create(string name, string email)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SubscribedUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SubscribedUser/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SubscribedUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubscribedUser/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
