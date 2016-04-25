using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace UniversalLocatorApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]

        [WebGet(UriTemplate = "/unilocator?zipcode={zipcode}&type={type}")] 
        
        string[] unilocator(string zipcode, string type);

        

        // TODO: Add your service operations here
    }

}