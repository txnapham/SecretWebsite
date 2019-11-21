// This is my ListedPropertyForm.aspx.cs form. It all compiles and I am pretty sure
// I have the logic correct, the FileUpload1_Click method just does not fire, page_load does...

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Amazon.S3;
using Amazon.S3.Transfer;
using awsTestUpload;
using System.Collections;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

public partial class ListPropertyForm : System.Web.UI.Page
{
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

    SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AccountId"] != null && Convert.ToInt16(Session["type"]) == 2)
        {
            int accountID = Convert.ToInt16(HttpContext.Current.Session["AccountId"].ToString());
            FileUpload1_Click(sender, e);

            txtCountry.Text = "US";
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }

    ArrayList imageId = new ArrayList();
    protected void btnListProperty_Click(object sender, EventArgs e)
    {
        Property newProperty = new Property(HttpUtility.HtmlEncode(txtHouseNum.Text), HttpUtility.HtmlEncode(txtStreet.Text), HttpUtility.HtmlEncode(txtCity.Text), ddState.SelectedValue, HttpUtility.HtmlEncode(txtZip.Text), HttpUtility.HtmlEncode(txtCountry.Text));


        if (cbStPark.Checked == true) newProperty.setStreetParking(1);
        else newProperty.setStreetParking(0);

        if (cbGarPark.Checked == true) newProperty.setGarageParking(1);
        else newProperty.setGarageParking(0);

        if (cbPool.Checked == true) newProperty.setPool(1);
        else newProperty.setPool(0);

        if (cbBackyard.Checked == true) newProperty.setBackyard(1);
        else newProperty.setBackyard(0);

        if (cbPorch.Checked == true) newProperty.setPorchOrDeck(1);
        else newProperty.setPorchOrDeck(0);

        if (cbPets.Checked == true) newProperty.setPets(1);
        else newProperty.setPets(0);

        if (cbGuest.Checked == true) newProperty.setGuest(1);
        else newProperty.setGuest(0);

        if (cbSmoke.Checked == true) newProperty.setNonSmoking(1);
        else newProperty.setNonSmoking(0);

        if (cbHSS.Checked == true) newProperty.setHomeShareSmarter(1);
        else newProperty.setHomeShareSmarter(0);

        int propertyType = Convert.ToInt16(RadioButtonList.SelectedIndex);
        if (propertyType == 0) newProperty.setPropertyType(1);
        else if (propertyType == 1) newProperty.setPropertyType(2);
        else if (propertyType == 2) newProperty.setPropertyType(3);
        else if (propertyType == 3) newProperty.setPropertyType(4);

        //string value = descriptionMessagebox.Value;

        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = "server=aa1evano00xv2xb.cqpnea2xsqc1.us-east-1.rds.amazonaws.com;database=roommagnetdb;uid=admin;password=Skylinejmu2019;";
        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
        insert.Connection = sc;
        sc.Open();

        string description = HttpUtility.HtmlEncode(Request.Form["descriptionBox"]);

        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@propertyType", newProperty.getPropertyType()));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@houseNum", newProperty.getHouseNumber()));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@street", newProperty.getStreet()));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city", newProperty.getCity()));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@homeState", newProperty.getHomeState()));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", newProperty.getZip()));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@country", newProperty.getCountry()));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RoomPriceRangeLow", newProperty.getRoomPrice()));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RoomPriceRangeHigh", newProperty.getRoomPrice()));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@streetParking", newProperty.getStreetParking()));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@garageParking", newProperty.getGarageParking()));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@backyard", newProperty.getBackyard()));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@porchOrDeck", newProperty.getPorchOrDeck()));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pool", newProperty.getPool()));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nonSmoking", newProperty.getNonSmoking()));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@homeShareSmarter", newProperty.getHomeShareSmarter()));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@date", newProperty.getModDate()));

        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HostID", Session["AccountId"]));

        insert.CommandText = "INSERT INTO PROPERTY VALUES(@propertyType, @houseNum, @street, @city, @homeState, @zip, @country, @roomPriceRangeLow, @roomPriceRangeHigh, @streetParking, @garageParking, @backyard, @porchOrDeck, @pool, @nonSmoking, @homeShareSmarter, @date, @HostID)";
        string check = insert.CommandText;
        Console.Write(check); 
        insert.ExecuteNonQuery();

        sc.Close();

        txtHouseNum.Text = "";
        txtStreet.Text = "";
        txtCity.Text = "";
        ddState.ClearSelection();
        txtZip.Text = "";
        txtCountry.Text = "US";

        System.Data.SqlClient.SqlCommand propertyIdGrab = new System.Data.SqlClient.SqlCommand();
        propertyIdGrab.Connection = sc;
        propertyIdGrab.CommandText = "SELECT MAX(PropertyID) FROM Property";
        sc.Open();

        int propertyID = (int)propertyIdGrab.ExecuteScalar();

        sc.Close();

        System.Data.SqlClient.SqlCommand imageLink = new System.Data.SqlClient.SqlCommand();
        imageLink.Connection = sc;
        sc.Open();
        int arrayImageId = 0;

        for (int i = 0; i < PropertyRoomImages.propertyRoomImagesArray.Count; i++)
        {
            arrayImageId = Convert.ToInt32(PropertyRoomImages.propertyRoomImagesArray[i].ToString());
            imageLink.CommandText = "UPDATE PropertyImages SET PropertyID = @propID WHERE ImagesID = @insertImage";
            imageLink.Parameters.Add(new System.Data.SqlClient.SqlParameter("@insertImage", arrayImageId));
            imageLink.Parameters.Add(new System.Data.SqlClient.SqlParameter("@propID", propertyID));
            imageLink.ExecuteNonQuery();
        }

        PropertyRoomImages.propertyRoomImagesArray.Clear();
        sc.Close();

        System.Data.SqlClient.SqlCommand linkRooms = new System.Data.SqlClient.SqlCommand();
        linkRooms.Connection = sc;
        sc.Open();
        int arrayRoomID = 0;

        for (int i = 0; i < PropertyRoom.roomArray.Count; i++)
        {
            arrayRoomID = Convert.ToInt32(PropertyRoom.roomArray[i].ToString());
            linkRooms.CommandText = "UPDATE PropertyRoom SET PropertyID = @propID WHERE RoomID = @roomID";
            linkRooms.Parameters.Add(new System.Data.SqlClient.SqlParameter("@roomID", arrayRoomID));
            linkRooms.Parameters.Add(new System.Data.SqlClient.SqlParameter("@propID", propertyID));
            linkRooms.ExecuteNonQuery();
        }
        sc.Close();

        Response.Redirect("HostDashboard.aspx");
    }

    protected void FileUpload1_Click(object sender, EventArgs e)
    {
        if (FileUploadControl.HasFile)
        {
            Random rnd = new Random();
            int imageUniqueID = rnd.Next(1, 10000);
            Stream st = FileUploadControl.PostedFile.InputStream;
            string name = Path.GetFileName(FileUploadControl.FileName);
            string myBucketName = "elasticbeanstalk-us-east-1-606091308774"; //your s3 bucket name goes here  
            string s3DirectoryName = "PropertyImages";
            string s3FileName = imageUniqueID.ToString() + @name;
            bool a;
            AmazonUploader myUploader = new AmazonUploader();
            a = myUploader.sendMyFileToS3(st, myBucketName, s3DirectoryName, s3FileName);

            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = "server=aa1evano00xv2xb.cqpnea2xsqc1.us-east-1.rds.amazonaws.com;database=roommagnetdb;uid=admin;password=Skylinejmu2019;";
            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.Connection = sc;
            sc.Open();

            insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@imagefilename", s3FileName));
            insert.CommandText = "INSERT INTO PropertyImages VALUES(NULL, @imagefilename)";

            string check = insert.CommandText;
            Console.Write(check);
            insert.ExecuteNonQuery();

            sc.Close();

            string selectQ = "SELECT MAX(ImagesID) from PropertyImages";
            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand(selectQ, sc);
            sc.Open();
            int test = (int)select.ExecuteScalar();

            PropertyRoomImages.propertyRoomImagesArray.Add(test);

            StatusLabel.Text = "Imaged Saved!";
        }
        else
        {
            StatusLabel.Text = "";
        }
    }

    protected void btnAddRoom_Click(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = "server=aa1evano00xv2xb.cqpnea2xsqc1.us-east-1.rds.amazonaws.com;database=roommagnetdb;uid=admin;password=Skylinejmu2019;";
        sc.Open();
        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
        insert.Connection = sc;

        insert.CommandText = "INSERT INTO PropertyRoom Values(@price, @aboutProperty, @kitchen, @HVAC, @Wifi, @privateBR, @washAndDry, @walkInCloset, NULL)";

        int kitchen;
        int HVAC;
        int Wifi;
        int PrivateBR;
        int WashAndDry;
        int WalkInCloset;

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

        insert.ExecuteNonQuery();

        System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
        select.Connection = sc;

        select.CommandText = "SELECT MAX(RoomID) FROM PropertyRoom";
        int roomID = (int)select.ExecuteScalar();
        PropertyRoom.roomArray.Add(roomID);
    }
}





