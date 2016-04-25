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

namespace UniversalLocatorApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        static string a;

        public string[] unilocator(string zipcode, string type)
        {
            string url = "http://maps.googleapis.com/maps/api/geocode/xml?address=" + zipcode;  // API that woud return latitude and longitude coordinates based upon the entered zipcode
            XmlDocument d1 = MakeRequest(url);
            string f = ProcessResponse1(d1);
            string urlrequest = "https://maps.googleapis.com/maps/api/place/nearbysearch/xml?location=" + a + "&radius=32187&types=" + type + "&key=AIzaSyBXYtS6Cf7IMdkhrDXCbeFkuh3dTnfeeAs";
            XmlDocument d = MakeRequest(urlrequest);
            string[] e = ProcessResponse(d);
            return e;
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

        static public string[] ProcessResponse(XmlDocument locationsResponse)
        {
            string[] ret = new string[100];

            XmlNodeList locationElements = locationsResponse.SelectNodes("PlaceSearchResponse/result");
            XmlNodeList locationElement = locationsResponse.SelectNodes("PlaceSearchResponse");

            int i = 0;
            int j = 0;

            foreach (XmlNode result in locationElements) //Block to return the result found
            {

                ret[i] = result.SelectSingleNode("name").InnerText + "," + result.SelectSingleNode("vicinity").InnerText;
                //break;
                i++;

            }

            foreach (XmlNode calc in locationElement) //Block to check if no results were found
            {
                if (calc.SelectSingleNode("status").InnerText == "ZERO_RESULTS")
                {
                    ret[j] = "Error, no such place found within 20 miles";
                    //break;
                    j++;
                }
            }

            return ret;
        }

        static public string ProcessResponse1(XmlDocument locationResponse)
        {
            string b;
            XmlNodeList location = locationResponse.SelectNodes("GeocodeResponse/result/geometry/location");
            try
            {
                foreach (XmlNode result in location)
                {

                    //Selecting the lat, lng tags from the received XML document
                    a = (result.SelectSingleNode("lat").InnerText);
                    b = (result.SelectSingleNode("lng").InnerText);

                    a += ",";
                    a += b;
                    break;
                }
                return a;
            }
            catch
            {
                a = "No store found";
                return a;
            }
        }
    }
}

