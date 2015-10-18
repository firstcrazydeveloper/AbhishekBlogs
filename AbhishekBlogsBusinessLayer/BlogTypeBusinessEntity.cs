using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbhishekBlogsDataLayer;
using AbhishekBlogsDataEntities;

namespace AbhishekBlogsBusinessLayer
{
    public class BlogTypeBusinessEntity
    {
        private Blog_Types blogsTypeObj;
        private GetBlogDetailsResult blogsDetailsResultObj;
        public BlogTypeBusinessEntity()
        {
            blogsTypeObj = new Blog_Types();
            blogsDetailsResultObj = new GetBlogDetailsResult();

        }
        public List<Blog_TypeEntity> getBlogTypeList()
        {
            return blogsTypeObj.getBlogType();
        }
        public List<GetBlogTypeDetailsEntity> GetBlogTypeResult()
        {
            // TO DO : Code to get the list of all the records in database  
            return blogsDetailsResultObj.getBlogDetailsResultList();
        }
        public Blog_TypeEntity getBlogType(int id = 0)
        {
            return blogsTypeObj.getBlogType(id);
        }
        public void createBlogType(Blog_TypeEntity blogEntity)
        {
            blogsTypeObj.createBlogType(blogEntity);
        }
        public void editBlogType(Blog_TypeEntity blogEntity)
        {
            blogsTypeObj.editBlogType(blogEntity);
        }
        public void deleteBlogType(int id)
        {
            blogsTypeObj.deleteBlogType(id);
        }
    }
}
