using Blog_le6perite.Models;
using System;
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
    public class SearchController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Search
        public ActionResult Index()
        {
            var searchedWord = "";
            searchedWord = Request.Form["searchEngine"];
            var results = db.Posts.Include(p => p.Author).Select(p => p).Where(p => p.Title.Contains(searchedWord) || p.Author.FullName.Contains(searchedWord));
            ViewBag.SearchResults = null;
            if (results.Count() != 0)
            {
                ViewBag.SearchResults = results;
            }
            return View();
        }
    }
}