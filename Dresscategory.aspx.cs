using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class Dresscategory : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-LISP7GJ;Initial Catalog=Clothing;Integrated Security=True");
    private void messageBox(string sms)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "Showalert", "alert('" + sms + "')", true);
    }
    string Pid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                Pid = Request.QueryString["Id"].ToString();
                getedata();
            }
        }
    }
    private void getedata()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from AddBrand where Category='" + Pid + "'", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
        else
        {
            Repeater1.DataSource = null;
            Repeater1.DataBind();
        }
    }


    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}