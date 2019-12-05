using awsTestUpload;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HostAccountCategories : System.Web.UI.Page
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
        //Host Session Verification
        if (Session["AccountId"] != null && Convert.ToInt16(Session["type"]) == 2)
        {

        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }

    protected void btnSet_Click(object sender, EventArgs e)
    {
        //Type of Personality Characterisics 
        int English;
        int Mandarin;
        int German;
        int Spanish;
        int Japanese;
        int French;
        int EarlyR;
        int Introvert;
        int Family;
        int Night;
        int Extrovert;
        int TechSavvy;
        int NonSmoker;

        //Changing  the status in database if toggled on/ off
        if (cbEnglish.Checked == true)
        {
            English = 1;
        }
        else
        {
            English = 0;
        }
        if(cbMandarin.Checked == true)
        {
            Mandarin = 1;
        }
        else
        {
            Mandarin = 0;
        }
        if (cbGerman.Checked == true)
        {
            German = 1;
        }
        else
        {
            German = 0;
        }
        if(cbSpanish.Checked == true)
        {
            Spanish = 1;
        }
        else
        {
            Spanish = 0;
        }
        if(cbJapanese.Checked == true)
        {
            Japanese = 1;
        }
        else
        {
            Japanese = 0;
        }
        if(cbFrench.Checked == true)
        {
            French = 1;
        }
        else
        {
            French = 0;
        }
        if(cbEarlyRiser.Checked == true)
        {
            EarlyR = 1;
        }
        else
        {
            EarlyR = 0;
        }
        if (cbIntrovert.Checked == true)
        {
            Introvert = 1;
        }
        else
        {
            Introvert = 0;
        }
        if (cbFamily.Checked == true)
        {
            Family = 1;
        }
        else
        {
            Family = 0;
        }
        if (cbNightOwl.Checked == true)
        {
            Night = 1;
        }
        else
        {
            Night = 0;
        }
        if (cbExtrovert.Checked == true)
        {
            Extrovert = 1;
        }
        else
        {
            Extrovert = 0;
        }
        if (cbTechSavy.Checked == true)
        {
            TechSavvy = 1;
        }
        else
        {
            TechSavvy = 0;
        }
        if (cbNonSmoker.Checked == true)
        {
            NonSmoker = 1;
        }
        else
        {
            NonSmoker = 0;
        }

        //SQL Statement 
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        //SQL Connection
        sc.ConnectionString = "server=aawnyfad9tm1sf.cqpnea2xsqc1.us-east-1.rds.amazonaws.com; database =roommagnetdb;uid=admin;password=Skylinejmu2019;";
        sc.Open();
        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
        insert.Connection = sc;
        //Inserting Values into Database for Personality Characterisitcs
        insert.CommandText = "INSERT into Characteristics Values(" + Convert.ToInt32(HttpContext.Current.Session["AccountId"].ToString()) 
            + ", " + Extrovert + ", " + Introvert + ", " + NonSmoker + ", " + EarlyR + ", " + Night + ", " + TechSavvy + ", " + Family + 
            ", " + English + ", " + Spanish + ", " + Mandarin + ", " + Japanese + ", " + German + ", " + French + ");";
        //Execute and Close SQL
        insert.ExecuteNonQuery();
        sc.Close();
        HostImageUpate();
        Response.Redirect("HostDashboard.aspx");
    }

    protected void HostImageUpate()
    {
        if (HostImageUpload.HasFile)
        {
            // Upload image to S3
            Random rnd = new Random();
            int imageUniqueID = rnd.Next(1, 10000);
            Stream st = HostImageUpload.PostedFile.InputStream;
            string name = Path.GetFileName(HostImageUpload.FileName);
            string myBucketName = "elasticbeanstalk-us-east-1-606091308774"; //your s3 bucket name goes here  
            string s3DirectoryName = "UserImages";
            string s3FileName = imageUniqueID.ToString() + @name;
            bool a;
            AmazonUploader myUploader = new AmazonUploader();
            a = myUploader.sendMyFileToS3(st, myBucketName, s3DirectoryName, s3FileName);

            // Grab AccountID to update correct account
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = "server=aawnyfad9tm1sf.cqpnea2xsqc1.us-east-1.rds.amazonaws.com; database =roommagnetdb;uid=admin;password=Skylinejmu2019;";
            System.Data.SqlClient.SqlCommand update = new System.Data.SqlClient.SqlCommand();
            update.Connection = sc;
            sc.Open();

            update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HostID", Session["AccountID"]));
            update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@imagefilename", s3FileName));
            update.CommandText = "UPDATE Account SET AccountImage = @imagefilename WHERE AccountID = @HostID";

            string check = update.CommandText;
            Console.Write(check);
            update.ExecuteNonQuery();

            sc.Close();

        }
        else
        {
            //Do nothing
        }
    }

}