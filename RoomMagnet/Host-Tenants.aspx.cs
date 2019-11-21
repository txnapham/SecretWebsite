using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Host_Tenants : System.Web.UI.Page
{
    System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ToString());

    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["type"] != null)
        {
            if ((int)Session["type"] == 1)
            {
                this.MasterPageFile = "~/AdminPage.master";
            }
            else if ((int)Session["type"] == 2)
            {
                this.MasterPageFile = "~/HostPage.master";
            }
            else if ((int)Session["type"] == 3)
            {
                this.MasterPageFile = "~/TenantPage.master";
            }
        }
        else if (Session["type"] == null)
        {
            this.MasterPageFile = "~/MasterPage.master";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["AccountId"] != null && Convert.ToInt16(Session["type"]) == 2)
        {
            int accountID = Convert.ToInt16(HttpContext.Current.Session["AccountId"].ToString());

            //Select Statements properties
            System.Data.SqlClient.SqlCommand selectHost = new System.Data.SqlClient.SqlCommand();
            selectHost.CommandText = "SELECT FirstName, AccountImage FROM Account WHERE AccountID = " + accountID + ";";
            //Connections
            selectHost.Connection = sc;
            sc.Open();

            //Populating Tenant Part of Host Dashboard
            System.Data.SqlClient.SqlDataReader readerHostImage = selectHost.ExecuteReader();
            while (readerHostImage.Read())
            {
                String tenantName = readerHostImage["FirstName"].ToString();
                String filename = readerHostImage["AccountImage"].ToString();
                // No image uploaded (currently default image in S3)
                if (filename == "") filename = "noprofileimage.png";
                // User dashboard dynamically updated using S3
                StringBuilder hostImage = new StringBuilder();
                hostImage
                .Append("<img alt=\"image\" src=\"https://duvjxbgjpi3nt.cloudfront.net/UserImages/" + filename + "\" class=\" rounded-circle img-fluid\" width=\"30%\" height=\"auto\">");
                HostCard.Text += hostImage.ToString();
            }
            sc.Close();
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }
}