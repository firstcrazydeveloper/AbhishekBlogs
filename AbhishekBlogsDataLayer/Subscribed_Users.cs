using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbhishekBlogsDataEntities;
using System.Data.Entity;

namespace AbhishekBlogsDataLayer
{
    public class Subscribed_Users
    {
         private AbhishekBlogsEntities db;
         public Subscribed_Users()
        {
            db = new AbhishekBlogsEntities();

        }
         public List<Subscribed_UserEntity> getSubscribedUserList()
         {
             return Decorator.getSubscribedUserList((db.subscribed_user.Where(b => b.IsDeleted == false).OrderByDescending(b => b.CreatedDate)).ToList());
         }
        
         public Subscribed_UserEntity getSubscribedUser(int id = 0)
         {
             subscribed_user user = db.subscribed_user.Find(id);

             return Decorator.getSubscribedUserEntity(user);
         }
         public void createSubscribedUser(Subscribed_UserEntity userEntity)
         {
             var temp = db.subscribed_user.Where(subuser => subuser.User_Email == userEntity.User_Email).FirstOrDefault();
             if (temp == null)
             {
                 subscribed_user user = Decorator.getSubscribedUser(userEntity);
                 user.CreatedDate = DateTime.Now;
                 user.UpdatedDate = DateTime.Now;
                 user.IsDeleted = false;
                 db.subscribed_user.Add(user);
                 db.SaveChanges();
             }

         }
         public void editSubscribedUser(Subscribed_UserEntity userEntity)
         {
             subscribed_user user = Decorator.getSubscribedUser(userEntity);
             user.UpdatedDate = DateTime.Now;
             db.Entry(user).State = EntityState.Modified;
             db.SaveChanges();

         }
         public void deleteSubscribedUser(int id)
         {
             subscribed_user userObj = db.subscribed_user.Find(id);
             userObj.IsDeleted = true;
             db.Entry(userObj).State = EntityState.Modified;
             db.SaveChanges();
             //db.blogs.Remove(blog);
             //db.SaveChanges();

         }
    }
}
