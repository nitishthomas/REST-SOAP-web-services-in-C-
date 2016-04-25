using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.IO;
using System.Xml;
using System.Net.Http;

namespace UniversalLocatorAppTryIt
{
    public partial class TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            HttpClient obj = new HttpClient();

            string zip = TextBox1.Text;
            string type = TextBox2.Text;

            string url = @"http://localhost:62539/Service1.svc/unilocator?zipcode=" + zip + "&type=" + type;

            Task<string> result = obj.GetStringAsync(url);

            string x = await result;

            string[] ret = new string[20];

            string[] f = new string[20];

            string[] printable = new string[20];
            string[] printable2 = new string[20];
            string[] printable3 = new string[20];
            string[] printable4 = new string[20];

            ret = x.Split('>');

            f = ret[2].Split('<');

            printable = ret[4].Split('<');
            printable2 = ret[6].Split('<');
            printable3 = ret[8].Split('<');
            printable4 = ret[10].Split('<');

            XmlDocument parser = new XmlDocument();

            parser.LoadXml(x);

            XmlNodeList locationElements = parser.SelectNodes("string");

            int i = 1;
            
            ListBox1.Items.Clear();

            ListBox1.Items.Add(f[0]);
            ListBox1.Items.Add(printable[0]);
            ListBox1.Items.Add(printable2[0]);
            ListBox1.Items.Add(printable3[0]);
            ListBox1.Items.Add(printable4[0]);
            
           
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ListBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
}