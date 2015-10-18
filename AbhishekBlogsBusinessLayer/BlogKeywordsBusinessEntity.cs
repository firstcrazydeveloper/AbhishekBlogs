using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbhishekBlogsDataLayer;
using AbhishekBlogsDataEntities;

namespace AbhishekBlogsBusinessLayer
{
    public class BlogKeywordsBusinessEntity
    {
        private BlogKeywords blogsKeywordsObj;
        public BlogKeywordsBusinessEntity()
        {
            blogsKeywordsObj = new BlogKeywords();

        }
        public List<BlogKeywordsEntity> getBlogKeywordsList()
        {
            return blogsKeywordsObj.getBlogKeywordsList();
        }
        public BlogKeywordsEntity getBlogKeywordsListByBlogId(int blogId = 0)
        {
            return blogsKeywordsObj.getBlogKeywordsListByBlogId(blogId);
        }
        public BlogKeywordsEntity getBlogKeywordsListByBlogTitle(string blogTitle = "Homepage")
        {
            return blogsKeywordsObj.getBlogKeywordsListByBlogTitle(blogTitle);
        }
        public BlogKeywordsEntity getBlogKeywords(int id = 0)
        {
            return blogsKeywordsObj.getBlogKeywords(id);
        }
        public BlogKeywordsEntity createBlogKeywords(BlogKeywordsEntity blogKeywordsEntity)
        {
            return blogsKeywordsObj.createBlogKeywords(blogKeywordsEntity);
        }
        public void editBlogKeywords(BlogKeywordsEntity blogKeywordsEntity)
        {
            blogsKeywordsObj.editBlogKeywords(blogKeywordsEntity);
        }

        public void deleteBlogKeywords(int id=0)
        {
            blogsKeywordsObj.deleteBlogKeywords(id);
        }

       
    }
}
