using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-LISP7GJ;Initial Catalog=Clothing;Integrated Security=True");
    private void messageBox(string sms)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "Showalert", "alert('" + sms + "')", true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtUsername.Text == "")
        {
            messageBox("Enter Email");
        }
        else if (txtPassword.Text == "")
        {
            messageBox("Enter Password");
        }
       
        else
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Signup WHERE Email=@Email AND ConformPassword=@ConformPassword ", con);
           
            cmd.Parameters.AddWithValue("@Email", txtUsername.Text);
            cmd.Parameters.AddWithValue("@ConformPassword", txtPassword.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            string Name = dt.Rows[0]["UserName"].ToString();
            string Photo = dt.Rows[0]["Photo"].ToString();


            if (dt.Rows.Count > 0)
            {
                messageBox("Login Successful");
                txtUsername.Text = "";
                Session["UserName"] = Name;
                Session["Photo"] = Photo;

                Response.Redirect("~/Admin/Admin.aspx");
            }
            else
            {
                messageBox("Invalid Username Password");
            }
        }


    }
   

   
}
