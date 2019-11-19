using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListedProperties : System.Web.UI.Page
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
        if (Session["AccountId"] != null)
        { 
            int accountID = Convert.ToInt16(HttpContext.Current.Session["AccountId"].ToString());
            //Select Statements properties
            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
            select.CommandText = "SELECT Property.HouseNumber, Property.Street, Property.RoomPriceRangeLow, Property.RoomPriceRangeHigh, PropertyImages.images " +
                "FROM PropertyImages INNER JOIN PropertyRoom ON PropertyImages.PropertyID = PropertyRoom.RoomID " +
                "INNER JOIN Property ON PropertyImages.PropertyID = Property.PropertyID " +
                "WHERE Property.HostID  =" + accountID + "; ";
            //Connections
            select.Connection = sc;
            sc.Open();

            //Populating Tenant Part of Host Dashboard
            System.Data.SqlClient.SqlDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                String HouseNum = reader["HouseNumber"].ToString();
                String Street = reader["Street"].ToString();
                String price = reader["MonthlyPrice"].ToString();
                String filename = reader["images"].ToString();
                double priceRounded = Math.Round(Convert.ToDouble(price), 0, MidpointRounding.ToEven);
                StringBuilder myCard = new StringBuilder();
                myCard
                .Append("<div class=\"col-md-3\">")
                .Append("<div class=\"card  shadow-sm  mb-4\" >")
                //.Append("                        <img src=\"https://elasticbeanstalk-us-east-1-606091308774.s3.amazonaws.com/PropertyImages//" + filename + " alt =\"image\">")
                .Append("                        <a href=\"search-result-page-detail.html\" class=\"cardLinks\">")
                .Append("                            <div class=\"card-body\">")
                .Append("                                <h5 class=\"card-title\">" + HouseNum + " " + Street + "</h5>")
                .Append("                                <p class=\"card-text\">" + "Room Price" + " - " + "$" + priceRounded + "</p>")
                .Append("                            </div>")
                .Append("                        </a>")
                .Append("")
                .Append("                        <div>")
                .Append("                            <button type=\"button\" id=\"heartbtn\" class=\"btn favoriteHeartButton\"><i id=\"hearti\" class=\"far fa-heart\"></i></button>")
                .Append("                        </div>")
                .Append("                    </div>")
                .Append("</n 4div>");
                Card.Text += myCard.ToString();
            }
            reader.Close();
            sc.Close();
        }
    }
}