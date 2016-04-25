using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ApartmentService.Service1Client obj = new ApartmentService.Service1Client(); //creates a proxy to access the service
            string[] apartment = obj.apartment(TextBox1.Text);  //gets the array of apartments
            TextBox2.Text = apartment[0];                       //stores apartment name in text box
            TextBox2.Text += apartment[10];                     // stores the aparement address in the textbox 
            TextBox3.Text = apartment[1];
            TextBox3.Text += apartment[11];
            TextBox4.Text = apartment[2];
            TextBox4.Text += apartment[12];
            TextBox5.Text = apartment[3];
            TextBox5.Text += apartment[13];
            TextBox6.Text = apartment[4];
            TextBox6.Text += apartment[14];
            TextBox7.Text = apartment[5];
            TextBox7.Text += apartment[15];
            TextBox8.Text = apartment[6];
            TextBox8.Text += apartment[16];
            TextBox9.Text = apartment[7];
            TextBox9.Text += apartment[17];
            TextBox10.Text = apartment[8];
            TextBox10.Text += apartment[18];

        }

        protected void TextBox10_TextChanged(object sender, EventArgs e)
        {

        }
    }
}