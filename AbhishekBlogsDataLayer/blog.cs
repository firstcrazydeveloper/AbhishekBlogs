//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AbhishekBlogsDataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class blog
    {
        public int Id { get; set; }
        public Nullable<int> Blog_type_Id { get; set; }
        public string Blog_Id { get; set; }
        public string Blog_short_Content { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsPublished { get; set; }
        public string Page_Keywords { get; set; }
        public string Page_Description { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual blog_type blog_type { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
