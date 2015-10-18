using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AbhishekBlogsDataEntities;
using AbhishekBlogsBusinessLayer;

namespace AbhishekBlogs.Repository
{
    public class BlogKeywordsRepository : IBlogKeywordsRepository
    {
        private BlogKeywordsBusinessEntity blogKeywordsObject;
        public BlogKeywordsRepository()  
        {
            blogKeywordsObject = new BlogKeywordsBusinessEntity();
        }  
  
        public IEnumerable<BlogKeywordsEntity> GetAll()  
        {  
            // TO DO : Code to get the list of all the records in database  
            return blogKeywordsObject.getBlogKeywordsList();  
        }
        public BlogKeywordsEntity Get(int id)  
        {  
            // TO DO : Code to find a record in database  
            return blogKeywordsObject.getBlogKeywords(id);  
        }
        public BlogKeywordsEntity GetByBlogId(int id)
        {
            // TO DO : Code to find a record in database  
            return blogKeywordsObject.getBlogKeywordsListByBlogId(id);
        }

        public BlogKeywordsEntity GetByBlogTitle(string title)
        {
            // TO DO : Code to find a record in database  
            return blogKeywordsObject.getBlogKeywordsListByBlogTitle(title);
        }
        public BlogKeywordsEntity Add(BlogKeywordsEntity item)  
        {  
            if (item == null)  
            {  
                throw new ArgumentNullException("item");  
            }
            return blogKeywordsObject.createBlogKeywords(item);   
        }
        public bool Update(BlogKeywordsEntity item)  
        {  
            if (item == null)  
            {  
                throw new ArgumentNullException("item");  
            }  
  
            // TO DO : Code to update record into database  
            blogKeywordsObject.editBlogKeywords(item);
            return true;  
        }  
        public bool Delete(int id)  
        {  
            // TO DO : Code to remove the records from database  
            blogKeywordsObject.deleteBlogKeywords(id);
            return true;  
        }
    }
}