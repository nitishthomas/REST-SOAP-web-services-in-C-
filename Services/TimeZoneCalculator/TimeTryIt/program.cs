using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml;
using System.Net.Http;

namespace TimeTryIt
{
    public class program
    {

        public async Task<string> get(string a)
        {
            HttpClient client = new HttpClient();
            string url = @"http://localhost:55031/Service1.svc/city=" + a;
            Task<string> result = client.GetStringAsync(url);
            string x = await result;
            return x;
            
        }
    }
}