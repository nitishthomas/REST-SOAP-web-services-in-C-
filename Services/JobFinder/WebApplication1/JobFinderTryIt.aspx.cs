using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.ServiceReference1;

namespace WebApplication1
{
    public partial class JobFinderTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Service1Client x = new Service1Client();
            string one = TextBox1.Text;
            string two = TextBox2.Text;

            string[] urls = x.JobFinder(one, two);
            int len = urls.Length;

            int m = 0;

            ListBox1.Items.Clear();
            while(m<len)
            {
                ListBox1.Items.Add(urls[m]);
                m++;
            }
            
        }
    }
}