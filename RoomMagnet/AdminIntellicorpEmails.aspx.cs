using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminIntellicorpEmails : System.Web.UI.Page
{
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
        if (Session["AccountId"] != null && Convert.ToInt16(Session["type"]) == 1)
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["roommagnetdbConnectionString"].ToString());

            System.Data.SqlClient.SqlCommand selectEmail = new System.Data.SqlClient.SqlCommand();
            selectEmail.Connection = sc;

            sc.Open();

            intellicorpEmail.Text = String.Empty;

            //Populate Emails
            selectEmail.CommandText = "SELECT Account.FirstName, Account.LastName, Account.Email " +
                "FROM Account FULL OUTER JOIN Host ON Account.AccountID = Host.HostID FULL OUTER JOIN Tenant ON Account.AccountID = Tenant.TenantID " +
                "WHERE Host.BackgroundCheckStatus = 0 OR Tenant.BackgroundCheckStatus = 0";


            StringBuilder nameCard = new StringBuilder();
            System.Data.SqlClient.SqlDataReader reader = selectEmail.ExecuteReader();

            while (reader.Read())
            {
                String fName = reader["FirstName"].ToString();
                String lName = reader["LastName"].ToString();
                String email = reader["Email"].ToString();

                //StringBuilder
                StringBuilder myCard = new StringBuilder();
                myCard.Append("<tr><td><a href =\"#\" class=\"tenantdashlist\">" + "Name: " + fName + " " + lName + "</a></td>" +
                    "<td><a href =\"#\" class=\"tenantdashlist\">" + "Email: " + email + "</a></td></tr>");
                intellicorpEmail.Text += myCard.ToString();
            }
            reader.Close();
            sc.Close();
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }
    protected void btnChange_Click(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["roommagnetdbConnectionString"].ToString());

        System.Data.SqlClient.SqlCommand selectEmail = new System.Data.SqlClient.SqlCommand();
        selectEmail.Connection = sc;

        sc.Open();

        //Populate Emails
        selectEmail.CommandText = "UPDATE Tenant SET BackgroundCheckStatus = 1 WHERE BackgroundCheckStatus = 0; " +
            "UPDATE Host SET BackgroundCheckStatus = 1 WHERE BackgroundCheckStatus = 0;";
        selectEmail.ExecuteNonQuery();
        Page_Load(sender, e);
    }
}