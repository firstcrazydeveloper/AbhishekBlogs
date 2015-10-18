using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbhishekBlogsDataEntities;

namespace AbhishekBlogsDataLayer
{
    public class BlogKeywords
    {
        private AbhishekBlogsEntities db;

        public BlogKeywords()
        {
            db = new AbhishekBlogsEntities();

        }
        public List<BlogKeywordsEntity> getBlogKeywordsList()
        {
            return Decorator.getBlogKeywordsEntityList((db.blog_keywords.Where(b =>b.IsDeleted==false).OrderByDescending(b => b.Keyword_CreatedDate)).ToList());
        }
        public BlogKeywordsEntity getBlogKeywordsListByBlogId(int blogId=0)
        {
            BlogKeywordsEntity blogKeywordsEntity = new BlogKeywordsEntity();
            var blogKeywords = db.blog_keywords.Where(bk => bk.Page_Id == blogId && bk.IsDeleted == false).ToList();
            if (blogKeywords != null && blogKeywords.Count > 0)
            {
                blogKeywordsEntity= Decorator.getBlogKeywordsEntity(blogKeywords[0]);
            }
            return blogKeywordsEntity;
        }

        public BlogKeywordsEntity getBlogKeywordsListByBlogTitle(string blogTitle="Homepage")
        {
            BlogKeywordsEntity blogKeywordsEntity = new BlogKeywordsEntity();
            var blogKeywords = db.blog_keywords.Where(bk => bk.Page_Type == blogTitle && bk.IsDeleted == false).ToList();
            if (blogKeywords != null && blogKeywords.Count > 0)
            {
                blogKeywordsEntity = Decorator.getBlogKeywordsEntity(blogKeywords[0]);
            }
            return blogKeywordsEntity;
        }
        public BlogKeywordsEntity getBlogKeywords(int id = 0)
        {
            blog_keywords blogKeywords = db.blog_keywords.Find(id);

            return Decorator.getBlogKeywordsEntity(blogKeywords);
        }
        public BlogKeywordsEntity createBlogKeywords(BlogKeywordsEntity blogKeywordsEntity)
        {
            blog_keywords blogKeywordsObj = Decorator.getBlogKeywords(blogKeywordsEntity);
            blogKeywordsObj.Keyword_CreatedDate = DateTime.Now;
            blogKeywordsObj.Keyword_UpdatedDate = DateTime.Now;
            db.blog_keywords.Add(blogKeywordsObj);
            db.SaveChanges();
            return Decorator.getBlogKeywordsEntity(blogKeywordsObj);
               
        }
        public void editBlogKeywords(BlogKeywordsEntity blogKeywordsEntity)
        {
            blog_keywords blogKeywordsObj = db.blog_keywords.Find(blogKeywordsEntity.Id);
            blogKeywordsObj.Page_Description = blogKeywordsEntity.Page_Description;
            blogKeywordsObj.Page_Keywords = blogKeywordsEntity.Page_Keywords;
            blogKeywordsObj.Keyword_UpdatedDate = DateTime.Now;
            db.Entry(blogKeywordsObj).State = EntityState.Modified;
            db.SaveChanges();
               
        }
       
        public void deleteBlogKeywords(int id)
        {
            blog_keywords blogKeywordsObj = db.blog_keywords.Find(id);
            blogKeywordsObj.IsDeleted = true;
            db.Entry(blogKeywordsObj).State = EntityState.Modified;
            db.SaveChanges();
            //db.blogs.Remove(blog);
            //db.SaveChanges();
           
        }
    }
}
