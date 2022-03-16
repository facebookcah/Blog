using Blog.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        private BlogContext db = new BlogContext();
        private PostController postCL = new PostController();
        [HttpPost]
        public ActionResult Post(int? PostId, string content, string email)
        {
            var post = db.Posts.ToList().Where(i => i.Id == PostId).FirstOrDefault();
            var list = db.Posts.ToList().Where(i => i.Id != PostId).Take(3).ToList();
            ViewBag.list = list;
            if (content != null)
            {
                Comment comment = new Comment();
                comment.CommentText = content;
                comment.PostId = PostId;
                comment.CreatedOn = DateTime.Now;
                comment.UpdatedOn = DateTime.Now;
                comment.Status = 0;
                comment.DateTime = DateTime.Now;

                db.Comments.Add(comment);
                if (email != null)
                {
                    comment.Email = email;
                }
                db.SaveChanges();
                db.Entry(post).State = EntityState.Modified;
                post.RateCount += 1;
                db.SaveChanges();


            }
            return View(post);
        }
    }
}