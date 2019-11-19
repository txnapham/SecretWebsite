using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.IO;

public partial class HostCreateAccount : System.Web.UI.Page
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
        ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
    }
    protected void btnCreateAccount_Click(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = "server=aa1evano00xv2xb.cqpnea2xsqc1.us-east-1.rds.amazonaws.com;database=roommagnetdb;uid=admin;password=Skylinejmu2019;";
        sc.Open();
        System.Data.SqlClient.SqlCommand checkEmailCount = new System.Data.SqlClient.SqlCommand();
        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
        checkEmailCount.Connection = sc;
        insert.Connection = sc;

        int emailCount;

        //create new account and host object
        //use HttpUtility.HtmlEncode for these inputs
        Account newAccount = new Account(HttpUtility.HtmlEncode(txtFN.Text), HttpUtility.HtmlEncode(txtMN.Text), HttpUtility.HtmlEncode(txtLN.Text), HttpUtility.HtmlEncode(txtPhone.Text), DateTime.Parse(txtBday.Text), HttpUtility.HtmlEncode(txtEmail.Text), HttpUtility.HtmlEncode(txtHouseNum.Text), HttpUtility.HtmlEncode(txtStreet.Text), HttpUtility.HtmlEncode(txtCity.Text), ddState.SelectedValue, HttpUtility.HtmlEncode(txtZip.Text), "US", Int32.Parse("2"), Int32.Parse("2"));
        Host newHost = new Host(newAccount, "N", "Retiree");

        checkEmailCount.CommandText = "SELECT COUNT(*) FROM ACCOUNT WHERE EMAIL = @emailCheck";
        checkEmailCount.Parameters.Add(new SqlParameter("@emailCheck", newAccount.getEmail()));

        emailCount = (int)checkEmailCount.ExecuteScalar();

        if (emailCount < 1)
        {
            insert.CommandText = "INSERT into Account VALUES (@fName, @mName, @lName, @phone, @bday, @email, @HouseNbr, @street, @city, @state, @zip, @country, NULL, @AccType, @ModDate, @PID); " +
                "INSERT into Host VALUES(@@Identity, @BackCheck, @HostReason);" +
                "INSERT into Password VALUES((SELECT MAX(HostID) from Host), @email, @password);";

            //Insert into ACCOUNT
            insert.Parameters.Add(new SqlParameter("@fName", newHost.getFirstName()));
            insert.Parameters.Add(new SqlParameter("@mName", newHost.getMiddleName()));
            insert.Parameters.Add(new SqlParameter("@lName", newHost.getLastName()));
            insert.Parameters.Add(new SqlParameter("@phone", newHost.getPhone()));
            insert.Parameters.Add(new SqlParameter("@bday", newHost.getBday()));
            insert.Parameters.Add(new SqlParameter("@email", newHost.getEmail()));
            insert.Parameters.Add(new SqlParameter("@HouseNbr", newHost.getHouseNumber()));
            insert.Parameters.Add(new SqlParameter("@street", newHost.getStreet()));
            insert.Parameters.Add(new SqlParameter("@city", newHost.getCity()));
            insert.Parameters.Add(new SqlParameter("@state", newHost.getState()));
            insert.Parameters.Add(new SqlParameter("@zip", newHost.getZip()));
            insert.Parameters.Add(new SqlParameter("@country", newHost.getCountry()));
            insert.Parameters.Add(new SqlParameter("@AccType", newHost.getAccType()));
            insert.Parameters.Add(new SqlParameter("@ModDate", newHost.getModDate()));
            insert.Parameters.Add(new SqlParameter("@PID", newHost.getPID()));

            //Insert into HOST
            insert.Parameters.Add(new SqlParameter("@BackCheck", newHost.getBackCheck()));
            insert.Parameters.Add(new SqlParameter("@HostReason", newHost.getHostReason()));

            //Insert into PASSWORD
            insert.Parameters.Add(new SqlParameter("@password", PasswordHash.HashPassword(txtPassword.Text))); // hash entered password

            insert.ExecuteNonQuery();

            //Label1.Text = "Success";

            Session["type"] = 2;

            System.Data.SqlClient.SqlCommand getAcctID = new System.Data.SqlClient.SqlCommand();
            getAcctID.CommandText = "SELECT AccountID FROM ACCOUNT WHERE EMAIL = @emailCheck";
            getAcctID.Parameters.Add(new SqlParameter("@emailCheck", newAccount.getEmail()));
            getAcctID.Connection = sc;
            int AccountID = (int)getAcctID.ExecuteScalar();

            Session["AccountId"] = AccountID;

            sc.Close();

            //Fetching Settings from WEB.CONFIG file.  
            string emailSender = ConfigurationManager.AppSettings["username"].ToString();
            string emailSenderPassword = ConfigurationManager.AppSettings["password"].ToString();
            string emailSenderHost = ConfigurationManager.AppSettings["smtp"].ToString();
            int emailSenderPort = Convert.ToInt16(ConfigurationManager.AppSettings["portnumber"]);
            Boolean emailIsSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSSL"]);


            //Fetching Email Body Text from EmailTemplate File.  
            string FilePath = Server.MapPath("~/Email.aspx");
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();

            //Repalce [newusername] = signup user name   
            MailText = MailText.Replace("[newusername]", txtFN.Text.Trim());


            string subject = "Welcome to Roommagnet!";

            //Base class for sending email  
            MailMessage _mailmsg = new MailMessage();

            //Make TRUE because our body text is html  
            _mailmsg.IsBodyHtml = true;

            //Set From Email ID  
            _mailmsg.From = new MailAddress(emailSender);

            //Set To Email ID  
            _mailmsg.To.Add(txtEmail.Text.ToString());

            //Set Subject  
            _mailmsg.Subject = subject;

            //Set Body Text of Email   
            _mailmsg.Body = MailText;


            //Now set your SMTP   
            SmtpClient _smtp = new SmtpClient();

            //Set HOST server SMTP detail  
            _smtp.Host = emailSenderHost;

            //Set PORT number of SMTP  
            _smtp.Port = emailSenderPort;

            //Set SSL --> True / False  
            _smtp.EnableSsl = emailIsSSL;

            //Set Sender UserEmailID, Password  
            NetworkCredential _network = new NetworkCredential(emailSender, emailSenderPassword);
            _smtp.Credentials = _network;

            //Send Method will send your MailMessage create above.  
            _smtp.Send(_mailmsg);

            //Clear text boxes
            txtFN.Text = "";
            txtMN.Text = "";
            txtLN.Text = "";
            txtBday.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtPassword.Text = "";
            txtHouseNum.Text = "";
            txtStreet.Text = "";
            txtCity.Text = "";
            ddState.ClearSelection();
            txtZip.Text = "";

            Response.Redirect("HostAccountCategories.aspx");

        }
        else
        {
            //Label1.Text = "Error";
            sc.Close();
        }
    }
}