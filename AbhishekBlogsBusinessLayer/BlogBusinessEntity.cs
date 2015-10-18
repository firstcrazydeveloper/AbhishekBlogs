using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbhishekBlogsDataLayer;
using AbhishekBlogsDataEntities;

namespace AbhishekBlogsBusinessLayer
{
    public class BlogBusinessEntity
    {
        private Blogs blogsObj;
        public BlogBusinessEntity()
        {
            blogsObj=new Blogs();

        }
        public List<BlogEntity> getBlogList()
        {
            return blogsObj.getBlogList();
        }
        public List<BlogEntity> getBlogListByBlogType(int blogTypeId)
        {
            return blogsObj.getBlogListByBlogType(blogTypeId);
        }
        public BlogEntity getBlog(int id = 0)
        {
            return blogsObj.getBlog(id);
        }
        public BlogEntity createBlog(BlogEntity blogEntity)
        {
            return blogsObj.createBlog(blogEntity);
        }
        public void editBlog(BlogEntity blogEntity)
        {
            blogsObj.editBlog(blogEntity);
        }
        public void deleteBlog(int id)
        {
            blogsObj.deleteBlog(id);
        }

        public BlogEntity publishBlog(int id)
        {
            return blogsObj.publishBlog(id);
        }
    }
}
