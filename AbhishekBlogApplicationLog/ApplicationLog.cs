using System.Text;
using System.IO;
using System.Web;
using System.Web.UI;
using System;

namespace AbhishekBlogApplicationLog
{
    public static class ApplicationLog
    {
        public static void WriteTrace(string FilePath, Exception Ex)
        {

        }
        public static void WriteTrace(string FilePath, string Message)
        {

        }
        public static void WriteTrace(Exception Ex)
        {
            StreamWriter log;
            string filepath = HttpContext.Current.Server.MapPath("~");// AppDomain.CurrentDomain.BaseDirectory;
           
            string fileName = DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString();
            fileName = fileName + "_" + "ApplicationLog.txt";
            var pathWithParent = Path.Combine(filepath, "ApplicationLog/"+fileName);
            if (!File.Exists(HttpContext.Current.Server.MapPath("~/ApplicationLog/" + fileName)))
            {
                log = new StreamWriter(HttpContext.Current.Server.MapPath("~/ApplicationLog/" + fileName));
            }
            else
            {
                log = File.AppendText(HttpContext.Current.Server.MapPath("~/ApplicationLog/" + fileName));

            }

            log.WriteLine("Data Time:" + DateTime.Now);
            log.WriteLine("Exception Name:" + Ex.Message);
            log.WriteLine("Event Name:" + Ex.ToString());
            log.WriteLine("Error Line No.:" + LineNumber(Ex));
            log.WriteLine("Inner Exception Message" + Ex.InnerException);
            log.Close();


        }
        public static void WriteTrace(string Message)
        {

        }
        public static int LineNumber(this Exception e)
        {

            int linenum = 0;

            try
            {

                linenum = Convert.ToInt32(e.StackTrace.Substring(e.StackTrace.LastIndexOf(":line") + 5));

            }

            catch
            {

                //Stack trace is not available!

            }

            return linenum;

        }
    }
}
