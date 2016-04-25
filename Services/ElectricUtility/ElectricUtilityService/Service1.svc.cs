using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using System.Net;


namespace ElectricUtilityService
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

        public static string a, latitude, longitude;
        public string ElectricUtility(string latitude, string longitude)
        {
            try
            {


                String URL = "http://developer.nrel.gov/api/utility_rates/v3.xml?api_key=DzywHjIBxgOoGUkCsdgU8Fxj7aoEHacU8K1lgaRE";  // URL that is used to access the web service

                String mainURL = URL + "&lat=" + latitude + "&lon=-" + longitude;                        // concating the url with latitude and longitude
                String result = "";
                WebRequest httprequest = WebRequest.Create(mainURL);        
                httprequest.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)httprequest.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                XmlDocument d = new XmlDocument();                                      // Creates new xml document
                d.LoadXml(reader.ReadToEnd());                                              // Reads the document
                XmlNodeList xmlNodeList = d.SelectNodes("/response/outputs/residential");        // electric utility node is selected
                XmlNode c = xmlNodeList[0];                                                      //takes first node that contains the value
                result = c.InnerText;                                                           // value is stored as a string
                return result;
            }
            catch
            {
                return " Invalid input";
            }


        }
    }
}