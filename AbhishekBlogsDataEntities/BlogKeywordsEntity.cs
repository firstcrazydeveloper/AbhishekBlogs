using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AbhishekBlogsDataEntities
{
    public class BlogKeywordsEntity
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Nullable<int> Page_Id { get; set; }

        [Required]
        [Display(Name = "Blog Title")]
        public string Page_Type { get; set; }

        [Required]
        [Display(Name = "Blog Keywords")]
        [DataType(DataType.MultilineText)]
        public string Page_Keywords { get; set; }

        [Required]
        [Display(Name = "Blog Description")]
        [DataType(DataType.MultilineText)]
        public string Page_Description { get; set; }
        public Nullable<System.DateTime> Keyword_CreatedDate { get; set; }
        public Nullable<System.DateTime> Keyword_UpdatedDate { get; set; }

        public Nullable<bool> IsDeleted { get; set; }

        public virtual BlogEntity blog { get; set; }
    }
}
