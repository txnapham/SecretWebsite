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
                "FROM Property LEFT OUTER JOIN PropertyImages ON Property.PropertyID = PropertyImages.PropertyID " +
                "WHERE Property.HostID = " + accountID + ";";
            //Connections
            select.Connection = sc;
            sc.Open();

            //Populating Tenant Part of Host Dashboard
            System.Data.SqlClient.SqlDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                String HouseNum = reader["HouseNumber"].ToString();
                String Street = reader["Street"].ToString();
                String priceLow = reader["RoomPriceRangeLow"].ToString();
                String priceHigh = reader["RoomPriceRangeHigh"].ToString();
                String filename = reader["images"].ToString();
                // No image uploaded (currently default image in S3)
                if (filename == "") filename = "imagenotfound.png";
                double priceLowRounded = Math.Round(Convert.ToDouble(priceLow), 0, MidpointRounding.ToEven);
                double priceHighRounded = Math.Round(Convert.ToDouble(priceHigh), 0, MidpointRounding.ToEven);
 
                StringBuilder myCard = new StringBuilder();
                myCard
                .Append("<div class=\"col-xs-4 col-md-3\">")
                .Append("   <div class=\"card  shadow-sm  mb-4\">")
                .Append("<img alt=\"image\" src=\"https://duvjxbgjpi3nt.cloudfront.net/PropertyImages/" + filename + "\" />")
                .Append("           <div class=\"card-body\">")
                .Append("               <h5 class=\"card-title\">" + HouseNum + ", " + Street + "</h5>")
                .Append("               <p class=\"card-text\">" + "$" + priceLowRounded + " - " + "$" + priceHighRounded + "</p>")
                .Append("           </div>")
                .Append("   </div>")
                .Append("</div>");
                Card.Text += myCard.ToString();
            }
            reader.Close();
            sc.Close();
        }
    }
}