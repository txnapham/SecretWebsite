using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using awsTestUpload;
using System.IO;

public partial class EditProperty : System.Web.UI.Page
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
        //Only Hosts Allowed to Do This 
        if (Session["AccountId"] != null && Convert.ToInt16(Session["type"]) == 2)
        {
            int accountID = Convert.ToInt16(HttpContext.Current.Session["AccountId"].ToString());

            //Select Statements properties
            System.Data.SqlClient.SqlCommand selectProperty = new System.Data.SqlClient.SqlCommand();
            selectProperty.CommandText = "SELECT HouseNumber, Street, City, HomeState, Zip, Country, RoomPriceRangeLow, RoomPriceRangeHigh," +
                "StreetParking, GarageParking, PorchOrDeck, Pool, NonSmoking FROM Property WHERE HostID = " + accountID + ";";
            //Connections
            selectProperty.Connection = sc;
            sc.Open();

            //Populating Property 
            System.Data.SqlClient.SqlDataReader readerPropertyEdit = selectProperty.ExecuteReader();
            while (readerPropertyEdit.Read())
            {
                String HouseNumber = readerPropertyEdit["HouseNumber"].ToString();
                String Street = readerPropertyEdit["Street"].ToString();
                String City = readerPropertyEdit["City"].ToString();
                String HomeState = readerPropertyEdit["HomeState"].ToString();
                String Zip = readerPropertyEdit["Zip"].ToString();
                String Country = readerPropertyEdit["Country"].ToString();
                String RoomPriceRangeLow = readerPropertyEdit["RoomPriceRangeLow"].ToString();
                String RoomPriceRangeHigh = readerPropertyEdit["RoomPriceRangeHigh"].ToString();
                String StreetParking = readerPropertyEdit["StreetParking"].ToString();
                String GarageParking = readerPropertyEdit["GarageParking"].ToString();
                String PorchOrDeck = readerPropertyEdit["PorchOrDeck"].ToString();
                String Pool = readerPropertyEdit["Pool"].ToString();
                String NonSmoking = readerPropertyEdit["NonSmoking"].ToString();



                //// No image uploaded (currently default image in S3)
                //if (filename == "") filename = "defaulttenantimg.jpg";
                //// User dashboard dynamically updated using S3
                //StringBuilder hostImage = new StringBuilder();
                //hostImage
                //.Append("<img alt=\"image\" src=\"https://duvjxbgjpi3nt.cloudfront.net/UserImages/" + filename + "\" class=\" rounded-circle img-fluid\" width=\"30%\" height=\"auto\">");
                //HostCard.Text += hostImage.ToString();
            }
            sc.Close();

            sc.ConnectionString = "server=aa9vyec53lz6c8.cqpnea2xsqc1.us-east-1.rds.amazonaws.com; database =roommagnetdb;uid=admin;password=Skylinejmu2019;";
            sc.Open();
            //Search Query 
            System.Data.SqlClient.SqlCommand search = new System.Data.SqlClient.SqlCommand();
            search.Connection = sc;
            search.CommandText = "SELECT HouseNumber, Street, City, HomeState, Zip, Country, RoomPriceRangeLow, RoomPriceRangeHigh," +
                "StreetParking, GarageParking, PorchOrDeck, Pool, NonSmoking FROM Property WHERE HostID = " + accountID + ";";
            SqlDataReader searching = search.ExecuteReader();

            //checks the database for matches
            if (searching.Read())
            {
                txtHouseNum.Text = searching.GetString(0);
                txtStreet.Text = searching.GetString(1);
                txtCity.Text = searching.GetString(2);
                ddState.SelectedValue = searching.GetString(3);
                txtZip.Text = searching.GetString(4);
                txtCountry.Text = searching.GetString(5);
            }
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

    }
}