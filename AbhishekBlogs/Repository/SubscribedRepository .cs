using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AbhishekBlogsDataEntities;
using AbhishekBlogsBusinessLayer;
namespace AbhishekBlogs.Repository
{
    public class SubscribedRepository:ISubscribedRepository
    {
        private List<Subscribed_UserEntity> user = new List<Subscribed_UserEntity>();  
        private SubscribedUserBusinessEntity userObject;
        public SubscribedRepository()  
        {
            userObject = new SubscribedUserBusinessEntity();
        }

        public IEnumerable<Subscribed_UserEntity> GetAll()  
        {  
            // TO DO : Code to get the list of all the records in database  
            return userObject.getSubscribedUserList();  
        }
        public Subscribed_UserEntity Get(int id)  
        {  
            // TO DO : Code to find a record in database  
            return userObject.getSubscribedUser(id);  
        }
        public Subscribed_UserEntity Add(Subscribed_UserEntity item)  
        {  
            if (item == null)  
            {  
                throw new ArgumentNullException("item");  
            }

            userObject.createSubscribedUser(item);
            return item;  
        }
        public bool Update(Subscribed_UserEntity item)  
        {  
            if (item == null)  
            {  
                throw new ArgumentNullException("item");  
            }  
  
            // TO DO : Code to update record into database  
            userObject.editSubscribedUser(item);
            return true;  
        }  
        public bool Delete(int id)  
        {  
            // TO DO : Code to remove the records from database  
            userObject.deleteSubscribedUser(id);
            return true;  
        }   
    }
}