﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Blog_le6perite.Models;

namespace Blog_le6perite.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        //GET:POST
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Author).OrderByDescending(p=>p.Date).Take(3);
            return View(posts.ToList());
        }     
    }
}