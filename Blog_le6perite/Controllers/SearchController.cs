using Blog_le6perite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var results = db.Posts.Select(p => p).Where(p => p.Title.Contains(searchedWord) || p.Author.FullName.Contains(searchedWord));
            ViewBag.SearchResults = null;
            if (results.Count() != 0)
            {
                ViewBag.SearchResults = results;
            }
            return View();
        }
    }
}