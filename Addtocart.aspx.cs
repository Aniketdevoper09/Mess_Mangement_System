using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Addtocart : System.Web.UI.Page
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

                getedata();
            
        }
    }
    private void getedata()
    {
        try
        {
            if (Session["cartitem"] != null)
            {
                if (Session["cartitem"] != null)
                {
                    DataTable dt = (DataTable)Session["cartitem"];
                    if (dt.Rows.Count > 0)
                    {
                        Repeater1.DataSource = dt;
                        Repeater1.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            messageBox(ex.Message);
        }
        
    }




    protected void btnPlus_Click(object sender, EventArgs e)
    {
        // Increment the quantity and recalculate total price
        UpdateQuantityAndCalculateTotalPrice((Control)sender, 1);
    }

    protected void btnMinus_Click(object sender, EventArgs e)
    {
        UpdateQuantityAndCalculateTotalPrice((Control)sender, -1);
    }

    private void UpdateQuantityAndCalculateTotalPrice(Control sender, int change)
    {
        try
        {
            // Get the reference to the TextBox control
            TextBox textBox = (TextBox)sender.Parent.FindControl("txtQuantity");

            // Increment or decrement the quantity if greater than 1
            int quantity = int.Parse(textBox.Text) + change;
            if (quantity >= 1)
            {
                textBox.Text = quantity.ToString();

                // Recalculate total price
               // CalculateTotalPrice();
            }
        }
        catch (Exception ex)
        {
            messageBox(ex.Message);
        }
    }
}