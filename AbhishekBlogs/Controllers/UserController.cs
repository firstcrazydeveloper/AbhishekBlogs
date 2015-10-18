using AbhishekBlogs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AbhishekBlogsDataEntities;
using AbhishekBlogsBusinessLayer;
using AbhishekBlogs.Helpers;

namespace AbhishekBlogs.Controllers
{
    public class UserController : ApiController
    {
        readonly ISubscribedRepository repo;
        private IBlogTypeRepository blogTyperepo = new BlogTypeRepository();
        public UserController(ISubscribedRepository subscribedUserData)  
        {
            this.repo = subscribedUserData;  
           
        }
        public UserController()
        {
            this.repo = new SubscribedRepository();

        }   
        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public string Post(User userDeatails )
        {
            try
            {
                
                // TODO: Add insert logic here
                var allblogType = blogTyperepo.GetAll();
                string str = "";
                foreach(var obj in allblogType ){
                    if (str != "")
                        str = str + ",";
                    str = str + obj.Id;

                }
                Subscribed_UserEntity user = new Subscribed_UserEntity();
                user.User_Name = userDeatails.UserName;
                user.User_Email = userDeatails.UserEmail;
                user.BlogTypeId = str;
                user.IsDeleted = false;
                user.CreatedDate = DateTime.Now;
                repo.Add(user);
                return "success";
               
            }
            catch
            {
                return "failed";
            }
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
