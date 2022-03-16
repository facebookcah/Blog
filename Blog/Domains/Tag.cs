namespace Blog.Domains
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tag")]
    public partial class Tag
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tag()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }

        [Display(Name = "Tag")]

        [StringLength(225,ErrorMessage ="Không quá 225 kí tự")]
        public string TagName { get; set; }

        [StringLength(225)]
        public string UrlSlug { get; set; }
        [Display(Name ="Mô tả")]
        [StringLength(1024,ErrorMessage ="Không quá 1024 kí tự")]
        public string Description { get; set; }

        public int? Count { get; set; }
        [Display(Name = "Trạng thái")]

        public byte? Status { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Ngày tạo")]

        public DateTime? CreatedOn { get; set; }
        [Display(Name = "Ngày cập nhật")]

        [Column(TypeName = "datetime2")]
        public DateTime? UpdatedOn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
