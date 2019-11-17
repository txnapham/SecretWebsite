using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using awsTestUpload;

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
    protected void Page_Load(object sender, EventArgs e)
    {
        txtCountry.Text = "US";
        ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
    }
    protected void btnListProperty_Click(object sender, EventArgs e)
    {
        Property newProperty = new Property(HttpUtility.HtmlEncode(txtHouseNum.Text), HttpUtility.HtmlEncode(txtStreet.Text), HttpUtility.HtmlEncode(txtCity.Text), ddState.SelectedValue, HttpUtility.HtmlEncode(txtZip.Text), HttpUtility.HtmlEncode(txtCountry.Text));

        if (cbGuest.Checked == true)
            txtOtherRules.Text = "it works";

        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = "server=aa1evano00xv2xb.cqpnea2xsqc1.us-east-1.rds.amazonaws.com;database=roommagnetdb;uid=admin;password=Skylinejmu2019;";
        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
        insert.Connection = sc;
        sc.Open();

        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@houseNum", newProperty.getHouseNumber()));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@street", newProperty.getStreet()));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city", newProperty.getCity()));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@homeState", newProperty.getHomeState()));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", newProperty.getZip()));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@country", newProperty.getCountry()));
        //insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@localPriceRangeLow", newProperty.getLocalPriceRangeLow()));
        //insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@localPriceRangeHigh", newProperty.getLocalPriceRangeHigh()));
        //insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@roomPriceRangeLow", newProperty.getRoomPriceRangeLow()));
        //insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("roomPriceRangeHigh", newProperty.getRoomPriceRangeHigh()));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@date", newProperty.getModDate()));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HostID", Session["AccountId"]));

    insert.CommandText = "INSERT INTO PROPERTY VALUES(@houseNum, @street, @city, @homeState, @zip, @country, 0,0,0,0,"+
    "@date, @HostID);";

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

        Response.Redirect("HostDashboard.aspx");
    }
    protected void FileUpload1_Click(object sender, EventArgs e)
    {
        if (FileUploadControl.HasFile)
        {
            while (FileUploadControl.HasFiles)
            {
                Stream st = FileUploadControl.PostedFile.InputStream;
                string name = Path.GetFileName(FileUploadControl.FileName);
                string myBucketName = "elasticbeanstalk-us-east-1-606091308774"; //your s3 bucket name goes here
                string s3DirectoryName = "PropertyImages";
                string s3FileName = @name;
                bool a;
                AmazonUploader myUploader = new AmazonUploader();
                a = myUploader.sendMyFileToS3(st, myBucketName, s3DirectoryName, s3FileName);
                StatusLabel.Text = "Imaged Saved!";
            }

        }
        else
        {
            StatusLabel.Text = "";
        }
    }
}