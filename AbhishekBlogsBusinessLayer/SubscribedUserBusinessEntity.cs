using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbhishekBlogsDataLayer;
using AbhishekBlogsDataEntities;

namespace AbhishekBlogsBusinessLayer
{
   public class SubscribedUserBusinessEntity
    {
        private Subscribed_Users userObj;
        public SubscribedUserBusinessEntity()
        {
            userObj = new Subscribed_Users();

        }
        public List<Subscribed_UserEntity> getSubscribedUserList()
        {
            return userObj.getSubscribedUserList();
        }

        public Subscribed_UserEntity getSubscribedUser(int id = 0)
        {
            return userObj.getSubscribedUser(id);
        }
        public void createSubscribedUser(Subscribed_UserEntity userEntity)
        {
            userObj.createSubscribedUser(userEntity);
        }
        public void editSubscribedUser(Subscribed_UserEntity userEntity)
        {
            userObj.editSubscribedUser(userEntity);
        }
        public void deleteSubscribedUser(int id)
        {
            userObj.deleteSubscribedUser(id);
        }
    }
}
