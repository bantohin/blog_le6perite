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
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comments/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment.AuthorId!=null)
            {
                if (comment == null || (comment.Author.UserName != User.Identity.Name && !User.IsInRole("Administrators")))
                {
                    this.AddNotification("You don't have permission to delete this comment", NotificationType.ERROR);
                    return RedirectToAction($"../Posts/Details/{comment.PostId}");
                }
            }
            else
            {
                if (comment == null || !User.IsInRole("Administrators"))
                {
                    this.AddNotification("You don't have permission to delete this comment", NotificationType.ERROR);
                    return RedirectToAction($"../Posts/Details/{comment.PostId}");
                }
            }
            
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            var postId = comment.PostId;
            db.Comments.Remove(comment);
            db.SaveChanges();
            this.AddNotification("Comment deleted", NotificationType.SUCCESS);
            return RedirectToAction($"../Posts/Details/{postId}");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
