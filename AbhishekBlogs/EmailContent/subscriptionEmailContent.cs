using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using AbhishekBlogsDataEntities;
using AbhishekBlogsBusinessLayer;
using AbhishekBlogs.Repository;
using AbhishekBlogs.Helpers;
using System.Web.Configuration;

namespace AbhishekBlogs.EmailContent
{
    public class subscriptionEmailContent
    {
        private IBlogTypeRepository blogTypeRepo;
        private ISubscribedRepository userRepo;

        public subscriptionEmailContent()
        {
            blogTypeRepo = new BlogTypeRepository();
            userRepo = new SubscribedRepository();
        }
        public void sendmail(BlogEntity blog){

            var allblogType = blogTypeRepo.GetAll();
            string str = "";
            foreach (var obj in allblogType)
            {
                if (str != "")
                    str = str + ",";
                str = str + obj.Id;

            }
            var alluserList = userRepo.GetAll();
            var appUrl = WebConfigurationManager.AppSettings["AppUrl"].ToString() + blog.Id.ToString() + "/" + blog.Name.ToSeoUrl();
            foreach (var user in alluserList)
            {
                var desc="firstcrazydeveloper.com --  Abhishek Kumar, First Crazy Developer";
                var mailBody = PopulateBody(user.User_Name, blog.Name, appUrl, desc);
                SendHtmlFormattedEmail(user.User_Email, blog.Name, mailBody);
            }

        }

        private string PopulateBody(string userName, string title, string url, string description)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailContent/subscriptionEmailContent.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{UserName}", userName);
            body = body.Replace("{Title}", title);
            body = body.Replace("{Url}", url);
            body = body.Replace("{Description}", description);
            return body;
        }

        private void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                try
                {
                    mailMessage.From = new MailAddress(WebConfigurationManager.AppSettings["UserEmail"]);
                    mailMessage.Subject ="FirstCrazyDeveloper - "+ subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(new MailAddress(recepientEmail));
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = WebConfigurationManager.AppSettings["Host"];
                    smtp.EnableSsl = Convert.ToBoolean(WebConfigurationManager.AppSettings["EnableSsl"]);
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    NetworkCred.UserName = WebConfigurationManager.AppSettings["UserName"];
                    NetworkCred.Password = WebConfigurationManager.AppSettings["Password"];
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = int.Parse(WebConfigurationManager.AppSettings["Port"]);
                    smtp.Send(mailMessage);
                }
                catch (SmtpException ex)
                {

                }
            }
               

           
        }


    }

}