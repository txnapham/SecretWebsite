using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class HostDashboard : System.Web.UI.Page
{
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
        if (Session["AccountId"] != null && Convert.ToInt16(Session["type"]) == 2)
        {
            //apptCal.SelectedDate = DateTime.Today;

            HostCard.Text = "";
            properties.Text = "";
            currTen.Text = "";
            favTen.Text = "";
            alert1.Text = "";
            alert2.Text = "";
            progressBar.Text = "";

            int accountID = Convert.ToInt16(HttpContext.Current.Session["AccountId"].ToString());

            //Select Statements properties
            System.Data.SqlClient.SqlCommand selectHost = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand alert1Comm = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand alert2Comm = new System.Data.SqlClient.SqlCommand();
            selectHost.CommandText = "SELECT FirstName, AccountImage FROM Account WHERE AccountID = " + accountID + ";";
            alert1Comm.CommandText = "SELECT COUNT(*) FROM Characteristics WHERE AccountID = " + accountID;
            alert2Comm.CommandText = "SELECT BackgroundCheckStatus FROM Host WHERE HostID = " + accountID;

            //Connections
            selectHost.Connection = sc;
            alert1Comm.Connection = sc;
            alert2Comm.Connection = sc;
            sc.Open();

            int charCheck = (int)alert1Comm.ExecuteScalar();
            int backStatusCheck = 0;

            if(alert2Comm.ExecuteScalar() is DBNull)
            {

            }
            else
            {
                backStatusCheck = (int)alert2Comm.ExecuteScalar();
            }

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
                    .Append("<div> <img alt=\"image\" src=\"https://duvjxbgjpi3nt.cloudfront.net/UserImages/" + filename + "\" class=\" rounded-circle-header img-fluid\" width=\"30%\" height=\"auto\">")
                    .Append("                Welcome " + tenantName + "! </div>");
                HostCard.Text += hostImage.ToString();
            }
            sc.Close();

            StringBuilder alert1Text = new StringBuilder();
            alert1Text
                .Append("<div class=\"alert alert-light alert-dismissible fade show\" role=\"alert\">")
                .Append("   <strong>Complete profile now! (Welcome -> Edit Profile to Complete Profile)</strong>")
                .Append("   <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">")
                .Append("       <span aria-hidden=\"true\">&times;</span>")
                .Append("   </button>")
                .Append("</div>");

            StringBuilder alert2Text = new StringBuilder();
            alert2Text
                .Append("<div class=\"alert alert-light alert-dismissible fade show\" role=\"alert\">")
                .Append("   <strong>Begin background check now! (Welcome -> Edit Profile to Begin Background Check)</strong>")
                .Append("   <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">")
                .Append("       <span aria-hidden=\"true\">&times;</span>")
                .Append("   </button>")
                .Append("</div>");

            StringBuilder progressOneThird = new StringBuilder();
            progressOneThird
                .Append("<div class=\"progress\" style=\"height: 40%; \">")
                .Append("   <img class=\"d-block w-100 img-fluid\" src=\"images/Progressbar1.png\" \">")
                .Append("</div");

            StringBuilder progressTwoThird = new StringBuilder();
            progressTwoThird
                .Append("<div class=\"progress\" style=\"height: 40%; \">")
                .Append("   <img class=\"d-block w-100 img-fluid\" src=\"images/Progressbar2.png\" \">")
                .Append("</div");

            StringBuilder progressFull = new StringBuilder();
            progressFull
                .Append("<div class=\"progress\" style=\"height: 40%; \">")
                .Append("   <img class=\"d-block w-100 img-fluid\" src=\"images/Progressbar3.png\" \">")
                .Append("</div");

            if (charCheck == 0 && backStatusCheck == 0)
            {
                alert1.Text += alert1Text.ToString();
                alert2.Text += alert2Text.ToString();
                progressBar.Text += progressOneThird.ToString();
            }
            else if (charCheck == 1 && backStatusCheck == 1)
            {
                progressBar.Text += progressFull.ToString();
            }
            else if (charCheck == 1 || backStatusCheck == 1)
            {
                if (charCheck == 1 || backStatusCheck == 1)
                {
                    alert1.Text += alert2Text.ToString();
                    progressBar.Text += progressTwoThird.ToString();
                }
                else if (charCheck == 1 || backStatusCheck == 1)
                {
                    alert1.Text += alert1Text.ToString();
                    progressBar.Text += progressTwoThird.ToString();
                }
            }

            //Select Statements for tenant and properties
            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand selectProp = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand favoriteTenant = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand tenantDash = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand selectTenant = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand selectDate = new System.Data.SqlClient.SqlCommand();
            //Tenant Select
            select.CommandText = "SELECT FirstName,LastName FROM Account WHERE AccountID in " +
            "(SELECT TOP(5) tenantID FROM Lease WHERE HostID = " + accountID + ");";
            //Property Select
            selectProp.CommandText = "SELECT HouseNumber, Street FROM Property WHERE PropertyID in (SELECT propertyID FROM Property WHERE HostID = " + accountID + ");";
            //Message Center Tenant Populating once they favorite the current host's room
            favoriteTenant.CommandText = "select firstName, LastName,AccountID,BirthDate, AccountImage from account where AccountID in (select tenantID from tenant where TenantID in " +
                "(select tenantID from FavoritedProperties where PropertyID in (select PropertyID from property where hostID =" + accountID + ")));";
            //Select statement to get fsvorite tenantID to check if they exist already
            tenantDash.CommandText = "select accountID from account where AccountID in (select tenantID from Tenant where TenantID in (select tenantID from " +
                "FavoritedTenants where HostID =" + accountID + "));";
            //Select statement to get appointments with tenants
            selectTenant.CommandText = "SELECT Account.FirstName, Account.LastName " +
                "FROM FavoritedTenants INNER JOIN Appointment ON FavoritedTenants.FavTenantID = Appointment.FavTenantID" +
                " INNER JOIN Tenant ON FavoritedTenants.TenantID = Tenant.TenantID INNER JOIN Account ON " +
                "Tenant.TenantID = Account.AccountID WHERE FavoritedTenants.HostID =" + accountID + ";";
            //Select date to get appointments with tenants
            selectDate.CommandText = "SELECT Appointment.AppointmentDate " +
                "FROM FavoritedTenants INNER JOIN Appointment ON FavoritedTenants.FavTenantID = Appointment.FavTenantID" +
                " INNER JOIN Tenant ON FavoritedTenants.TenantID = Tenant.TenantID INNER JOIN Account ON " +
                "Tenant.TenantID = Account.AccountID WHERE FavoritedTenants.HostID =" + accountID + ";";

            //Connections
            select.Connection = sc;
            selectProp.Connection = sc;
            favoriteTenant.Connection = sc;
            tenantDash.Connection = sc;
            selectTenant.Connection = sc;
            selectDate.Connection = sc;
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
                currTen.Text += myCard.ToString();
            }
            reader.Close();
            //Populating Property Part of Host Dashboard
            System.Data.SqlClient.SqlDataReader rdr = selectProp.ExecuteReader();
            while (rdr.Read())
            {
                String HouseNum = rdr["HouseNumber"].ToString();
                String Street = rdr["Street"].ToString();

                StringBuilder currentTenant = new StringBuilder();
                currentTenant
                .Append("<li><a href=\"#\" class=\"tenantdashlist\">" + HouseNum + " " + Street + "</a></li>");
                properties.Text += currentTenant.ToString();
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
                String imgURL = drd["AccountImage"].ToString();
                if (imgURL == "") imgURL = "noprofileimage.png";

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
                        .Append("   <div class=\"chat-people\">")
                        .Append("       <div class=\"chat-img\"> <img src =\"https://duvjxbgjpi3nt.cloudfront.net/UserImages/" + imgURL + "\" class=\"rounded-circle img-fluid\">")
                        .Append("       </div>")
                        .Append("       <div class=\"chat-ib\">")
                        .Append("           <h5><a href=\"#\" class=\"tenantdashlist\" onclick= \"insertMessage(" + tenantID + "," + HttpContext.Current.Session["AccountId"] + ");\">" + firstName + " " + lastName + " " + ", Age: " + age + "</a></h5>")
                        .Append("           <p>Hello I'm interested in your property!</p>")
                        .Append("       </div>")
                        .Append("   </div>")
                        .Append("</div>");

                    favTen.Text += myCard.ToString();
                    count++;
                }
            }
            drd.Close();

            //Populate Tenant with appointments
            System.Data.SqlClient.SqlDataReader aName = selectTenant.ExecuteReader();
            while (aName.Read())
            {
                String firstName = aName["FirstName"].ToString();
                String lastName = aName["LastName"].ToString();
                //StringBuilder
                StringBuilder myCard = new StringBuilder();
                myCard.Append("<li><a href =\"#\" class=\"tenantdashlist\">" + firstName + " " + lastName + ": </a></li>");
                apptName.Text += myCard.ToString();
            }
            aName.Close();
            //Populate Tenant with appointments
            System.Data.SqlClient.SqlDataReader aDate = selectDate.ExecuteReader();
            while (aDate.Read())
            {
                String apDate = aDate["AppointmentDate"].ToString();
                //StringBuilder
                StringBuilder myCard = new StringBuilder();
                myCard.Append("<li><a href =\"#\" class=\"tenantdashlist\">" + apDate + " " + " </a></li>");
                apptDate.Text += myCard.ToString();
            }
            aDate.Close();
            sc.Close();
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static void MessageInsert(int tenantID, int hostID)
    {
        //Add favorited tenants into the Host Message Dashboard
        System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["roommagnetdbConnectionString"].ToString());

        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
        insert.Connection = conn;
        insert.CommandText = "INSERT into [roommagnetdb].[dbo].[FavoritedTenants] VALUES(@tenantID, @hostID)";
        insert.Parameters.Add(new SqlParameter("@tenantID", tenantID));
        insert.Parameters.Add(new SqlParameter("@hostID", hostID));
        conn.Open();
        insert.ExecuteNonQuery();
        conn.Close();
    }
    protected void btnCreateAppt_Click(object sender, EventArgs e)
    {
        if (ddRecipient.SelectedIndex==0)
        {
            lblRError.Text = "Please select a Recipient.";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
        else
        {
            DateTime appt = new DateTime();
            if (txtDate.Text == "")
            {
                lblError.Text = "Please enter the Date (MM/DD/YYYY). <br/>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
            }
            else
            {
                //Date validation. Check to make sure appointment date is in the future
                DateTime today = DateTime.Now;
                appt = DateTime.Parse(txtDate.Text, new System.Globalization.CultureInfo("pt-BR"));
                if(appt < today)
                {
                    lblError.Text = "Please select a future date.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                }
                else
                {
                    //SQL Statement
                    System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
                    //Connection
                    sc.ConnectionString = "server=aawnyfad9tm1sf.cqpnea2xsqc1.us-east-1.rds.amazonaws.com; database =roommagnetdb;uid=admin;password=Skylinejmu2019;";
                    sc.Open();
                    System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
                    System.Data.SqlClient.SqlCommand favTen = new System.Data.SqlClient.SqlCommand();
                    insert.Connection = sc;
                    favTen.Connection = sc;

                    int favTenID;
                    favTen.CommandText = "SELECT FavTenantID FROM FavoritedTenants WHERE HostID =" + Session["AccountId"] + "AND TenantID=" + ddRecipient.SelectedValue;
                    favTenID = Convert.ToInt32(favTen.ExecuteScalar());

                    //Appointment added into Database
                    Appointment newAppt = new Appointment(DateTime.Parse(txtDate.Text), favTenID);
                    insert.CommandText = "INSERT into Appointment VALUES (@date, @favTenID) ; ";
                    insert.Parameters.Add(new SqlParameter("@date", newAppt.getDate()));
                    insert.Parameters.Add(new SqlParameter("@favTenID", favTenID));

                    insert.ExecuteNonQuery();
                    sc.Close();

                    txtDate.Text = "";
                    ddRecipient.ClearSelection();
                }
            }
        }
    }

    protected void btnAddRoom_Click(object sender, EventArgs e)
    {
        //SQl Statement
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        //Connection
        sc.ConnectionString = "server=aawnyfad9tm1sf.cqpnea2xsqc1.us-east-1.rds.amazonaws.com; database =roommagnetdb;uid=admin;password=Skylinejmu2019;";
        sc.Open();
        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
        insert.Connection = sc;

        insert.CommandText = "INSERT INTO PropertyRoom Values(@price, @aboutProperty, @kitchen, @HVAC, @Wifi, @privateBR, @washAndDry, @WalkInCloset, @PropertyID)";
        
        //Variables for types of ammentites
        int kitchen;
        int HVAC;
        int Wifi;
        int PrivateBR;
        int WashAndDry;
        int WalkInCloset;
        //Changing the Status of these ammentities in Database
        if (cbKitchen.Checked == true) { kitchen = 1; }
        else { kitchen = 0; }
        if (cbHVAC.Checked == true) { HVAC = 1; }
        else { HVAC = 0; }
        if (cbWifi.Checked == true) { Wifi = 1; }
        else { Wifi = 0; }
        if (cbPrivateBR.Checked == true) { PrivateBR = 1; }
        else { PrivateBR = 0; }
        if (cbWashDry.Checked == true) { WashAndDry = 1; }
        else { WashAndDry = 0; }
        if (cbWalkInClos.Checked == true) { WalkInCloset = 1; }
        else { WalkInCloset = 0; }

        string description = txtDescription.Text;

        insert.Parameters.Add(new SqlParameter("@price", txtPrice.Text));
        insert.Parameters.Add(new SqlParameter("@aboutProperty", description));
        insert.Parameters.Add(new SqlParameter("@kitchen", kitchen));
        insert.Parameters.Add(new SqlParameter("@HVAC", HVAC));
        insert.Parameters.Add(new SqlParameter("@Wifi", Wifi));
        insert.Parameters.Add(new SqlParameter("@privateBR", PrivateBR));
        insert.Parameters.Add(new SqlParameter("@washAndDry", WashAndDry));
        insert.Parameters.Add(new SqlParameter("@walkInCloset", WalkInCloset));
        insert.Parameters.Add(new SqlParameter("@PropertyID", ddProperty.SelectedValue));

        insert.ExecuteNonQuery();
        //Close 
    }
}