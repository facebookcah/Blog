using Blog.Areas.Admin.Views.Login;
using Blog.Domains;
using Blog.Views.LoginClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class LoginClientController : Controller
    {
        private BlogContext db = new BlogContext();
        // GET: LoginClient
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Account taikhoan)
        {
            if (!ModelState.IsValid)
            {
                return View(taikhoan);
            }
            var account = db.TaiKhoans.ToList().Where(i => i.UserName.Equals(taikhoan.UserName) && i.PassWord.Equals(taikhoan.PassWord) && i.Type == false).FirstOrDefault();
            if (account == null)
            {
                ViewBag.ErrorMessage = "Tài khoản hoặc mật khẩu không đúng";
                return View(taikhoan);
            }
            Session["username"] = account.UserName;
            return RedirectToAction("index", "Post");


        }
        public ActionResult Logout()
        {
            return RedirectToAction("Index","Post");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register register)
        {
            if(ModelState.IsValid)
            {
                TaiKhoan taiKhoan = new TaiKhoan();
                taiKhoan.UserName = register.UserName;
                taiKhoan.Email = register.Email;
                taiKhoan.PassWord = register.Password;
                taiKhoan.CreatedOn = DateTime.Now;
                taiKhoan.UpdatedOn = DateTime.Now;
                taiKhoan.Status = true;
                taiKhoan.Type = false;
                db.TaiKhoans.Add(taiKhoan);
                db.SaveChanges();
                Account acc = new Account();
                acc.UserName = register.UserName;
                acc.PassWord = register.Password;
                return View("Login",acc);

            }    
            else
            {
                
                return View(register);
            }    
            
        }
    }
}