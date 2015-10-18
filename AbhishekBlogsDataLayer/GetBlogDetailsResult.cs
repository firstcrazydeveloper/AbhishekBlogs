using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbhishekBlogsDataEntities;

namespace AbhishekBlogsDataLayer
{

    public class GetBlogDetailsResult
    {
        private AbhishekBlogsEntities db;
        public GetBlogDetailsResult()
        {
            db = new AbhishekBlogsEntities();

        }
        public List<GetBlogTypeDetailsEntity> getBlogDetailsResultList()
        {
            return Decorator.getBlogTypeDetailsList((db.GetBlogDetails()).ToList());
        }
    }
}
