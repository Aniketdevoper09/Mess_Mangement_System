using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class viewcategory : System.Web.UI.Page
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
            getedata();
        }
    }
    private void getedata()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from AddBrand", con);
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



    string Id, image, brandname, price;
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Add To Cart")
            {
                Id = e.CommandArgument.ToString();
                GetProDetail();

                if (Context.Session["cartitem"] == null)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.AddRange(new DataColumn[4] {
                new DataColumn("Id"),
                new DataColumn("Image"),
                new DataColumn("ProductName"),
                new DataColumn("Price")



            });
                    dt.Rows.Add(Id, image, brandname, price);
                    Context.Session["cartitem"] = dt;
                }
                else
                {
                    DataTable dt = (DataTable)Context.Session["cartitem"];

                    bool itemExists = false;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["ProductName"].ToString() == brandname && row["Price"].ToString() == price && row["Image"].ToString()== image)
                        {
                            itemExists = true;
                            break;
                        }
                    }

                    if (!itemExists)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["Id"] = Id;
                        newRow["Image"] = image;
                        newRow["ProductName"] = brandname; // Fixed the column name


                        //newRow["Qnty"] = qnty;
                        newRow["Price"] = price;
                        dt.Rows.Add(newRow);
                        Context.Session["cartitem"] = dt;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            messageBox(ex.Message);
        }
    }

    public void GetProDetail()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("Select * from AddBrand WHERE Id=@Id", con);
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                brandname = dt.Rows[0]["ProductName"].ToString();
                price = dt.Rows[0]["Price"].ToString();
               // qnty = dt.Rows[0]["Qnty"].ToString();
                image = dt.Rows[0]["Image"].ToString();
            }
        }
        catch (Exception ex)
        {
            messageBox(ex.Message);
        }
    }
}