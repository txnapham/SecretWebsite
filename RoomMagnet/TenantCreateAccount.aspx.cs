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

public partial class TenantCreateAccount : System.Web.UI.Page
{
    //Access to Pages with Certain Profile 
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
        //Birthday 
        DateTime bday = new DateTime();
        if (txtBday.Text == "")
        {
            lblError.Text = "Please enter the birthdate (MM/DD/YYYY). <br/>";
        }
        else
        {
            //Birthdate validation
            DateTime today = DateTime.Now;
            bday = DateTime.Parse(txtBday.Text, new System.Globalization.CultureInfo("pt-BR"));
            int age = today.Year - bday.Year;
            if (bday > today.AddYears(-age))
            {
                age--;
            }
            if (age < 18)
            {
                lblError.Text = "You must be at least 18 years old.";
            }
            else
            {
                System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
                sc.ConnectionString = "server=aa9vyec53lz6c8.cqpnea2xsqc1.us-east-1.rds.amazonaws.com; database =roommagnetdb;uid=admin;password=Skylinejmu2019;";
                sc.Open();
                System.Data.SqlClient.SqlCommand checkEmailCount = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
                checkEmailCount.Connection = sc;
                insert.Connection = sc;

                int emailCount;

                //create new account and tenant object
                Account newAccount = new Account(HttpUtility.HtmlEncode(txtFN.Text), HttpUtility.HtmlEncode(txtMN.Text), HttpUtility.HtmlEncode(txtLN.Text),
                    HttpUtility.HtmlEncode(txtPhone.Text), DateTime.Parse(txtBday.Text, new System.Globalization.CultureInfo("pt-BR")), HttpUtility.HtmlEncode(txtEmail.Text),
                    HttpUtility.HtmlEncode(txtHouseNum.Text), HttpUtility.HtmlEncode(txtStreet.Text), HttpUtility.HtmlEncode(txtCity.Text), ddState.SelectedValue,
                    HttpUtility.HtmlEncode(txtZip.Text), "US", Int32.Parse("3"), Int32.Parse("3"));
                Tenant newTenant = new Tenant(newAccount, Int32.Parse("0"), "Student");

                checkEmailCount.CommandText = "SELECT COUNT(*) FROM ACCOUNT WHERE EMAIL = @emailCheck";
                checkEmailCount.Parameters.Add(new SqlParameter("@emailCheck", newAccount.getEmail()));

                emailCount = (int)checkEmailCount.ExecuteScalar();
                //Insert into Account
                if (emailCount < 1)
                {
                    insert.CommandText = "INSERT into Account VALUES(@fName, NULLIF(@mName, ''), @lName, @phone, @bday, @email, @HouseNbr, @street, @city, @state, @zip, @country, NULL, @AccType, @ModDate, @PID); " +
                                        "INSERT into Tenant VALUES(@@IDENTITY, @BackCheck, @TenantReason); " +
                                        "INSERT into Password VALUES((SELECT MAX(TenantID) from Tenant), @email, @password);";

                    //Insert into ACCOUNT
                    insert.Parameters.Add(new SqlParameter("@fName", newTenant.getFirstName()));
                    insert.Parameters.Add(new SqlParameter("@mName", newTenant.getMiddleName()));
                    insert.Parameters.Add(new SqlParameter("@lName", newTenant.getLastName()));
                    insert.Parameters.Add(new SqlParameter("@phone", newTenant.getPhone()));
                    insert.Parameters.Add(new SqlParameter("@bday", newTenant.getBday()));
                    insert.Parameters.Add(new SqlParameter("@email", newTenant.getEmail()));
                    insert.Parameters.Add(new SqlParameter("@HouseNbr", newTenant.getHouseNumber()));
                    insert.Parameters.Add(new SqlParameter("@street", newTenant.getStreet()));
                    insert.Parameters.Add(new SqlParameter("@city", newTenant.getCity()));
                    insert.Parameters.Add(new SqlParameter("@state", newTenant.getState()));
                    insert.Parameters.Add(new SqlParameter("@zip", newTenant.getZip()));
                    insert.Parameters.Add(new SqlParameter("@country", newTenant.getCountry()));
                    insert.Parameters.Add(new SqlParameter("@AccType", newTenant.getAccType()));
                    insert.Parameters.Add(new SqlParameter("@ModDate", newTenant.getModDate()));
                    insert.Parameters.Add(new SqlParameter("@PID", newTenant.getPID()));

                    //Insert into TENANT
                    insert.Parameters.Add(new SqlParameter("@BackCheck", newTenant.getBackgroundStatus()));
                    insert.Parameters.Add(new SqlParameter("@TenantReason", newTenant.getTenantReason()));

                    //Insert into PASSWORD
                    insert.Parameters.Add(new SqlParameter("@password", PasswordHash.HashPassword(txtPassword.Text))); // hash entered password

                    insert.ExecuteNonQuery();
                    //Tenant Access
                    Session["type"] = 3;

                    System.Data.SqlClient.SqlCommand getAcctID = new System.Data.SqlClient.SqlCommand();
                    getAcctID.CommandText = "SELECT AccountID FROM Account WHERE EMAIL = @emailCheck";
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


                    string subject = "Welcome to roommagnet!";

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

                    //send email if user has check the background checkbox
                    //if (cbBackCheck.Checked == true)
                    //{
                    //    //Fetching Email Body Text from EmailTemplate File.  
                    //    string FilePath2 = Server.MapPath("~/BackgroundEmail.aspx");
                    //    StreamReader str2 = new StreamReader(FilePath);
                    //    string MailText2 = str2.ReadToEnd();
                    //    str2.Close();

                    //    //Replace [newusername] = signup user name   
                    //    MailText2 = MailText.Replace("[newusername]", txtFN.Text.Trim());


                    //    string subject2 = "Begin your Background Check!";

                    //    //Base class for sending email  
                    //    MailMessage _mailmsg2 = new MailMessage();

                    //    //Make TRUE because our body text is html  
                    //    _mailmsg2.IsBodyHtml = true;

                    //    //Set From Email ID  
                    //    _mailmsg2.From = new MailAddress(emailSender);

                    //    //Set To Email ID  
                    //    _mailmsg2.To.Add(txtEmail.Text.ToString());

                    //    //Set Subject  
                    //    _mailmsg2.Subject = subject2;

                    //    //Set Body Text of Email   
                    //    _mailmsg2.Body = MailText;


                    //    //Now set your SMTP   
                    //    SmtpClient _smtp2 = new SmtpClient();

                    //    //Set HOST server SMTP detail  
                    //    _smtp2.Host = emailSenderHost;

                    //    //Set PORT number of SMTP  
                    //    _smtp2.Port = emailSenderPort;

                    //    //Set SSL --> True / False  
                    //    _smtp2.EnableSsl = emailIsSSL;

                    //    //Set Sender UserEmailID, Password  
                    //    NetworkCredential _network2 = new NetworkCredential(emailSender, emailSenderPassword);
                    //    _smtp2.Credentials = _network2;

                    //    //Send Method will send your MailMessage create above.  
                    //    _smtp2.Send(_mailmsg2);

                    //    //Clear text boxes
                    //    txtFN.Text = "";
                    //    txtMN.Text = "";
                    //    txtLN.Text = "";
                    //    txtBday.Text = "";
                    //    txtEmail.Text = "";
                    //    txtPhone.Text = "";
                    //    txtPassword.Text = "";
                    //    txtHouseNum.Text = "";
                    //    txtStreet.Text = "";
                    //    txtCity.Text = "";
                    //    ddState.ClearSelection();
                    //    txtZip.Text = "";

                    //    Response.Redirect("TenantAccountCategories.aspx");
                    //}

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

                    Response.Redirect("TenantAccountCategories.aspx");
                }
                else
                {
                    sc.Close();
                    //Clear text boxes
                }
            }
        }
            
    }
}