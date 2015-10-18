using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AbhishekBlogsDataEntities
{
    public class GetBlogTypeDetailsEntity
    {
        [Display(Name = "Blog TypeId")]
        public Nullable<int> BlogTypeId { get; set; }
        [Display(Name = "Total Blog")]
        public Nullable<int> Total { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
