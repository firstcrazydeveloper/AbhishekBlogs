using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AbhishekBlogsBusinessLayer;
using AbhishekBlogsDataEntities;
namespace AbhishekBlogs.Repository
{
    public class BlogTypeRepository:IBlogTypeRepository
    {
        private List<Blog_TypeEntity> products = new List<Blog_TypeEntity>();  
        private BlogTypeBusinessEntity blogTypeObject;
        public BlogTypeRepository()  
        {
            blogTypeObject = new BlogTypeBusinessEntity();
        }

        public IEnumerable<Blog_TypeEntity> GetAll()  
        {  
            // TO DO : Code to get the list of all the records in database  
            return blogTypeObject.getBlogTypeList();  
        }
        public IEnumerable<GetBlogTypeDetailsEntity> GetBlogTypeResult()
        {
            // TO DO : Code to get the list of all the records in database  
            return blogTypeObject.GetBlogTypeResult();
        }
        public Blog_TypeEntity Get(int id)  
        {  
            // TO DO : Code to find a record in database  
            return blogTypeObject.getBlogType(id);  
        }
        public Blog_TypeEntity Add(Blog_TypeEntity item)  
        {  
            if (item == null)  
            {  
                throw new ArgumentNullException("item");  
            }

            blogTypeObject.createBlogType(item);
            return item;  
        }
        public bool Update(Blog_TypeEntity item)  
        {  
            if (item == null)  
            {  
                throw new ArgumentNullException("item");  
            }  
  
            // TO DO : Code to update record into database  
            blogTypeObject.editBlogType(item);
            return true;  
        }  
        public bool Delete(int id)  
        {  
            // TO DO : Code to remove the records from database  
            blogTypeObject.deleteBlogType(id);
            return true;  
        } 
    }
}