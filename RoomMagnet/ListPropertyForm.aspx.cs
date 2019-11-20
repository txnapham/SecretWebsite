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


            //Select Statements properties
            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
            select.CommandText = "SELECT FirstName, AccountImage FROM Account WHERE AccountID = " + accountID + ";";
            //Connections
            select.Connection = sc;
            sc.Open();
            //Populating Tenant Part of Host Dashboard
            System.Data.SqlClient.SqlDataReader readerHost = select.ExecuteReader();
            while (readerHost.Read())
            {
                String tenantName = readerHost["FirstName"].ToString();
                String filename = readerHost["AccountImage"].ToString();
                // No image uploaded (currently default image in S3)
                if (filename == "") filename = "defaulttenantimg.jpg";
                // User dashboard dynamically updated using S3
                StringBuilder tenantImage = new StringBuilder();
                tenantImage
                .Append("<img alt=\"image\" src=\"https://duvjxbgjpi3nt.cloudfront.net/UserImages/" + filename + "\" class=\" rounded-circle img-fluid\" width=\"30%\" height=\"auto\">");
                HostCard.Text += tenantImage.ToString();
            }
            sc.Close();
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

        double roomPrice;
        if (txtPrice.Text == "") 
        {
             roomPrice = 0;
        }
        else
        roomPrice = Convert.ToDouble(txtPrice.Text);

        newProperty.setRoomPrices(roomPrice);

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

        for (int i = 0; i < PropertyRoomImages.propertyRoomImagesArray.Count; i++)
        {
            imageLink.CommandText = "UPDATE PropertyImages SET PropertyID = @propID WHERE ImagesID = @insertImage";
            string arrayImageId = PropertyRoomImages.propertyRoomImagesArray[i].ToString();
            imageLink.Parameters.Add(new System.Data.SqlClient.SqlParameter("@insertImage", arrayImageId));
            imageLink.Parameters.Add(new System.Data.SqlClient.SqlParameter("@propID", propertyID));
            imageLink.ExecuteNonQuery();
        }

        PropertyRoomImages.propertyRoomImagesArray.Clear();
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
}





