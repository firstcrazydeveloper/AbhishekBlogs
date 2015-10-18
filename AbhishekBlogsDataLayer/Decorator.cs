using AbhishekBlogsDataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AbhishekBlogsDataLayer
{
    public static class Decorator
    {
        public static List<BlogEntity> getBlogEntityList(List<blog> blogList)
        {
            List<BlogEntity> blogEntityList = new List<BlogEntity>();
            foreach (var blog in blogList)
            {
                BlogEntity blogEntity = getBlogEntity(blog);
                blogEntityList.Add(blogEntity);
            }

            return blogEntityList;
        }
        public static BlogEntity getBlogEntity(blog blogObj)
        {
            BlogEntity blog = new BlogEntity();
            blog.Id = blogObj.Id;
            blog.BlogShortContent = HttpUtility.HtmlDecode(blogObj.Blog_short_Content);
            blog.Blog_Id = blogObj.Blog_Id;
            blog.Blog_type_Id = blogObj.Blog_type_Id;
            blog.CreateDate = blogObj.CreateDate;
            blog.UpdatedDate = blogObj.UpdatedDate;
            blog.Description = HttpUtility.HtmlDecode(blogObj.Description);
            blog.Name = HttpUtility.HtmlDecode(blogObj.Name);
            blog.Page_Keywords =HttpUtility.HtmlDecode( blogObj.Page_Keywords);
            blog.Page_Description =HttpUtility.HtmlDecode( blogObj.Page_Description);
            blog.IsDeleted = blogObj.IsDeleted;
            blog.IsPublished = blogObj.IsPublished;
            
            return blog;
        }
        public static blog getBlog(BlogEntity blogObj)
        {
            blog blog = new blog();
            blog.Id = blogObj.Id;
            blog.Blog_Id = blogObj.Blog_Id;
            blog.Blog_type_Id = blogObj.Blog_type_Id;
            blog.CreateDate = blogObj.CreateDate;
            blog.UpdatedDate = blogObj.UpdatedDate;
            blog.Description = HttpUtility.HtmlEncode( blogObj.Description);
            blog.Blog_short_Content =HttpUtility.HtmlEncode(blogObj.BlogShortContent);
            blog.Name =HttpUtility.HtmlEncode( blogObj.Name);
            blog.Page_Keywords = HttpUtility.HtmlEncode(blogObj.Page_Keywords);
            blog.Page_Description =HttpUtility.HtmlEncode(blogObj.Page_Description);
            blog.IsDeleted = blogObj.IsDeleted;
            blog.IsPublished = blogObj.IsPublished;
            return blog;
        }

        public static List<Blog_TypeEntity> getBlogTypeEntityList(List<blog_type> blogTypeList)
        {
            List<Blog_TypeEntity> blogTypeEntityList = new List<Blog_TypeEntity>();
            foreach (var blog in blogTypeList)
            {
                Blog_TypeEntity blogTypeEntity = getBlogTypeEntity(blog);
                blogTypeEntityList.Add(blogTypeEntity);
            }

            return blogTypeEntityList;
        }
        public static Blog_TypeEntity getBlogTypeEntity(blog_type blogTypeObj)
        {
            Blog_TypeEntity blogType = new Blog_TypeEntity();
            blogType.Id = blogTypeObj.Id;
            blogType.Name = blogTypeObj.Name;
            blogType.CreateDate = blogTypeObj.CreateDate;

            return blogType;
        }
        public static blog_type getBlogType(Blog_TypeEntity blogTypeObj)
        {
            blog_type blogType = new blog_type();
            blogType.Id = blogTypeObj.Id;
            blogType.Name = blogTypeObj.Name;
            blogType.CreateDate = blogTypeObj.CreateDate;
            return blogType;
        }

        public static List<GetBlogTypeDetailsEntity> getBlogTypeDetailsList(List<GetBlogDetails_Result> blogDetailsList)
        {
            List<GetBlogTypeDetailsEntity> BlogTypeDetailsList = new List<GetBlogTypeDetailsEntity>();
            foreach (var blogResult in blogDetailsList)
            {
                GetBlogTypeDetailsEntity blogEntity = getBlogTypeDetails(blogResult);
                BlogTypeDetailsList.Add(blogEntity);
            }

            return BlogTypeDetailsList;
        }
        public static GetBlogTypeDetailsEntity getBlogTypeDetails(GetBlogDetails_Result blogDetailsResult)
        {
            GetBlogTypeDetailsEntity blogTypeDetail = new GetBlogTypeDetailsEntity();
            blogTypeDetail.BlogTypeId = blogDetailsResult.BlogTypeId;
            blogTypeDetail.Name = blogDetailsResult.Name;
            blogTypeDetail.Total = blogDetailsResult.Total;
           
            return blogTypeDetail;
        }

        public static List<Subscribed_UserEntity> getSubscribedUserList(List<subscribed_user> subscribedObjList)
        {
            List<Subscribed_UserEntity> subscribedEntityList = new List<Subscribed_UserEntity>();
            foreach (var blog in subscribedObjList)
            {
                Subscribed_UserEntity blogTypeEntity = getSubscribedUserEntity(blog);
                subscribedEntityList.Add(blogTypeEntity);
            }

            return subscribedEntityList;
        }
        public static Subscribed_UserEntity getSubscribedUserEntity(subscribed_user subscribedObj)
        {
            Subscribed_UserEntity subscribedType = new Subscribed_UserEntity();
            subscribedType.Id = subscribedObj.Id;
            subscribedType.User_Name = subscribedObj.User_Name;
            subscribedType.User_Email = subscribedObj.User_Email;
            subscribedType.BlogTypeId = subscribedObj.BlogTypeId;
            subscribedType.CreatedDate = subscribedObj.CreatedDate;
            subscribedType.User_Address = subscribedObj.User_Address;
            subscribedType.User_Contact = subscribedObj.User_Contact;
            subscribedType.UpdatedDate = subscribedObj.UpdatedDate;
            subscribedType.IsDeleted = subscribedObj.IsDeleted;

            return subscribedType;
        }
        public static subscribed_user getSubscribedUser(Subscribed_UserEntity subscribedObj)
        {
            subscribed_user subscribedType = new subscribed_user();

            subscribedType.Id = subscribedObj.Id;
            subscribedType.User_Name = subscribedObj.User_Name;
            subscribedType.User_Email = subscribedObj.User_Email;
            subscribedType.BlogTypeId = subscribedObj.BlogTypeId;
            subscribedType.CreatedDate = subscribedObj.CreatedDate;
            subscribedType.User_Address = subscribedObj.User_Address;
            subscribedType.User_Contact = subscribedObj.User_Contact;
            subscribedType.UpdatedDate = subscribedObj.UpdatedDate;
            subscribedType.IsDeleted = subscribedObj.IsDeleted;
            return subscribedType;
        }


        public static List<BlogKeywordsEntity> getBlogKeywordsEntityList(List<blog_keywords> blogKeywordsList)
        {
            List<BlogKeywordsEntity> blogKeywordsEntityList = new List<BlogKeywordsEntity>();
            foreach (var blogKeyWords in blogKeywordsList)
            {
                BlogKeywordsEntity blogKeyWordsEntity = getBlogKeywordsEntity(blogKeyWords);
                blogKeywordsEntityList.Add(blogKeyWordsEntity);
            }

            return blogKeywordsEntityList;
        }
        public static BlogKeywordsEntity getBlogKeywordsEntity(blog_keywords blogKeywordsObj)
        {
            BlogKeywordsEntity blogKeywords = new BlogKeywordsEntity();
            blogKeywords.Id = blogKeywordsObj.Id;
            blogKeywords.Page_Type = HttpUtility.HtmlDecode(blogKeywordsObj.Page_Type);
            blogKeywords.Page_Id = blogKeywordsObj.Page_Id;            
            blogKeywords.Keyword_CreatedDate = blogKeywordsObj.Keyword_CreatedDate;
            blogKeywords.Keyword_UpdatedDate = blogKeywordsObj.Keyword_UpdatedDate;
            blogKeywords.Page_Keywords = HttpUtility.HtmlDecode(blogKeywordsObj.Page_Keywords);
            blogKeywords.Page_Description = HttpUtility.HtmlDecode(blogKeywordsObj.Page_Description);
            blogKeywords.IsDeleted = blogKeywordsObj.IsDeleted;
           

            return blogKeywords;
        }
        public static blog_keywords getBlogKeywords(BlogKeywordsEntity blogKeywordsEntityObj)
        {
            blog_keywords blogKeywords = new blog_keywords();
            blogKeywords.Id = blogKeywordsEntityObj.Id;
            blogKeywords.Page_Type = HttpUtility.HtmlEncode(blogKeywordsEntityObj.Page_Type);
            blogKeywords.Page_Id = blogKeywordsEntityObj.Page_Id;
            blogKeywords.Keyword_CreatedDate = blogKeywordsEntityObj.Keyword_CreatedDate;
            blogKeywords.Keyword_UpdatedDate = blogKeywordsEntityObj.Keyword_UpdatedDate;
            blogKeywords.Page_Keywords = HttpUtility.HtmlEncode(blogKeywordsEntityObj.Page_Keywords);
            blogKeywords.Page_Description = HttpUtility.HtmlEncode(blogKeywordsEntityObj.Page_Description);
            blogKeywords.IsDeleted = blogKeywordsEntityObj.IsDeleted;
            return blogKeywords;
        }
    }
}
