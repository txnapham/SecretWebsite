using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HostDashboard : System.Web.UI.Page
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
        Card.Text = String.Empty;
        Card2.Text = String.Empty;
        Card3.Text = String.Empty;

        if (string.IsNullOrEmpty(HttpContext.Current.Session["AccountId"].ToString()))
        {
        }
        else
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
                if (filename == "") filename = "defaulttenantimg.jpg";
                // User dashboard dynamically updated using S3
                StringBuilder hostImage = new StringBuilder();
                hostImage
                .Append("<img alt=\"image\" src=\"https://duvjxbgjpi3nt.cloudfront.net/UserImages/" + filename + "\" class=\" rounded-circle img-fluid\" width=\"30%\" height=\"auto\">")
                .Append("                Welcome " + tenantName + "!");
                HostCard.Text += hostImage.ToString();
            }
            sc.Close();


            //Select Statements for tenant and properties
            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand selectProp = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand favoriteTenant = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand tenantDash = new System.Data.SqlClient.SqlCommand();
            //Tenant Select
            select.CommandText = "SELECT FirstName,LastName FROM Account WHERE AccountID in " +
            "(SELECT TOP(5) tenantID FROM Lease WHERE HostID = " + accountID + ");";
            //Property Select
            selectProp.CommandText = "SELECT HouseNumber, Street FROM Property WHERE PropertyID in (SELECT propertyID FROM Property WHERE HostID = " + accountID + ");";
            //Message Center Tenant Populating once they favorite the current host's room
            favoriteTenant.CommandText = "select firstName, LastName,AccountID,BirthDate from account where AccountID in (select tenantID from tenant where TenantID in " +
                "(select tenantID from FavoritedProperties where PropertyID in (select PropertyID from property where hostID =" + accountID + ")));";
            //Select statement to get fsvorite tenantID to check if they exist already
            tenantDash.CommandText = "select accountID from account where AccountID in (select tenantID from Tenant where TenantID in (select tenantID from " +
                "FavoritedTenants where HostID =" + accountID + "));";
            //Connections
            select.Connection = sc;
            selectProp.Connection = sc;
            favoriteTenant.Connection = sc;
            tenantDash.Connection = sc;
            sc.Open();

            //Store tenantID for if statement
            List<int> tenantList = new List<int>(); 
            System.Data.SqlClient.SqlDataReader sqlDataReader = tenantDash.ExecuteReader();
            while(sqlDataReader.Read())
            {
                tenantList.Add(Convert.ToInt16(sqlDataReader["AccountID"].ToString()));
            }
            sqlDataReader.Close();
            //Populating Tenant Part of Host Dashboard
            System.Data.SqlClient.SqlDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                String firstName = reader["FirstName"].ToString();
                String lastName = reader["LastName"].ToString();

                StringBuilder myCard = new StringBuilder();
                myCard
                .Append("<li><a href=\"PropertyDetails.aspx\" class=\"tenantdashlist\">" + firstName + " " + lastName + "</a></li>");
                Card.Text += myCard.ToString();
            }
            reader.Close();
            //Populating Property Part of Host Dashboard
            System.Data.SqlClient.SqlDataReader rdr = selectProp.ExecuteReader();
            while (rdr.Read())
            {
                String HouseNum = rdr["HouseNumber"].ToString();
                String Street = rdr["Street"].ToString();

                StringBuilder myCard2 = new StringBuilder();
                myCard2
                .Append("<li><a href=\"#\" class=\"tenantdashlist\">" + HouseNum + " " + Street + "</a></li>");
                Card2.Text += myCard2.ToString();
            }
            rdr.Close();
            //Populating Message Center Matches
            System.Data.SqlClient.SqlDataReader drd = favoriteTenant.ExecuteReader();
            int count = 0;
            while (drd.Read())
            {
                String firstName = drd["FirstName"].ToString();
                String lastName = drd["LastName"].ToString();
                int tenantID = Convert.ToInt16(drd["AccountID"].ToString());
                String bday = drd["BirthDate"].ToString();

                //Get Age
                DateTime birthDay = Convert.ToDateTime(bday);
                DateTime current = DateTime.Now;
                int age = new DateTime(DateTime.Now.Subtract(birthDay).Ticks).Year - 1;
                DateTime past = birthDay.AddYears(age);
                int months = 0;
                for (int i = 1; i <= 12; i++)
                {
                    if (past.AddMonths(i) == current)
                    {
                        months = i;
                        break;
                    }
                    else if (past.AddMonths(i) >= current)
                    {
                        months = i - 1;
                        break;
                    }
                }
                int days = current.Subtract(past.AddMonths(months)).Days;
                int hours = current.Subtract(past).Hours;

                if (!tenantList.Contains(tenantID))
                {
                    StringBuilder myCard = new StringBuilder();
                    myCard
                        .Append("<div class=\"chat-list\">")
                        .Append("           <div class=\"chat-people\">")
                        .Append("               <div class=\"chat-img\"> <img src = \"images/rebeccajames.png\" class=\"rounded-circle img-fluid\"></div>")
                        .Append("                <div class=\"chat-ib\">")
                        .Append("                    <h5><a href=\"#\" class=\"tenantdashlist\" onclick= \"insertMessage(" + tenantID + "," + HttpContext.Current.Session["AccountId"] + ");\">" + firstName + " " + lastName + " " + "Age: " + age + "</a></h5>")
                        .Append("                    <p>Hello I'm interested in your property!</p>")
                        .Append("                  </div>")
                        .Append("               </div>")
                        .Append("            </div>")
                        .Append("       </div>");

                    Card3.Text += myCard.ToString();
                    count++;
                }
            }
            drd.Close();
            sc.Close();
        }
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static void MessageInsert(int tenantID, int hostID)
    {
        System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ToString());

        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
        insert.Connection = conn;
        insert.CommandText = "INSERT into [roommagnetdb].[dbo].[FavoritedTenants] VALUES(@tenantID, @hostID)";
        insert.Parameters.Add(new SqlParameter("@tenantID", tenantID));
        insert.Parameters.Add(new SqlParameter("@hostID", hostID));
        conn.Open();
        insert.ExecuteNonQuery();
        conn.Close();
    }
}