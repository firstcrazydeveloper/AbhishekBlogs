using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AbhishekBlogsDataEntities
{
    public class BlogEntity
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [Display(Name = "Type")]
        public Nullable<int> Blog_type_Id { get; set; }
        public string Blog_Id { get; set; }
        
       
        [Required]
        [Display(Name = "Title")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Content")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string Description { get; set; }

       

        [Required]
        [Display(Name = "Short Content")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string BlogShortContent { get; set; }

        [Required]
        [Display(Name = "Meta Keywords")]
        [DataType(DataType.MultilineText)]
        public string Page_Keywords { get; set; }

        [Required]
        [Display(Name = "Meta Description")]
        [DataType(DataType.MultilineText)]
        public string Page_Description { get; set; }
             
        public virtual Blog_TypeEntity Blog_Type { get; set; }
        
        public virtual IEnumerable<Blog_TypeEntity> Blog_TypeList { get; set; }
       
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsPublished { get; set; }
    }
}
