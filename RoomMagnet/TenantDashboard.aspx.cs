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
        if (Session["AccountId"] != null && Convert.ToInt16(Session["type"]) == 3)
        {
            Card2.Text = String.Empty;
            Card3.Text = String.Empty;

            if (Session["AccountId"] != null)
            {
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
                select.CommandText = "SELECT FirstName, AccountImage FROM Account WHERE AccountID = " + accountID + ";";
                //Connections
                select.Connection = sc;
                sc.Open();

                //Populating Tenant Part of Host Dashboard
                System.Data.SqlClient.SqlDataReader reader = select.ExecuteReader();
                while (reader.Read())
                {
                    String tenantName = reader["FirstName"].ToString();
                    String filename = reader["AccountImage"].ToString();
                    // No image uploaded (currently default image in S3)
                    if (filename == "") filename = "defaulttenantimg.jpg";
                    // User dashboard dynamically updated using S3
                    StringBuilder tenantImage = new StringBuilder();
                    tenantImage
                    .Append("<img alt=\"image\" src=\"https://duvjxbgjpi3nt.cloudfront.net/UserImages/" + filename + "\" class=\" rounded-circle img-fluid\" width=\"30%\" height=\"auto\">")
                    .Append("                Welcome " + tenantName + "!");
                    Card.Text += tenantImage.ToString();
                }
                sc.Close();

                //Selecting from Property
                // System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlCommand messageSelect = new System.Data.SqlClient.SqlCommand();
                select.CommandText = "SELECT City, HomeState, LocalPriceRangeLow, LocalPriceRangeHigh FROM Property WHERE PropertyID in " +
                "(SELECT TOP(4) PropertyID FROM FavoritedProperties WHERE TenantID = " + accountID + ");";
                messageSelect.CommandText = "SELECT Account.FirstName, Account.LastName, max(Message.Date) as Date FROM Message INNER JOIN FavoritedProperties ON " +
                    "Message.FavPropID = FavoritedProperties.FavPropID INNER JOIN Property ON FavoritedProperties.PropertyID = Property.PropertyID INNER JOIN Host ON " +
                    "Property.HostID = Host.HostID INNER JOIN Account ON Host.HostID = Account.AccountID INNER JOIN FavoritedTenants ON Message.FavTenantID = " +
                    "FavoritedTenants.FavTenantID AND Host.HostID = FavoritedTenants.HostID where MessageType = 0 and FavoritedTenants.TenantID = " + accountID + " group by " +
                    "Account.FirstName, Account.LastName";
                select.Connection = sc;
                messageSelect.Connection = sc;
                sc.Open();
                System.Data.SqlClient.SqlDataReader readerProperty = select.ExecuteReader();

                //Populating Dashboard
                while (readerProperty.Read())
                {
                    String city = reader["City"].ToString();
                    String homeState = reader["HomeState"].ToString();
                    String priceRangeLow = reader["RoomPriceRangeLow"].ToString();
                    String priceRangeHigh = reader["RoomPriceRangeHigh"].ToString();
                    double priceLowRounded = Math.Round(Convert.ToDouble(priceRangeLow), 0, MidpointRounding.ToEven);
                    double priceHighRounded = Math.Round(Convert.ToDouble(priceRangeHigh), 0, MidpointRounding.ToEven);

                    StringBuilder myCard = new StringBuilder();
                    myCard
                    .Append("<div class=\"col-xs-4 col-md-3\">")
                    .Append("<div class=\"card  shadow-sm  mb-4\" >")
                    .Append("                        <img src=\"images/scott-webb-1ddol8rgUH8-unsplash.jpg\" class=\"card-img-top\" alt=\"image\">")
                    .Append("                        <a href=\"search-result-page-detail.html\" class=\"cardLinks\">")
                    .Append("                            <div class=\"card-body\">")
                    .Append("                                <h5 class=\"card-title\">" + city + ", " + homeState + "</h5>")
                    .Append("                                <p class=\"card-text\">" + "$" + priceLowRounded + " - " + "$" + priceHighRounded + "</p>")
                    .Append("                            </div>")
                    .Append("                        </a>")
                    .Append("")
                    .Append("                    </div>")
                    .Append("</div>");
                    Card2.Text += myCard.ToString();
                }
                reader.Close();
                System.Data.SqlClient.SqlDataReader rdr = messageSelect.ExecuteReader();
                while (rdr.Read())
                {
                    String firstName = rdr["FirstName"].ToString();
                    String LastName = rdr["LastName"].ToString();
                    String date = rdr["Date"].ToString();

                    StringBuilder myCard = new StringBuilder();
                    myCard
                        .Append(" <div class=\"chat-list\">")
                        .Append("            <div class=\"chat-people\">")
                        .Append("                <div class=\"chat-img\">")
                        .Append("                    <img src = \"images/bettyBrown.png\" class=\"rounded-circle img-fluid\">")
                        .Append("                </div>")
                        .Append("                <div class=\"chat-ib\">")
                        .Append("                    <h5>" + firstName + " " + LastName + "</h5>")
                        .Append("                    <p>" + date + "</p>")
                        .Append("                </div>")
                        .Append("            </div>")
                        .Append("        </div>");
                    Card3.Text += myCard.ToString();
                }
                rdr.Close();
                sc.Close();
            }
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }
}