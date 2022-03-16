namespace Blog.Domains
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Post")]
    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            Comments = new HashSet<Comment>();
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        [StringLength(500,ErrorMessage ="Không quá 500 kí tự")]
        [Display(Name = "Tiêu đề")]

        public string Title { get; set; }

        [StringLength(500)]
        public string ShortDescription { get; set; }
        [Display(Name = "Nội dung")]

        [Column(TypeName = "ntext")]
        public string PostContent { get; set; }

        [StringLength(225)]
        public string UrlSlug { get; set; }
        [Display(Name = "Trạng thái đăng")]

        public bool? Published { get; set; }
        [Display(Name = "Ngày đăng")]

        public DateTime? PostedOn { get; set; }

        public bool? Modifiled { get; set; }
        [Display(Name = "Lượt xem")]

        public int? ViewCount { get; set; }
        [Display(Name = "Lượt đánh giá")]

        public int? RateCount { get; set; }

        public int? TotalRate { get; set; }

        public double? Rate { get; set; }
        [Display(Name = "Danh mục")]

        public int? CategoryId { get; set; }

        public byte? Status { get; set; }
        [Display(Name = "Ngày tạo")]

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedOn { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Ngày cập nhật")]

        public DateTime? UpdatedOn { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
