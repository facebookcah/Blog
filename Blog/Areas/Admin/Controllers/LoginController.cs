using Blog.Areas.Admin.Views.Login;
using Blog.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private  BlogContext db=new BlogContext();
        private CategoryController category = new CategoryController();
        // GET: Admin/Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Account taikhoan)
        {
            if(!ModelState.IsValid)
            {
                return View(taikhoan);
            }    
            var account = db.TaiKhoans.ToList().Where(i => i.UserName.Equals(taikhoan.UserName) && i.PassWord.Equals(taikhoan.PassWord) && i.Type == true).FirstOrDefault();
            if(account==null)
            {
                ViewBag.ErrorMessage = "Tài khoản hoặc mật khẩu không đúng";
                return View(taikhoan);
            }
             return RedirectToAction("index", "Post");

            
        }

    }
}