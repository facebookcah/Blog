namespace Blog.Domains
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }

        [StringLength(225,ErrorMessage ="Không vượt quá 225 kí tự")]
        [Display(Name="Tên danh mục")]
        public string Name { get; set; }

        [StringLength(225)]
        public string UrlSlug { get; set; }

        [StringLength(1024, ErrorMessage = "Không vượt quá 1024 kí tự")]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        
        [Display(Name = "Trạng thái")]
        public byte? Status { get; set; }
        
        [Display(Name = "Ngày tạo")]
        [Column(TypeName = "datetime2")]
        public DateTime? CreatedOn { get; set; }
        [Display(Name = "Ngày cập nhật")]

        [Column(TypeName = "datetime2")]
        public DateTime? UpdatedOn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
