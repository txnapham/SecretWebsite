﻿using System;
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
            progressBar.Text = "";

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
                .Append("<img alt=\"image\" src=\"https://duvjxbgjpi3nt.cloudfront.net/UserImages/" + filename + "\" class=\" rounded-circle-header img-fluid\" width=\"30%\" height=\"auto\">")
                .Append("                Welcome " + tenantName + "!");
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

            //Give the profile completion and background check alert to pop up
            if (charCheck == 0 && backStatusCheck == 0)
            {
                alert1.Text += alert1Text.ToString();
                alert2.Text += alert2Text.ToString();
                progressBar.Text += progressOneThird.ToString();
            }
            //Move progress bar to fully complete 
            else if (charCheck == 1 && backStatusCheck == 1)
            {
                progressBar.Text += progressFull.ToString();

            }
            //2/3 Progress Bar and Give Alert 
            else if (charCheck == 1 || backStatusCheck == 1)
            {
                if (charCheck == 1 || backStatusCheck == 1)
                {
                    alert1.Text += alert2Text.ToString();
                    progressBar.Text += progressTwoThird.ToString();
                }
                //2/3 Progress Bar and Give Alert to Complete Profile
                else if (charCheck == 1 || backStatusCheck == 1)
                {
                    alert1.Text += alert1Text.ToString();
                    progressBar.Text += progressTwoThird.ToString();
                }
            }


            //Selecting from Property
            // System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand messageSelect = new System.Data.SqlClient.SqlCommand();
            select.CommandText = "SELECT City, HomeState, RoomPriceRangeLow, RoomPriceRangeHigh, I.images FROM Property LEFT OUTER JOIN PropertyImages I ON Property.PropertyID = I.PropertyID WHERE Property.PropertyID in " +
            "(SELECT TOP(4) PropertyID FROM FavoritedProperties WHERE TenantID = " + accountID + ");";
            messageSelect.CommandText = "SELECT Account.FirstName, Account.LastName, Account.AccountImage, MAX(Message.Date) as Date FROM FavoritedTenants FULL OUTER JOIN Message " +
                 "ON FavoritedTenants.FavTenantID = Message.FavTenantID FULL OUTER JOIN Host ON FavoritedTenants.HostID = Host.HostID FULL OUTER JOIN Account " +
                 "ON Host.HostID = Account.AccountID FULL OUTER JOIN Tenant " +
                 "ON FavoritedTenants.TenantID = Tenant.TenantID AND Account.AccountID = Tenant.TenantID " +
                 "WHERE MessageType = 0 and FavoritedTenants.TenantID = " + accountID + " " +
                 "GROUP BY Account.FirstName, Account.LastName, Account.AccountImage";

            select.Connection = sc;
            messageSelect.Connection = sc;
            sc.Open();

            System.Data.SqlClient.SqlDataReader readerProperty = select.ExecuteReader();
            //Populating Dashboard
            if (readerProperty.HasRows)
            {
                while (readerProperty.Read())
                {
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
                    .Append("<div class=\"card  shadow-sm  mb-4\" >")
                    .Append("<img class=\"img-fluid card-img-small\" src=\"https://duvjxbgjpi3nt.cloudfront.net/PropertyImages/" + filename + "\" />")
                    .Append("                        <a href=\"search-result-page-detail.html\" class=\"cardLinks\">")
                    .Append("                            <div class=\"card-body\">")
                    .Append("                                <h5 class=\"card-title\">" + city + ", " + homeState + "</h5>")
                    .Append("                                <p class=\"card-text\">" + "$" + priceLowRounded + " - " + "$" + priceHighRounded + "</p>")
                    .Append("                            </div>")
                    .Append("                        </a>")
                    .Append("")
                    .Append("                    </div>")
                    .Append("</div>");
                    favProp.Text += myCard.ToString();
                }
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
            sc.Close();
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }
}