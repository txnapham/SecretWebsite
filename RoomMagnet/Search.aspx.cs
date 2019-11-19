﻿using System;
using System.Text;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;


public partial class Search : System.Web.UI.Page
{
    System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ToString());
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
        if (Session["Search"] != null)
        {
            String homeSearch = "";
            if(Session["Search"] != null)
            {
                homeSearch = Convert.ToString(Session["Search"]);
            }
            btnHomeSearch_Click(homeSearch);
        }
    }

    public void btnHomeSearch_Click(String homeSearch)
    {
        Boolean searchCheck = false;
        for (int i = 0; i < homeSearch.Length - 1; i++)
        {
            String checkValue = homeSearch.Substring(i, 2);
            if (checkValue == ", ")
            {
                searchCheck = true;
            }
        }

        if (searchCheck == true)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ToString());

            sqlConn.Open(); 

            String tSearch = HttpUtility.HtmlEncode(homeSearch);
            int commaSplit = tSearch.IndexOf(",");
            String cityString = tSearch.Substring(0, commaSplit).ToUpper();
            String state = tSearch.Substring(commaSplit + 2).ToUpper();
            String query = "select [PropertyID], [City], [HomeState], [Zip], [RoomPriceRangeLow],[RoomPriceRangeHigh] from[dbo].[Property] where upper([City]) like '" + cityString + "' AND upper([HomeState]) like '" + state + "';";
            System.Data.SqlClient.SqlCommand sqlComm = new System.Data.SqlClient.SqlCommand(query, sqlConn);
            System.Data.SqlClient.SqlDataReader reader = sqlComm.ExecuteReader();

            Card1.Text = "";
            int resultCount = 0;

            while (reader.Read())
            {
                int PropID = Convert.ToInt32(reader["PropertyID"]);
                String city = reader["City"].ToString();
                String homeState = reader["HomeState"].ToString();
                String priceRangeLow = reader["RoomPriceRangeLow"].ToString();
                String priceRangeHigh = reader["RoomPriceRangeHigh"].ToString();
                double priceLowRounded = Math.Round(Convert.ToDouble(priceRangeLow), 0, MidpointRounding.ToEven);
                double priceHighRounded = Math.Round(Convert.ToDouble(priceRangeHigh), 0, MidpointRounding.ToEven);

                StringBuilder myCard = new StringBuilder();
                myCard
                .Append("<div class=\"col-xs-4 col-md-3\">")
                .Append("   <div class=\"card  shadow-sm  mb-4\">")
                .Append("       <img src=\"images/scott-webb-1ddol8rgUH8-unsplash.jpg\" class=\"card-img-top\" alt=\"image\">")
                .Append("           <div class=\"card-body\">")
                .Append("               <h5 class=\"card-title\">" + city + ", " + homeState + "</h5>")
                .Append("               <p class=\"card-text\">" + "$" + priceLowRounded + " - " + "$" + priceHighRounded + "</p>")
                .Append("           </div>")
                .Append("   </div>")
                .Append("</div>");

                Card1.Text += myCard.ToString();
                resultCount++;
            }
            reader.Close();
            Session["Search"] = null;
        }
        else
        {
            txtSearch.Text = "That Search Query Did Not Display Results";
        }
    }

    [System.Web.Services.WebMethod]
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Boolean searchCheck = false;
        for (int i = 0; i < txtSearch.Text.Length - 1; i++)
        {
            String checkValue = txtSearch.Text.Substring(i, 2);
            if (checkValue == ", ")
            {
                searchCheck = true;
            }
        }

        if (searchCheck == true)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ToString());

            if (String.IsNullOrEmpty(txtSearch.Text))
            {
                // Do nothing
            }
            else
            {
                sqlConn.Open();
                String tSearch = HttpUtility.HtmlEncode(txtSearch.Text);
                int commaSplit = tSearch.IndexOf(",");
                String cityString = tSearch.Substring(0, commaSplit).ToUpper();
                String state = tSearch.Substring(commaSplit + 2).ToUpper();
                String query = "select [PropertyID], [City], [HomeState], [Zip], [RoomPriceRangeLow],[RoomPriceRangeHigh] from[dbo].[Property] where upper([City]) like '" + cityString + "' AND upper([HomeState]) like '" + state + "';";
                System.Data.SqlClient.SqlCommand sqlComm = new System.Data.SqlClient.SqlCommand(query, sqlConn);
                System.Data.SqlClient.SqlDataReader reader = sqlComm.ExecuteReader();

                Card1.Text = "";
                int resultCount = 0;

                while (reader.Read())
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
                    .Append("   <div class=\"card  shadow-sm  mb-4\">")
                    .Append("       <img src=\"images/scott-webb-1ddol8rgUH8-unsplash.jpg\" class=\"card-img-top\" alt=\"image\">")
                    .Append("           <div class=\"card-body\">")
                    .Append("               <h5 class=\"card-title\">" + city + ", " + homeState + "</h5>")
                    .Append("               <p class=\"card-text\">" + "$" + priceLowRounded + " - " + "$" + priceHighRounded + "</p>")
                    .Append("           </div>")
                    .Append("   </div>")
                    .Append("</div>");

                    Card1.Text += myCard.ToString();
                    resultCount++;
                }
                reader.Close();
                Session["Search"] = null;
            }
        }
        else
        {
            txtSearch.Text = "That Search Did Not Display Results";
        }
    }
}
