using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HtmlAgilityPack;
using System.Text;


namespace JobFinder
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string[] JobFinder(string type, string place)
        {
            string[] urls = new string[50];

            int i = 0;
            int j = 0;
            

            HtmlWeb obj = new HtmlWeb();

            string url = "http://www.jobs.com/jobs/search?q=" + type + "&where=" + place;

            HtmlDocument doc = obj.Load(url);
            HtmlNodeCollection hrefs = doc.DocumentNode.SelectNodes("//a[@rel='nofollow']");



            try //Try and catch blocks to handle the event when no news items are returned
            {
                foreach (HtmlNode href in hrefs)
                {
                    
                        urls[i] = href.Attributes["href"].Value;

                        i++;
                        if (i > 50)
                            break;
      
                }
            }
            catch
            {

            }
            
            return urls;

         }


 
     }
}
