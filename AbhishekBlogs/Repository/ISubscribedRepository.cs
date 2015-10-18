using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AbhishekBlogsDataEntities;
namespace AbhishekBlogs.Repository
{
    public interface ISubscribedRepository
    {
        IEnumerable<Subscribed_UserEntity> GetAll();
        Subscribed_UserEntity Get(int id);
        Subscribed_UserEntity Add(Subscribed_UserEntity item);
        bool Update(Subscribed_UserEntity item);
        bool Delete(int id);
    }
    public class User
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
    }
}