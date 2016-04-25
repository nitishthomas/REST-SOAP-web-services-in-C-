using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using HtmlAgilityPack;

namespace ApartmentFinder
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



        public string[] apartment(string zipcode)
        {
            string[] ApartmentList = new string[50];
            try
            {
                string[] apartmentName = new string[50];
                string[] apartmentAddress = new string[50];
                int i = 0;
                int j = 0;
                HtmlWeb htmlpage = new HtmlWeb();      //creates a html document 
                string url = "http://www.yelp.com/search?find_desc=apartments&find_loc=" + zipcode; // url that is used to access the service is appended with the zipcode
                HtmlDocument doc = htmlpage.Load(url);                      // loads the given url's html page
                HtmlNodeCollection itemList = doc.DocumentNode.SelectNodes("//a[@class='biz-name']"); //selects the apartment name node from the given class atribute
                HtmlNodeCollection itemList1 = doc.DocumentNode.SelectNodes("//address");             //selects the address node from the document
                foreach (HtmlNode node in itemList)
                {
                    apartmentName[i] = node.InnerText;  // stores apartment name in an array
                    i++;
                }
                foreach (HtmlNode node2 in itemList1)
                { 
                    apartmentAddress[j] = node2.InnerText; // stores apartment addresses in ana array
                    j++;
                }                
                Array.Copy(apartmentName, ApartmentList, 10);   // adds apartment addresses to first 10 array index in a new array
                Array.Copy(apartmentAddress, 0, ApartmentList, 10, 10); //adds the apartment address in next 10 indexes
                return ApartmentList;  //returns the appended array
            }
            catch (Exception)
            {
                ApartmentList[0] = "Invalid zipcode";
                return ApartmentList;
            }
        }
    }
}
