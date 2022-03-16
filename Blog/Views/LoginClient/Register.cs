using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Views.LoginClient
{
    public class Register
    {
        [Display(Name ="Tên đăng nhập")]
        [Required(ErrorMessage ="Không được để trống")]
        public string UserName{get;set;}
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Không được để trống")]
        public string Email{get;set;}
        [Display(Name = "Mật khẩu")]
        [MinLength(8,ErrorMessage ="Tối thiểu 8 kí tự")]
        [MaxLength(20,ErrorMessage ="Tối thiểu 20 kí tự")]
        [Required(ErrorMessage = "Không được để trống")]
        public string Password{get;set;}
        [Display(Name = "Nhập lại mật khẩu")]
        [Required(ErrorMessage = "Không được để trống")]
        [Compare("Password",ErrorMessage ="Mật khẩu không khớp")]
        public string RePassword{get;set;}
    }
}