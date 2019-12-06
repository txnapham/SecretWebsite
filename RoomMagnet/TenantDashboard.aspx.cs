using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TenantDashboard : System.Web.UI.Page
{
    System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["roommagnetdbConnectionString"].ToString());

    protected void Page_PreInit(object sender, EventArgs e)
    {
        //Access for Certain Profile Types 
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
        if (Session["AccountId"] != null && Convert.ToInt16(Session["type"]) == 3)
        {
            //Empty Card
            TenantCard.Text = "";
            favProp.Text = "";
            hostMsg.Text = "";
            alert1.Text = "";
            alert2.Text = "";
            apptName.Text = "";
            apptDate.Text = "";

            int accountID = Convert.ToInt16(HttpContext.Current.Session["AccountId"].ToString());

            //Selecting from Account
            System.Data.SqlClient.SqlCommand selectAccount = new System.Data.SqlClient.SqlCommand();
            string accountNameQuery = "SELECT FirstName FROM Account WHERE AccountID = @AccountID";
            System.Data.SqlClient.SqlCommand accountNameGrab = new SqlCommand(accountNameQuery, sc);

            string accountImageQuery = "SELECT AccountImage FROM Account WHERE AccountID = @AccountID";
            System.Data.SqlClient.SqlCommand accountImageGrab = new SqlCommand(accountImageQuery, sc);


            //string propertyIdQuery = "SELECT MAX(PropertyID) from Property";
            //System.Data.SqlClient.SqlCommand propertyIdGrab = new System.Data.SqlClient.SqlCommand(propertyIdQuery, sc);


            //Select Statements properties
            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand alert1Comm = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand alert2Comm = new System.Data.SqlClient.SqlCommand();
            select.CommandText = "SELECT FirstName, AccountImage FROM Account WHERE AccountID = " + accountID + ";";
            alert1Comm.CommandText = "SELECT COUNT(*) FROM Characteristics WHERE AccountID = " + accountID;
            alert2Comm.CommandText = "SELECT BackgroundCheckStatus FROM Tenant WHERE TenantID = " + accountID;

            //Connections
            select.Connection = sc;
            alert1Comm.Connection = sc;
            alert2Comm.Connection = sc;
            sc.Open();

            int charCheck = (int)alert1Comm.ExecuteScalar();
            int backStatusCheck = (int)alert2Comm.ExecuteScalar();

            //Populating Tenant Part of Host Dashboard
            System.Data.SqlClient.SqlDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                String tenantName = reader["FirstName"].ToString();
                String filename = reader["AccountImage"].ToString();
                // No image uploaded (currently default image in S3)
                if (filename == "") filename = "noprofileimage.png";
                // User dashboard dynamically updated using S3
                StringBuilder tenantImage = new StringBuilder();
                tenantImage
                .Append("<img alt=\"image\" src=\"https://duvjxbgjpi3nt.cloudfront.net/UserImages/" + filename + "\" class=\"rounded-circle-header img-fluid\" width=\"50%\" height=\"auto\">")
                .Append("                <h3>Welcome " + tenantName + "! </h3>");
                TenantCard.Text += tenantImage.ToString();
            }
            sc.Close();
            //Complete Profile Pop-Up
            StringBuilder alert1Text = new StringBuilder();
            alert1Text
                .Append("<div class=\"alert alert-light alert-dismissible fade show\" role=\"alert\">")
                .Append("   <strong>Complete profile now! (Welcome -> Edit Profile to Complete Profile)</strong>")
                .Append("   <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">")
                .Append("       <span aria-hidden=\"true\">&times;</span>")
                .Append("   </button>")
                .Append("</div>");
            
            //Background Check Pop Up
            StringBuilder alert2Text = new StringBuilder();
            alert2Text
                .Append("<div class=\"alert alert-light alert-dismissible fade show\" role=\"alert\">")
                .Append("   <strong>Begin background check now! (Welcome -> Edit Profile to Begin Background Check)</strong>")
                .Append("   <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">")
                .Append("       <span aria-hidden=\"true\">&times;</span>")
                .Append("   </button>")
                .Append("</div>");

            //StringBuilder progressOneThird = new StringBuilder();
            //progressOneThird
            //    .Append("<div class=\"progress\" style=\"height: 40%; \">")
            //    .Append("   <img class=\"d-block w-100 img-fluid\" src=\"images/Progressbar1.png\" \">")
            //    .Append("</div");

            //StringBuilder progressTwoThird = new StringBuilder();
            //progressTwoThird
            //    .Append("<div class=\"progress\" style=\"height: 40%; \">")
            //    .Append("   <img class=\"d-block w-100 img-fluid\" src=\"images/Progressbar2.png\" \">")
            //    .Append("</div");

            //StringBuilder progressFull = new StringBuilder();
            //progressFull
            //    .Append("<div class=\"progress\" style=\"height: 40%; \">")
            //    .Append("   <img class=\"d-block w-100 img-fluid\" src=\"images/Progressbar3.png\" \">")
            //    .Append("</div");

            //Give the profile completion and background check alert to pop up
            //if (charCheck == 0 && backStatusCheck == 0)
            //{
            //    alert1.Text += alert1Text.ToString();
            //    alert2.Text += alert2Text.ToString();
            //    //progressBar.Text += progressOneThird.ToString();
            //}
            ////Move progress bar to fully complete 
            //else if (charCheck == 1 && backStatusCheck == 1)
            //{
            //    progressBar.Text += progressFull.ToString();

            //}
            ////2/3 Progress Bar and Give Alert 
            //else if (charCheck == 1 || backStatusCheck == 1)
            //{
            //    if (charCheck == 1 || backStatusCheck == 1)
            //    {
            //        alert1.Text += alert2Text.ToString();
            //        progressBar.Text += progressTwoThird.ToString();
            //    }
            //    //2/3 Progress Bar and Give Alert to Complete Profile
            //    else if (charCheck == 1 || backStatusCheck == 1)
            //    {
            //        alert1.Text += alert1Text.ToString();
            //        progressBar.Text += progressTwoThird.ToString();
            //    }
            //}


            //Selecting from Property
            // System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand messageSelect = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand selectHost = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand selectDate = new System.Data.SqlClient.SqlCommand();

            select.CommandText = "SELECT Property.PropertyID, City, HomeState, RoomPriceRangeLow, RoomPriceRangeHigh, I.images FROM Property LEFT OUTER JOIN PropertyImages I ON Property.PropertyID = I.PropertyID WHERE Property.PropertyID in " +
            "(SELECT TOP(4) PropertyID FROM FavoritedProperties WHERE TenantID = " + accountID + ");";
            messageSelect.CommandText = "SELECT Account.FirstName, Account.LastName, Account.AccountImage, MAX(Message.Date) as Date FROM FavoritedTenants FULL OUTER JOIN Message " +
                 "ON FavoritedTenants.FavTenantID = Message.FavTenantID FULL OUTER JOIN Host ON FavoritedTenants.HostID = Host.HostID FULL OUTER JOIN Account " +
                 "ON Host.HostID = Account.AccountID FULL OUTER JOIN Tenant " +
                 "ON FavoritedTenants.TenantID = Tenant.TenantID AND Account.AccountID = Tenant.TenantID " +
                 "WHERE MessageType = 0 and FavoritedTenants.TenantID = " + accountID + " " +
                 "GROUP BY Account.FirstName, Account.LastName, Account.AccountImage";

            //Select statement to get appointments with host
            selectHost.CommandText = "SELECT Account.FirstName, Account.LastName" +
                " FROM FavoritedTenants INNER JOIN Appointment ON FavoritedTenants.FavTenantID = Appointment.FavTenantID" +
                " INNER JOIN Host ON FavoritedTenants.HostID = Host.HostID INNER JOIN Account ON " +
                "Host.HostID = Account.AccountID WHERE FavoritedTenants.TenantID =" + accountID + ";";

            //Select date to get appointments with tenants
            selectDate.CommandText = "SELECT Appointment.AppointmentDate " +
                "FROM FavoritedTenants INNER JOIN Appointment ON FavoritedTenants.FavTenantID = Appointment.FavTenantID" +
                " INNER JOIN Host ON FavoritedTenants.HostID = Host.HostID INNER JOIN Account ON " +
                "Host.HostID = Account.AccountID WHERE FavoritedTenants.TenantID =" + accountID + ";";

            select.Connection = sc;
            messageSelect.Connection = sc;
            selectHost.Connection = sc;
            selectDate.Connection = sc;
            sc.Open();

            System.Data.SqlClient.SqlDataReader readerProperty = select.ExecuteReader();
            int resultCount = 0;

            //Populating Dashboard
            while (readerProperty.Read())
            {
                int PropID = Convert.ToInt32(readerProperty["PropertyID"]);
                String filename = readerProperty["images"].ToString();
                if (filename == "") filename = "imagenotfound.png";
                String city = readerProperty["City"].ToString();
                String homeState = readerProperty["HomeState"].ToString();
                String priceRangeLow = readerProperty["RoomPriceRangeLow"].ToString();
                String priceRangeHigh = readerProperty["RoomPriceRangeHigh"].ToString();
                double priceLowRounded = Math.Round(Convert.ToDouble(priceRangeLow), 0, MidpointRounding.ToEven);
                double priceHighRounded = Math.Round(Convert.ToDouble(priceRangeHigh), 0, MidpointRounding.ToEven);
                //String Builder
                StringBuilder myCard = new StringBuilder();
                myCard
                .Append("<div class=\"col-xs-4 col-md-3\">")
                .Append("   <div class=\"card  shadow-sm  mb-4\" >")
                .Append("       <img class=\"img-fluid card-img-small\" src=\"https://duvjxbgjpi3nt.cloudfront.net/PropertyImages/" + filename + "\" />")
                .Append("       <div class=\"card-body\">")
                .Append("           <h5 class=\"card-title\">" + city + ", " + homeState + "</h5>")
                .Append("           <p class=\"card-text\">" + "$" + priceLowRounded + " - " + "$" + priceHighRounded + "</p>")
                .Append("       </div>")
                .Append("       <div>")
                .Append("           <button type=\"button\" id=\"heartbtn" + resultCount + "\" onClick=\"favoriteBtn(" + PropID + "," + "\'" + city + "\'" + "," +
                                    "\'" + homeState + "\'" + "," + priceLowRounded + "," + priceHighRounded + ")\" " +
                                    "class=\"btn favoriteHeartButton\"><i id=\"hearti\" class=\"far fa-heart\"></i></button>")
                .Append("       </div>")
                .Append("   </div>")
                .Append("</div>");
                favProp.Text += myCard.ToString();

                resultCount++;
            }
            readerProperty.Close();

            System.Data.SqlClient.SqlDataReader rdr = messageSelect.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    //Profile at top (first, last, date, account image)
                    String firstName = rdr["FirstName"].ToString();
                    String LastName = rdr["LastName"].ToString();
                    String date = rdr["Date"].ToString();
                    String filename = rdr["AccountImage"].ToString();
                    if (filename == "") filename = "noprofileimage.png";
                    //Show chat 
                    StringBuilder myCard = new StringBuilder();
                    myCard
                        .Append(" <div class=\"chat-list\">")
                        .Append("            <div class=\"chat-people\">")
                        .Append("                <div class=\"chat-img\">")
                        .Append("                    <img src = \"https://duvjxbgjpi3nt.cloudfront.net/UserImages/" + filename + "\" class=\"rounded-circle img-fluid\">")
                        .Append("                </div>")
                        .Append("                <div class=\"chat-ib\">")
                        .Append("                    <h5>" + firstName + " " + LastName + "</h5>")
                        .Append("                    <p>" + date + "</p>")
                        .Append("                </div>")
                        .Append("            </div>")
                        .Append("        </div>");
                    hostMsg.Text += myCard.ToString();
                }
            }
            rdr.Close();
            //Populate Tenant with appointments
            System.Data.SqlClient.SqlDataReader aName = selectHost.ExecuteReader();
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
            //Populate Host with appointments
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
    public static void MiddleMan(int propertyID, string city, string state, double priceLow, double priceHigh)
    {
        int propID = propertyID;
        int loginID = Convert.ToInt32(HttpContext.Current.Session["AccountId"].ToString());

        System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["roommagnetdbConnectionString"].ToString());
        sqlConn.Open();

        System.Data.SqlClient.SqlCommand delete = new System.Data.SqlClient.SqlCommand();
        delete.Connection = sqlConn;
        delete.CommandText = "DELETE FROM [dbo].[FavoritedProperties] WHERE (TenantID = @tenantID) AND (PropertyID = @propertyID)";
        delete.Parameters.Add(new SqlParameter("@tenantID", loginID));
        delete.Parameters.Add(new SqlParameter("@propertyID", propID));

        delete.ExecuteNonQuery();
    }

    protected void btnCreateAppt_Click(object sender, EventArgs e)
    {
        if (ddRecipient.SelectedIndex == 0)
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
                if (appt < today)
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
                    favTen.CommandText = "SELECT FavTenantID FROM FavoritedTenants WHERE TenantID =" + Session["AccountId"] + "AND HostID=" + ddRecipient.SelectedValue;
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MyFunction()", true);
                }
            }
        }
    }
}
