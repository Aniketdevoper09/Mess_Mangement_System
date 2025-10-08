using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Contact : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-LISP7GJ;Initial Catalog=Clothing;Integrated Security=True");
    private void messageBox(string sms)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "Showalert", "alert('" + sms + "')", true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

   
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("insert into Contact(Name,Email,Mobile,Message,Status) values (@Name,@Email,@Mobile,@Message,@Status)", con);
            cmd.Parameters.AddWithValue("@Name", TextBox1.Text);
            cmd.Parameters.AddWithValue("@Email", TextBox3.Text);
            cmd.Parameters.AddWithValue("@Mobile", TextBox2.Text);
            cmd.Parameters.AddWithValue("@Message", TextBox4.Text);
            cmd.Parameters.AddWithValue("@Status", "Pending");
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                messageBox("Send Message Successfull!");
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
            }
        }
        catch (Exception ex)
        {
            messageBox("Error" + ex.Message);
        }
    }
}