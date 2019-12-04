using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.Data.SqlClient;

public partial class AdminDashboard : System.Web.UI.Page
{
    //sc Connection
    System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["roommagnetdbConnectionString"].ToString());
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
            //Select Statement for Host and Tenant to Populate on Dash
            System.Data.SqlClient.SqlCommand selectUserName = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand selectHost = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand selectTenant = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand selectIntendedLease = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand selectUsers = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand selectLeases = new System.Data.SqlClient.SqlCommand();

            //Connections
            selectUserName.Connection = sc;
            selectHost.Connection = sc;
            selectTenant.Connection = sc;
            selectIntendedLease.Connection = sc;
            selectUsers.Connection = sc;
            selectLeases.Connection = sc;
            sc.Open();

            //User Name Select
            selectUserName.CommandText = "SELECT FirstName FROM Account WHERE AccountID = " + Session["AccountId"] + ";";

            //Host Select
            selectHost.CommandText = "SELECT TOP(5) FirstName, LastName FROM Account WHERE (AccountType = 2);";

            //Tenant Select 
            selectTenant.CommandText = "SELECT TOP(5) FirstName, LastName FROM Account WHERE (AccountType = 3);";

            //Intented Lease: Hosts and Tenants
            selectIntendedLease.CommandText = "SELECT TOP(5) A.FirstName as hostF, A.LastName as hostL, B.FirstName as tenantF, B.LastName as tenantL " +
                "FROM Account A, Account B " +
                "WHERE A.AccountID in (select hostID from Host where hostID in (select HostID from lease where Agreed = '1')) " +
                "AND B.AccountID in (select tenantId from Tenant where tenantID in (select tenantID from lease where Agreed = '1'))";

            //Select Number of Users 
            selectUsers.CommandText = "SELECT COUNT(*) FROM Account;";
            int userCount = (int)selectUsers.ExecuteScalar();

            //Number of Leases
            selectLeases.CommandText = "SELECT COUNT(*) FROM Lease;";
            int leaseCount = (int)selectLeases.ExecuteScalar();

            //Populate Dashboard with Admin Name
            string userName = selectUserName.ExecuteScalar().ToString();

            //StringBuilder
            StringBuilder nameCard = new StringBuilder();
            nameCard.Append("<a href =\"#\" class=\"tenantdashlist\">" + "Welcome, " + userName + "</a>");
            UserNameCard.Text += nameCard.ToString();

            //Populate Dashboard with Host Info 
            System.Data.SqlClient.SqlDataReader reader = selectHost.ExecuteReader();
            while (reader.Read())
            {
                String firstName = reader["FirstName"].ToString();
                String lastName = reader["LastName"].ToString();
                //StringBuilder
                StringBuilder myCard = new StringBuilder();
                myCard.Append("<li><a href =\"#\" class=\"tenantdashlist\">" + firstName + " " + lastName + "</a></li>");
                RegHost.Text += myCard.ToString();
            }
            reader.Close();

            //Populate Dashboard with Tenant Info 
            System.Data.SqlClient.SqlDataReader rdr = selectTenant.ExecuteReader();
            while (rdr.Read())
            {
                String firstName = rdr["FirstName"].ToString();
                String lastName = rdr["LastName"].ToString();
                //StringBuilder
                StringBuilder myCard2 = new StringBuilder();
                myCard2.Append("<li><a href =\"#\" class=\"tenantdashlist\">" + firstName + " " + lastName + "</a></li>");
                RegTenant.Text += myCard2.ToString();
            }
            rdr.Close();

            //Reader to select intended leases
            System.Data.SqlClient.SqlDataReader intLeaseRdr = selectIntendedLease.ExecuteReader();
            while (intLeaseRdr.Read())
            {
                String hostFName = intLeaseRdr["hostF"].ToString();
                String hostLName = intLeaseRdr["hostL"].ToString();
                String tenantFName = intLeaseRdr["tenantF"].ToString();
                String tenantLName = intLeaseRdr["tenantL"].ToString();

                //StringBuilder
                StringBuilder myCard3 = new StringBuilder();
                myCard3.Append("<li><a href =\"#\" class=\"tenantdashlist\">" + "Host: " + hostFName + " " + hostLName + ", Tenant: " + tenantFName + " " + tenantLName);
                IntLease.Text += myCard3.ToString();
            }
            intLeaseRdr.Close();
            sc.Close();

            //StringBuilder for Amount of Users
            StringBuilder myCard4 = new StringBuilder();
            myCard4.Append("<li><a href =\"#\" class=\"tenantdashlist\">" + "Number of Users: " + userCount + "</a></li>");
            UserCount.Text += myCard4.ToString();


            //StringBuilder
            StringBuilder myCard5 = new StringBuilder();
            myCard5.Append("<li><a href =\"#\" class=\"tenantdashlist\">" + "Number of Leases: " + leaseCount + "</a></li>");
            LeaseCount.Text += myCard5.ToString();
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }

    protected void btnCreateAdmin_Click(object sender, EventArgs e)
    {
        //SQL Statements
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        System.Data.SqlClient.SqlCommand checkEmailCount = new System.Data.SqlClient.SqlCommand();
        //Connection
        sc.ConnectionString = "server=aawnyfad9tm1sf.cqpnea2xsqc1.us-east-1.rds.amazonaws.com; database =roommagnetdb;uid=admin;password=Skylinejmu2019;";
        //Check email to see if what was entered is in database
        checkEmailCount.Parameters.Add(new SqlParameter("@email", HttpUtility.HtmlEncode(txtEmail.Text)));
        checkEmailCount.CommandText = "SELECT COUNT(*) FROM ACCOUNT WHERE EMAIL = @email";
        checkEmailCount.Connection = sc;
        sc.Open();

        int emailCount = (int)checkEmailCount.ExecuteScalar();

        if(emailCount < 1)
        {
            //SQL Insert Statement
            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.Connection = sc;
            //SQL Inserting new admin name, email, password into database
            insert.CommandText = "INSERT into Account VALUES (@fName, NULL, @lName, NULL, NULL, @email, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, '" + DateTime.Now + "', 1); " +
                    "INSERT into Admin VALUES(@@Identity);" +
                    "INSERT into Password VALUES((SELECT MAX(AdminID) from Admin), @email, @password);";

            insert.Parameters.Add(new SqlParameter("@fName", HttpUtility.HtmlEncode(txtFN.Text)));
            insert.Parameters.Add(new SqlParameter("@lName", HttpUtility.HtmlEncode(txtLN.Text)));
            insert.Parameters.Add(new SqlParameter("@email", HttpUtility.HtmlEncode(txtEmail.Text)));
            insert.Parameters.Add(new SqlParameter("@password", PasswordHash.HashPassword(HttpUtility.HtmlEncode(txtPassword.Text))));
            //Execute and Close SQL 
            insert.ExecuteNonQuery();
            sc.Close();
            //Clearing fields back out
            txtFN.Text = "";
            txtLN.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
        }
        else
        {
            sc.Close();
        }
    }
}