using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbhishekBlogsDataEntities;
using AbhishekBlogApplicationLog;

namespace AbhishekBlogsDataLayer
{
    public class Blogs
    {
        private AbhishekBlogsEntities db;
        public Blogs()
        {
            db = new AbhishekBlogsEntities();

        }
        public List<BlogEntity> getBlogList()
        {
            try
            {
                return Decorator.getBlogEntityList((db.blogs.Where(b => b.IsDeleted == false).OrderByDescending(b => b.UpdatedDate)).ToList());
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteTrace(ex);
                return null;
            }
        }
        public List<BlogEntity> getBlogListByBlogType(int blogTypeId)
        {
            try
            {
                return Decorator.getBlogEntityList((db.blogs.Where(b => b.Blog_type_Id == blogTypeId).OrderByDescending(b => b.CreateDate)).ToList());
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteTrace(ex);
                return null;
            }
        }
        public BlogEntity getBlog(int id = 0)
        {
            try
            {
                blog blog = db.blogs.Find(id);

                return Decorator.getBlogEntity(blog);
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteTrace(ex);
                return null;
            }
        }
        public BlogEntity createBlog(BlogEntity blogEntity)
        {
            try
            {
                blog blogObj = Decorator.getBlog(blogEntity);
                blogObj.CreateDate = DateTime.Now;
                blogObj.IsPublished = false;
                db.blogs.Add(blogObj);
                db.SaveChanges();
                BlogKeywords blogKeywordsObj = new BlogKeywords();
                BlogKeywordsEntity blogKeywords = new BlogKeywordsEntity();
                blogKeywords.Page_Id = blogObj.Id;
                blogKeywords.Page_Type = blogObj.Name;
                blogKeywords.Page_Keywords = blogEntity.Page_Keywords;
                blogKeywords.Page_Description = blogEntity.Page_Description;
                blogKeywords.IsDeleted = false;
                blogKeywordsObj.createBlogKeywords(blogKeywords);
                return Decorator.getBlogEntity(blogObj);
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteTrace(ex);
                return null;
            }
               
        }
        public void editBlog(BlogEntity blogEntity)
        {
            try
            {
                blog blogObj = Decorator.getBlog(blogEntity);
                db.Entry(blogObj).State = EntityState.Modified;
                db.SaveChanges();
                BlogKeywords blogKeywordsObj = new BlogKeywords();
                BlogKeywordsEntity blogKeywords = blogKeywordsObj.getBlogKeywordsListByBlogId(blogObj.Id);

                blogKeywords.Page_Type = blogObj.Name;
                blogKeywords.Page_Keywords = blogEntity.Page_Keywords;
                blogKeywords.Page_Description = blogEntity.Page_Description;
                blogKeywords.IsDeleted = false;
                if (blogKeywords.Id != 0)
                {
                    blogKeywordsObj.editBlogKeywords(blogKeywords);
                }
                else
                {
                    blogKeywordsObj.createBlogKeywords(blogKeywords);
                }
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteTrace(ex);
            }
               
        }
        public BlogEntity publishBlog(int id)
        {
            try
            {
                blog blogObj = db.blogs.Find(id);
                blogObj.IsPublished = true;
                db.Entry(blogObj).State = EntityState.Modified;
                db.SaveChanges();
                return Decorator.getBlogEntity(blogObj);
                //db.blogs.Remove(blog);
                //db.SaveChanges();
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteTrace(ex);
                return null;
            }

        }
        public void deleteBlog(int id)
        {
            try
            {
                blog blogObj = db.blogs.Find(id);
                blogObj.IsDeleted = true;
                db.Entry(blogObj).State = EntityState.Modified;
                db.SaveChanges();
                BlogKeywords blogKeywordsObj = new BlogKeywords();
                BlogKeywordsEntity blogKeywords = blogKeywordsObj.getBlogKeywordsListByBlogId(blogObj.Id);
                blogKeywordsObj.deleteBlogKeywords(blogKeywords.Id);
                //db.blogs.Remove(blog);
                //db.SaveChanges();
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteTrace(ex);

            }
           
        }
    }
}
