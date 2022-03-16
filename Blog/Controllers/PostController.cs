using Blog.Domains;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Blog.Controllers
{

    public class PostController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: Post
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }
        public ActionResult Detail(int? id)
        {
            var post = db.Posts.ToList().Where(i => i.Id == id).FirstOrDefault();
            db.Entry(post).State = EntityState.Modified;
            post.ViewCount += 1;
            db.SaveChanges();
            var list = db.Posts.ToList().Where(i => i.Id != id).Take(3).ToList();
            ViewBag.list = list;
            return View(post);
        }

        public ActionResult MostView()
        {
            var mostViewList = db.Posts.OrderByDescending(i => i.ViewCount).ToList().Take(5);
            return View("Index", mostViewList);
        }

        public ActionResult Newest()
        {
            var mostViewList = db.Posts.OrderByDescending(i => i.CreatedOn).ToList().Take(5);
            return View("Index", mostViewList);
        }
    }
}