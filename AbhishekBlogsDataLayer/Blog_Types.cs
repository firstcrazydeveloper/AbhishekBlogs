using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbhishekBlogsDataEntities;
using System.Data.Entity;

namespace AbhishekBlogsDataLayer
{
    public class Blog_Types
    {
        private AbhishekBlogsEntities db;
        public Blog_Types()
        {
            db = new AbhishekBlogsEntities();

        }
        public List<Blog_TypeEntity> getBlogType()
        {
            return Decorator.getBlogTypeEntityList((db.blog_type.Where(bt=>bt.IsDeleted==false).OrderByDescending(b => b.CreateDate)).ToList());
        }
        public Blog_TypeEntity getBlogType(int id = 0)
        {
            blog_type blogType = db.blog_type.Find(id);

            return Decorator.getBlogTypeEntity(blogType);
        }
        public void createBlogType(Blog_TypeEntity blogEntity)
        {
            blog_type blogTypeObj = Decorator.getBlogType(blogEntity);
            blogTypeObj.CreateDate = DateTime.Now;
            db.blog_type.Add(blogTypeObj);
            db.SaveChanges();
               
        }
        public void editBlogType(Blog_TypeEntity blogEntity)
        {
            blog_type blogTypeObj = Decorator.getBlogType(blogEntity);
            db.Entry(blogTypeObj).State = EntityState.Modified;
            db.SaveChanges();
               
        }
        public void deleteBlogType(int id)
        {
            blog_type blogTypeObj = db.blog_type.Find(id);
            blogTypeObj.IsDeleted = true;
            db.Entry(blogTypeObj).State = EntityState.Modified;
            //db.blog_type.Remove(blogTypeObj);
            db.SaveChanges();
           
        }
      
    }
}
