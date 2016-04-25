using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using HtmlAgilityPack;

namespace TimeZoneCalculator
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public string TimeZone(string city)
        {
            try
            {
                city = city + " ";
                string[] cityName = new string[2];
                cityName = city.Split(' ');
                city = cityName[0] + cityName[1];                         //string 
                string[] time = new string[10];
                string[] date = new string[10];
                HtmlWeb htmlpage = new HtmlWeb();                           // creates a new html web page
                string url = "http://www.timeanddate.com/worldclock/usa/" + city; // the url used to access the service and appends the city to the url
                HtmlDocument doc = htmlpage.Load(url);                            // loads thr url
                HtmlNodeCollection itemList1 = doc.DocumentNode.SelectNodes("//small"); // parses the html to access the speified nodes
                foreach (HtmlNode node1 in itemList1)   
                {
                    date[0] = node1.InnerText;    //gets the time zone and stores as a string
                }
                return date[0];
            }
            catch
            {
                return "invalid city";
            }
            
        }
    }
}
