namespace Blog.Domains
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int Id { get; set; }

        [StringLength(225)]
        public string Name { get; set; }

        public string Email { get; set; }

        public string CommentHeader { get; set; }

        [StringLength(225)]
        [Display(Name ="Nội dung")]
        public string CommentText { get; set; }
        [Display(Name = "Ngày đăng")]

        public DateTime? DateTime { get; set; }

        public int? PostId { get; set; }
        [Display(Name = "Trạng thái")]

        public byte? Status { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedOn { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? UpdatedOn { get; set; }

        public virtual Post Post { get; set; }
    }
}
