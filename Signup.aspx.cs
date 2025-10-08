using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Signup : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-LISP7GJ;Initial Catalog=Clothing;Integrated Security=True");
    private void messageBox(string sms)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "Showalert", "alert('" + sms + "')", true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                messageBox("Enter UserName");
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                messageBox("Enter EmailId");
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                messageBox("Enter Password");
            }
            else if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                messageBox("Enter ConfirmPassword");
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                messageBox("Password does not match");
            }
            else if (!FileUpload1.HasFile)
            {
                messageBox("Please select a Profile Picture");
            }
            else
            {
                if (FileUpload1.HasFile)
                {

                    string str = FileUpload1.FileName;
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Photo/" + str));
                    string Image = "~/Photo/" + str.ToString();
                    SqlCommand cmd = new SqlCommand("insert into Signup (UserName,Email,Password,ConformPassword,Photo) values (@UserName,@Email,@Password,@ConformPassword,@Photo)", con);
                    cmd.Parameters.AddWithValue("@UserName", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@ConformPassword", txtConfirmPassword.Text);
                    cmd.Parameters.AddWithValue("@Photo", Image);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    messageBox("Signup Successfully!");
                    txtUsername.Text = "";
                    txtEmail.Text = "";
                  
                   

                }
            }

        }
        catch (Exception ex)
        {
            messageBox("Error" + ex.Message);
        }
    }
}