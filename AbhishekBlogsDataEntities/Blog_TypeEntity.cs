using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbhishekBlogsDataEntities
{
    public class Blog_TypeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public virtual ICollection<BlogEntity> blogs { get; set; }

    }
}
