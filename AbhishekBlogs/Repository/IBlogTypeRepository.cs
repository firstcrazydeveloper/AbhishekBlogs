using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AbhishekBlogsDataEntities;
namespace AbhishekBlogs.Repository
{
    public interface IBlogTypeRepository
    {
        IEnumerable<Blog_TypeEntity> GetAll();
        IEnumerable<GetBlogTypeDetailsEntity> GetBlogTypeResult();
        Blog_TypeEntity Get(int id);
        Blog_TypeEntity Add(Blog_TypeEntity item);
        bool Update(Blog_TypeEntity item);
        bool Delete(int id);
    }
}