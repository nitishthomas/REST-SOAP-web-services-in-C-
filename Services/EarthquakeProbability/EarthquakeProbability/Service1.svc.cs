using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using System.Net;


namespace EarthquakeProbability
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.


    public class Service1 : IService1
    {
        static string a;

        public string ProbFinder(string city, string state)
        {
            string url = "http://api.openhazards.com/GetEarthquakeProbability?q=" + city + ",+" + state;  // API that woud return latitude and longitude coordinates based upon the entered zipcode
            XmlDocument d1 = MakeRequest(url);
            string f = ProcessResponse(d1);
            return f;
        }

        public XmlDocument MakeRequest(string requesturl)
        {
            {
                HttpWebRequest request = WebRequest.Create(requesturl) as HttpWebRequest;

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
                return (xmlDoc);
            }
        }

        static public string ProcessResponse(XmlDocument locationsResponse)
        {
            //string a;
            XmlNodeList locationElements = locationsResponse.SelectNodes("xmlresponse/forecast");
            XmlNodeList locationElements1 = locationsResponse.SelectNodes("xmlresponse/error");

            try
            {
                foreach (XmlNode result in locationElements) //Block to return the result found
                {

                    a = "An earthquake of a probable magnitude of " + result.SelectSingleNode("mag").InnerText + " has a probability of " + result.SelectSingleNode("prob").InnerText + " and a rate of " + result.SelectSingleNode("rate").InnerText + " to occur in this region in the next 365 days ";

                    break;
                }
            }
            catch
            {
                a = "No data found";
            }
            foreach (XmlNode calc in locationElements1) //Block to check if no results were found
            {
                try
                {
                    if (calc.SelectSingleNode("error").InnerText == "1")
                    {
                        a = "No data for the entered place is detected";
                    }
                }
                catch
                {
                    a = "No data found";
                }
            }

            return a;
        }
    }
}