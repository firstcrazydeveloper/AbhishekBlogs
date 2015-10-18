using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AbhishekBlogsDataEntities;
using AbhishekBlogsBusinessLayer;

namespace AbhishekBlogs.Repository
{
    public class BlogRepository:IBlogRepository
    {
        private List<BlogEntity> products = new List<BlogEntity>();  
        private BlogBusinessEntity blogObject;
        public BlogRepository()  
        {
            blogObject = new BlogBusinessEntity();
        }  
  
        public IEnumerable<BlogEntity> GetAll()  
        {  
            // TO DO : Code to get the list of all the records in database  
            return blogObject.getBlogList();  
        }  
        public BlogEntity Get(int id)  
        {  
            // TO DO : Code to find a record in database  
            return blogObject.getBlog(id);  
        }
        public BlogEntity Add(BlogEntity item)  
        {  
            if (item == null)  
            {  
                throw new ArgumentNullException("item");  
            }
            return blogObject.createBlog(item);   
        }  
        public bool Update(BlogEntity item)  
        {  
            if (item == null)  
            {  
                throw new ArgumentNullException("item");  
            }  
  
            // TO DO : Code to update record into database  
            blogObject.editBlog(item);
            return true;  
        }  
        public bool Delete(int id)  
        {  
            // TO DO : Code to remove the records from database  
            blogObject.deleteBlog(id);
            return true;  
        }

        public BlogEntity Publish(int id)
        {
            // TO DO : Code to remove the records from database  
            return blogObject.publishBlog(id);
           
        }   
    }
}