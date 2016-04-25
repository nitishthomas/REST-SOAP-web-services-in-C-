using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ElectricUtility.Service1Client obj = new ElectricUtility.Service1Client(); //creating  proxy to access the client
            String latitude = TextBox1.Text;
            String longitude = TextBox2.Text;
            Label1.Text = obj.ElectricUtility(latitude, longitude); // gets the electric utility value and displays it in the label
            Label1.Visible = true;
        }
    }
}