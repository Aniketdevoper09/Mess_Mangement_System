using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Home : System.Web.UI.MasterPage
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-LISP7GJ;Initial Catalog=Clothing;Integrated Security=True");
    private void messageBox(string sms)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "Showalert", "alert('" + sms + "')", true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if(Session["cartitem"] != null)
                {
                    DataTable dt = (DataTable)Session["cartitem"];
                    if (dt.Rows.Count>0)
                    {
                        lblCartCount.Text = dt.Rows.Count.ToString();
                    }
                    else
                    {
                        lblCartCount.Text = 0.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                messageBox("Error" + ex.Message);
            }

            BindGrid();
        }
    }

    public void BindGrid()
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Addp", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                CategoryRepeater.DataSource = dt;
                CategoryRepeater.DataBind();

            }
            else
            {
                CategoryRepeater.DataSource = null;
                CategoryRepeater.DataBind();

            }
        }
        catch (Exception ex)
        {
            messageBox(ex.Message);
        }
    }
    protected void CategoryRepeater_ItemDataBound1(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView rowView = (DataRowView)e.Item.DataItem;
            string subcatname = rowView["Category"].ToString();
            Repeater rptSub = (Repeater)e.Item.FindControl("rptSub");
            BindSubCategories(subcatname, rptSub);
        }
    }

    private void BindSubCategories(string subcatname, Repeater rptSub)
    {
        try
        {
            con.Open(); 

            SqlCommand cmd = new SqlCommand("SELECT * FROM subcateg WHERE Category = @Category", con);
            cmd.Parameters.AddWithValue("@Category", subcatname);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                rptSub.DataSource = dt;
                rptSub.DataBind();
            }
            else
            {
                rptSub.DataSource = null;
                rptSub.DataBind();
            }
        }
        catch (Exception ex)
        {
            messageBox("Failed: " + ex.Message);
        }
        finally
        {
            con.Close(); 
        }
    }

   
}


