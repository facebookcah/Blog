using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Areas.Admin.Views.Login
{
    public class Account
    {
        [Required(ErrorMessage ="Không được để trống")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Không được để trống")]

        public string PassWord { get; set; }
    }
}