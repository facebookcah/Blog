namespace Blog.Domains
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        public int Id { get; set; }

        [StringLength(100,ErrorMessage ="Không quá 100 kí tự !")]
        [Display(Name ="Email")]
        public string Email { get; set; }

        
        [StringLength(20, ErrorMessage = "Không quá 20 kí tự !")]
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }

        [MaxLength(20, ErrorMessage = "Tối đa 20 kí tự !")]
        [MinLength(8, ErrorMessage = "Tối thiểu 8 kí tự !")]
        [Display(Name = "Mật khẩu")]
        public string PassWord { get; set; }
        [Display(Name = "Loại")]
        public bool? Type { get; set; }
        [Display(Name = "Trạng thái")]

        public bool? Status { get; set; }
        [Display(Name = "Ngày tạo")]

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedOn { get; set; }
        [Display(Name = "Ngày cập nhật")]

        [Column(TypeName = "datetime2")]
        public DateTime? UpdatedOn { get; set; }
    }
}
