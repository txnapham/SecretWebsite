using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class RegisteredTenants : System.Web.UI.Page
{
    System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AccountId"] != null && Convert.ToInt16(Session["type"]) == 1)
        {

        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //Update Background Status Query
        System.Data.SqlClient.SqlCommand update = new System.Data.SqlClient.SqlCommand();
        update.CommandText = "UPDATE Tenant SET BackgroundCheckStatus =@BackStatus WHERE TenantID =@TenantID;";
        //Connection
        update.Connection = sc;
        sc.Open();

        if (lblCompletedBC.Text == "Completed")
        {
            update.Parameters.AddWithValue("@BackStatus", 1);
            lblCompletedBC.Text = "Completed";
        }
        else
        {
            update.Parameters.AddWithValue("@BackStatus", 0);
            lblCompletedBC.Text = "Incomplete";
        }

        //Execute Query 
        update.ExecuteNonQuery();
        sc.Close();
        //Reader for Background Status Query 
        


    }
}