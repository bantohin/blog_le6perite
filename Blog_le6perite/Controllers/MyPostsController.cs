using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog_le6perite.Models;
using Blog_le6perite.Extensions;

namespace Blog_le6perite.Controllers
{
    public class MyPostsController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        // GET: MyPosts
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Author).Where(p => p.Author.UserName == User.Identity.Name);
            ViewBag.MyPosts = null;
            if (posts.Count() != 0)
            {
                ViewBag.MyPosts = posts;
            }
            return View();
        }

        // GET: MyPosts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MyPosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyPosts/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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

        // GET: MyPosts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MyPosts/Edit/5
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

        // GET: MyPosts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MyPosts/Delete/5
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
