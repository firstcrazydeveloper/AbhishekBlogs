using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AbhishekBlogsDataEntities
{
    public class Subscribed_UserEntity
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string User_Name { get; set; }
        [Required]
        [Display(Name = "User Email")]
        public string User_Email { get; set; }
        public string User_Contact { get; set; }
        public string User_Address { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        [Required]
        [Display(Name = "Seleted Blog Type")]
        public string BlogTypeId { get; set; }
    }
}
