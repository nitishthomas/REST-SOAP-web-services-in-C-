using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EarthquakeProbabilityTryIt.ServiceReference1;

namespace EarthquakeProbabilityTryIt
{
    public partial class TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Service1Client ip = new Service1Client();
            string t1 = TextBox1.Text;
            string t2 = TextBox2.Text;
            string d = ip.ProbFinder(t1, t2);
            Label4.Text = d;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}