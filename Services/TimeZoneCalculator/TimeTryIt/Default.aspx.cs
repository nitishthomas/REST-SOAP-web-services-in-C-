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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
   

        public async void Button1_Click(object sender, EventArgs e)
        {
                     
            HttpClient client = new HttpClient();         // creates an http client object
            string url = @"http://localhost:55031/Service1.svc/city=" + TextBox2.Text;    //concatenates the URL with the city         
            Task<string> result = client.GetStringAsync(url);  //get request is sent to the URI and the response is returned in a string
            string x = await result;                            //waits till the process completes and the string is got
            string[] a = x.Split('>');
            string[] b = a[1].Split('<');
            string c = b[0];                                    // stores the result in a string and displays
            Label1.Text = c;
            Label1.Visible = true;
       }
    }
}