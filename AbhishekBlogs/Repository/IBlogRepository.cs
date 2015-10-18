using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AbhishekBlogsDataEntities;
namespace AbhishekBlogs.Repository
{
    public interface IBlogRepository
    {
        IEnumerable<BlogEntity> GetAll();
        BlogEntity Get(int id);
        BlogEntity Add(BlogEntity item);
        bool Update(BlogEntity item);
        bool Delete(int id);
        BlogEntity Publish(int id);
    }
}