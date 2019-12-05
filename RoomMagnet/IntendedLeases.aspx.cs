using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IntendedLeases : System.Web.UI.Page
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
        //Only Host Can View 
        if (Session["AccountId"] != null && Convert.ToInt16(Session["type"]) == 1)
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["roommagnetdbConnectionString"].ToString());

            System.Data.SqlClient.SqlCommand selectLeases = new System.Data.SqlClient.SqlCommand();
            selectLeases.Connection = sc;

            sc.Open();

            //Intented Lease: Hosts and Tenants
            selectLeases.CommandText = "SELECT TOP(5) A.FirstName as hostF, A.LastName as hostL, B.FirstName as tenantF, B.LastName as tenantL " +
                "FROM Account A, Account B " +
                "WHERE A.AccountID in (select hostID from Host where hostID in (select HostID from lease where Agreed = '1')) " +
                "AND B.AccountID in (select tenantId from Tenant where tenantID in (select tenantID from lease where Agreed = '1'))";

            StringBuilder nameCard = new StringBuilder();
            System.Data.SqlClient.SqlDataReader reader = selectLeases.ExecuteReader();

            while (reader.Read())
            {
                String hostFName = reader["hostF"].ToString();
                String hostLName = reader["hostL"].ToString();
                String tenantFName = reader["tenantF"].ToString();
                String tenantLName = reader["tenantL"].ToString();

                //StringBuilder
                StringBuilder myCard = new StringBuilder();
                myCard.Append("<tr><td><a href =\"#\" class=\"tenantdashlist\">" + "Host: " + hostFName + " " + hostLName + "</a></td>" +
                    "<td><a href =\"#\" class=\"tenantdashlist\">" + "Tenant: " + tenantFName + " " + tenantLName + "</a></td></tr>");

                IntLease.Text += myCard.ToString();
            }
            reader.Close();
            sc.Close();
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }
}