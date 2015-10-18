using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AbhishekBlogsDataEntities;

namespace AbhishekBlogs.Repository
{
    public interface IBlogKeywordsRepository
    {
        IEnumerable<BlogKeywordsEntity> GetAll();
        BlogKeywordsEntity Get(int id);
        BlogKeywordsEntity GetByBlogId(int id);
        BlogKeywordsEntity GetByBlogTitle(string title);
        BlogKeywordsEntity Add(BlogKeywordsEntity item);
        bool Update(BlogKeywordsEntity item);
        bool Delete(int id);
       
    }
}