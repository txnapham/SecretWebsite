using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using awsTestUpload;
using System.Text;

public partial class TenantEditProfile : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        //Access to Page for Certain Account Types
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
        //Tenant Access
        if (Session["AccountId"] != null && Convert.ToInt16(Session["type"]) == 3)
        {
            if (IsPostBack != true)
            {
                System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
                sc.ConnectionString = "server=aawnyfad9tm1sf.cqpnea2xsqc1.us-east-1.rds.amazonaws.com; database =roommagnetdb;uid=admin;password=Skylinejmu2019;";
                sc.Open();
                int accountID = Convert.ToInt16(HttpContext.Current.Session["AccountId"].ToString());
                System.Data.SqlClient.SqlCommand search = new System.Data.SqlClient.SqlCommand();
                search.Connection = sc;
                search.CommandText = "SELECT FirstName, ISNULL(MiddleName,''), LastName, HomeNumber, Street, City, HomeState, Country, Zip, PhoneNumber, Email FROM Account WHERE AccountID = " + accountID + ";";

                System.Data.SqlClient.SqlCommand selectHost = new System.Data.SqlClient.SqlCommand();
                selectHost.CommandText = "SELECT FirstName, AccountImage FROM Account WHERE AccountID = " + accountID + ";";
                //Connections
                selectHost.Connection = sc;

                //Populating Tenant Part of Host Dashboard
                System.Data.SqlClient.SqlDataReader readerTenantImage = selectHost.ExecuteReader();
                while (readerTenantImage.Read())
                {
                    String tenantName = readerTenantImage["FirstName"].ToString();
                    String filename = readerTenantImage["AccountImage"].ToString();
                    // No image uploaded (currently default image in S3)
                    if (filename == "") filename = "defaulttenantimg.jpg";
                    // User dashboard dynamically updated using S3
                    StringBuilder tenantImage = new StringBuilder();
                    tenantImage
                    .Append("<img alt=\"image\" src=\"https://duvjxbgjpi3nt.cloudfront.net/UserImages/" + filename + "\" class=\" rounded-circle img-fluid\" width=\"30%\" height=\"auto\">");
                    tenantCard.Text += tenantImage.ToString();
                }
                readerTenantImage.Close();

                SqlDataReader searching = search.ExecuteReader();
                //checks the database for matches
                while (searching.Read())
                {
                    txtFN.Text = searching.GetString(0);
                    txtMN.Text = searching.GetString(1);
                    txtLN.Text = searching.GetString(2);
                    txtHouseNum.Text = searching.GetString(3);
                    txtStreet.Text = searching.GetString(4);
                    txtCity.Text = searching.GetString(5);
                    ddState.SelectedValue = searching.GetString(6);
                    ddCountry.SelectedValue = searching.GetString(7);
                    txtZip.Text = searching.GetString(8);
                    txtPhone.Text = searching.GetString(9);
                    txtEmail.Text = searching.GetString(10);
                }
                searching.Close();
                sc.Close();
                //Checks for characterisitcs
                System.Data.SqlClient.SqlCommand character = new System.Data.SqlClient.SqlCommand();
                character.Connection = sc;
                //Show Current Characteristics Query
                character.CommandText = "SELECT * from [Characteristics] where AccountID =" + Session["AccountId"] + ";";
                sc.Open();
                SqlDataReader rdr = character.ExecuteReader();
                //Show Current Characteristics Results
                while (rdr.Read())
                {
                    //Extrovert 
                    if (rdr["Extrovert"].ToString() == "1")
                    {
                        cbExtrovert.Checked = true;
                    }
                    //Introvert
                    if (rdr["Introvert"].ToString() == "1")
                    {
                        cbIntrovert.Checked = true;
                    }
                    //NonSmoking
                    if (rdr["NonSmoker"].ToString() == "1")
                    {
                        cbNonSmoker.Checked = true;
                    }
                    //Early Riser
                    if (rdr["EarlyRiser"].ToString() == "1")
                    {
                        cbEarlyRiser.Checked = true;
                    }
                    //Night Owl
                    if (rdr["NightOwl"].ToString() == "1")
                    {
                        cbNightOwl.Checked = true;
                    }
                    //TechSavvy
                    if (rdr["TechSavvy"].ToString() == "1")
                    {
                        cbTechSavy.Checked = true;
                    }
                    //FamilyOriented
                    if (rdr["FamilyOriented"].ToString() == "1")
                    {
                        fbFamily.Checked = true;
                    }
                    //English
                    if (rdr["English"].ToString() == "1")
                    {
                        cbEnglish.Checked = true;
                    }
                    //Spanish
                    if (rdr["Spanish"].ToString() == "1")
                    {
                        cbSpanish.Checked = true;
                    }
                    //Mandarin
                    if (rdr["Mandarin"].ToString() == "1")
                    {
                        cbMandarin.Checked = true;
                    }
                    //Japanese
                    if (rdr["Japanese"].ToString() == "1")
                    {
                        cbJapanese.Checked = true;
                    }
                    //German
                    if (rdr["German"].ToString() == "1")
                    {
                        cbGerman.Checked = true;
                    }
                    //French
                    if (rdr["French"].ToString() == "1")
                    {
                        cbFrench.Checked = true;
                    }
                    
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int accountID = Convert.ToInt16(HttpContext.Current.Session["AccountId"].ToString());
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = "server=aawnyfad9tm1sf.cqpnea2xsqc1.us-east-1.rds.amazonaws.com; database =roommagnetdb;uid=admin;password=Skylinejmu2019;";
        sc.Open();

        //Update the Account Address
        System.Data.SqlClient.SqlCommand update = new System.Data.SqlClient.SqlCommand();
        System.Data.SqlClient.SqlCommand updatePassEmail = new System.Data.SqlClient.SqlCommand();
        update.Connection = sc;
        updatePassEmail.Connection = sc;

        updatePassEmail.CommandText = "UPDATE Password SET Email = @Email WHERE Email = (SELECT Email FROM Account WHERE AccountID = " + accountID + ")";
        updatePassEmail.Parameters.Add(new SqlParameter("@Email", txtEmail.Text));
        updatePassEmail.ExecuteNonQuery();

        update.CommandText = "UPDATE Account SET FirstName = @fn, MiddleName = NULLIF(@mn,''), LastName = @ln, PhoneNumber = @number, Email = @email, HomeNumber = @HouseNbr, Street = @street, City = @city, HomeState = @state, " +
            "Country = @country, Zip = @zip WHERE AccountID = @accountID;";
        update.Parameters.Add(new SqlParameter("@fn", txtFN.Text));
        update.Parameters.Add(new SqlParameter("@mn", txtMN.Text));
        update.Parameters.Add(new SqlParameter("@ln", txtLN.Text));
        update.Parameters.Add(new SqlParameter("@number", txtPhone.Text));
        update.Parameters.Add(new SqlParameter("@email", txtEmail.Text));
        update.Parameters.Add(new SqlParameter("@HouseNbr", this.txtHouseNum.Text));
        update.Parameters.Add(new SqlParameter("@street", this.txtStreet.Text));
        update.Parameters.Add(new SqlParameter("@city", this.txtCity.Text));
        update.Parameters.Add(new SqlParameter("@state", this.ddState.SelectedValue));
        update.Parameters.Add(new SqlParameter("@country", this.ddCountry.SelectedValue));
        update.Parameters.Add(new SqlParameter("@zip", this.txtZip.Text));
        update.Parameters.Add(new SqlParameter("@accountID", accountID));

        update.ExecuteNonQuery();
        sc.Close();
        //Characteristic Variables
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
        //Changing Characteristic Preferences//////////////
        //Languages
        //English
        if (cbEnglish.Checked == true)
        {
            English = 1;
        }
        else
        {
            English = 0;
        }
        //Mandarin
        if (cbMandarin.Checked == true)
        {
            Mandarin = 1;
        }
        else
        {
            Mandarin = 0;
        }
        //German
        if (cbGerman.Checked == true)
        {
            German = 1;
        }
        else
        {
            German = 0;
        }
        //Spanish
        if (cbSpanish.Checked == true)
        {
            Spanish = 1;
        }
        else
        {
            Spanish = 0;
        }
        //Japanese
        if (cbJapanese.Checked == true)
        {
            Japanese = 1;
        }
        else
        {
            Japanese = 0;
        }
        //French
        if (cbFrench.Checked == true)
        {
            French = 1;
        }
        else
        {
            French = 0;
        }
        //LifeStyle Characteristics
        //Early Riser
        if (cbEarlyRiser.Checked == true)
        {
            EarlyR = 1;
        }
        else
        {
            EarlyR = 0;
        }
        //Introvert
        if (cbIntrovert.Checked == true)
        {
            Introvert = 1;
        }
        else
        {
            Introvert = 0;
        }
        //Family Oriented
        if (fbFamily.Checked == true)
        {
            Family = 1;
        }
        else
        {
            Family = 0;
        }
        //Night Owl
        if (cbNightOwl.Checked == true)
        {
            Night = 1;
        }
        else
        {
            Night = 0;
        }
        //Extrovert
        if (cbExtrovert.Checked == true)
        {
            Extrovert = 1;
        }
        else
        {
            Extrovert = 0;
        }
        //Tech Savvy
        if (cbTechSavy.Checked == true)
        {
            TechSavvy = 1;
        }
        else
        {
            TechSavvy = 0;
        }
        //NonSmoker
        if (cbNonSmoker.Checked == true)
        {
            NonSmoker = 1;
        }
        else
        {
            NonSmoker = 0;
        }
        sc.Open();

        System.Data.SqlClient.SqlCommand charCheck = new System.Data.SqlClient.SqlCommand();
        System.Data.SqlClient.SqlCommand charInsertUpdate = new System.Data.SqlClient.SqlCommand();
        charCheck.Connection = sc;
        charInsertUpdate.Connection = sc;

        charCheck.CommandText = "SELECT COUNT(*) FROM Characteristics WHERE AccountID =" + Session["AccountId"].ToString();
        int charExist = (int)charCheck.ExecuteScalar();

        if (charExist == 0)
        {
            charInsertUpdate.CommandText = "INSERT into Characteristics Values(" + Convert.ToInt32(HttpContext.Current.Session["AccountId"].ToString())
            + ", " + Extrovert + ", " + Introvert + ", " + NonSmoker + ", " + EarlyR + ", " + Night + ", " + TechSavvy + ", " + Family +
            ", " + English + ", " + Spanish + ", " + Mandarin + ", " + Japanese + ", " + German + ", " + French + ");";
        }
        else if (charExist == 1)
        {
            charInsertUpdate.CommandText = "Update Characteristics SET " + "Extrovert=" + Extrovert + ", " + "Introvert=" +
            Introvert + ", " + "NonSmoker=" + NonSmoker + ", " + "EarlyRiser=" + EarlyR + ", " + "NightOwl=" + Night + ", " + "TechSavvy=" + TechSavvy + ", " + "FamilyOriented="
            + Family + ", " + "English=" + English + ", " + "Spanish=" + Spanish + ", " + "Mandarin=" + Mandarin + ", " + "Japanese=" + Japanese + ", " + "German=" + German +
            ", " + "French=" + French + "Where " + "AccountID=" + Session["AccountId"].ToString() + ";";
        }
        charInsertUpdate.ExecuteNonQuery();
        sc.Close();
        TenantImageUpdate();
    }

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        int accountID = Convert.ToInt16(HttpContext.Current.Session["AccountId"].ToString());
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection();
        sqlConn.ConnectionString = "server=aawnyfad9tm1sf.cqpnea2xsqc1.us-east-1.rds.amazonaws.com; database =roommagnetdb;uid=admin;password=Skylinejmu2019;";
        sc.ConnectionString = "server=aawnyfad9tm1sf.cqpnea2xsqc1.us-east-1.rds.amazonaws.com; database =roommagnetdb;uid=admin;password=Skylinejmu2019;";
        sc.Open();
        sqlConn.Open();

        System.Data.SqlClient.SqlCommand findPass = new System.Data.SqlClient.SqlCommand();
        findPass.Connection = sc;
        // SELECT PASSWORD STRING WHERE THE ENTERED USERNAME MATCHES
        findPass.CommandText = "SELECT PasswordHash from Password where AccountID = @AccountID";
        findPass.Parameters.Add(new SqlParameter("@AccountID", accountID));
        // create a reader
        SqlDataReader reader = findPass.ExecuteReader(); 
        // if the email exists, it will continue
        if (reader.HasRows)
        {
            // this will read the single record that matches the entered email
            while (reader.Read()) 
            {
                // store the database password into this variable
                string storedHash = reader["PasswordHash"].ToString();
                // if the entered password matches what is stored, it will allow for password change
                if (PasswordHash.ValidatePassword(txtPrevPassword.Text, storedHash)) 
                {
                    System.Data.SqlClient.SqlCommand newPass = new System.Data.SqlClient.SqlCommand();
                    newPass.Connection = sqlConn;
                    newPass.CommandText = "UPDATE Password SET PasswordHash = @password WHERE AccountID = @accountID;";
                    //Insert into PASSWORD
                    newPass.Parameters.Add(new SqlParameter("@AccountID", accountID));
                    newPass.Parameters.Add(new SqlParameter("@password", PasswordHash.HashPassword(txtReenterPassword.Text))); // hash entered password
                    newPass.ExecuteNonQuery();
                    sqlConn.Close();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MyFunction()", true);
                }
                else
                {
                    lblPrev.Text = "Incorrect Password";
                }
            }
        }
        else // if the account doesn't exist, it will show failure

            sc.Close();

    }

    protected void TenantImageUpdate()
    {
        if (TenantImageUpload.HasFile)
        {
            // Upload image to S3
            Random rnd = new Random();
            int imageUniqueID = rnd.Next(1, 10000);
            Stream st = TenantImageUpload.PostedFile.InputStream;
            string name = Path.GetFileName(TenantImageUpload.FileName);
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

            update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TenantID", Session["AccountID"]));
            update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@imagefilename", s3FileName));
            update.CommandText = "UPDATE Account SET AccountImage = @imagefilename WHERE AccountID = @TenantID";

            string check = update.CommandText;
            Console.Write(check);
            update.ExecuteNonQuery();

            sc.Close();

            StatusLabel.Text = "Looking good! Profile image updated.";
        }
        else
        {
            StatusLabel.Text = "";
        }
    }

}