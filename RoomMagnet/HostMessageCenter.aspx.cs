﻿using PdfSharp;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheArtOfDev.HtmlRenderer.PdfSharp;

public partial class HostMessageCenter : System.Web.UI.Page
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
        //Host Session 
        if (Session["AccountId"] != null && Convert.ToInt16(Session["type"]) == 2)
        {
            Message.Text = String.Empty;
            //Connection 
            System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["roommagnetdbConnectionString"].ToString());
            //SQL Statement to Select Favorited Tenant onto Message Center
            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
            select.CommandText = "select accountID, firstName, LastName, AccountImage from account where AccountID in (select tenantID from tenant where TenantID in " +
                "(select tenantID from FavoritedTenants where HostID = " + Session["AccountId"] + "));";
            select.Connection = sc;
            sc.Open();

            System.Data.SqlClient.SqlCommand messageC = new System.Data.SqlClient.SqlCommand();
            messageC.Connection = sqlConn;
            sqlConn.Open();

            List<MessageInbox> lst = new List<MessageInbox>();

            System.Data.SqlClient.SqlDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                String imgURL = reader["AccountImage"].ToString();
                if (imgURL == "") imgURL = "noprofileimage.png";
                int tenID = Convert.ToInt32(reader["accountID"].ToString());
                String tenName = reader["firstName"].ToString() + " " + reader["lastName"].ToString();
                messageC.CommandText = "select top(1) MessageContent from Message where FavTenantID in " +
                   "(select FavTenantID from FavoritedTenants where hostID=" + Session["AccountId"].ToString() + "and tenantID=" + tenID + ")" +
                   "order by messageID desc";
                String latestMsg = (string)messageC.ExecuteScalar();

                lst.Add(new MessageInbox() {imageURL = "https://duvjxbgjpi3nt.cloudfront.net/UserImages/" + imgURL, messagerID = tenID, messagerName = tenName, latestMessage = latestMsg});
            }
            sc.Close();
            sqlConn.Close();

            inboxRepeater.DataSource = lst;
            inboxRepeater.DataBind();
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
        
    }
    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton lnk = sender as ImageButton;
        int tenantID = Convert.ToInt16(lnk.Attributes["CustomParameter"].ToString());
        Session["msgTenantID"] = tenantID;
        loadMessages(tenantID);
    }

    public void loadMessages(int tenantID)
    {
        System.Data.SqlClient.SqlCommand selectMessage = new System.Data.SqlClient.SqlCommand();
        System.Data.SqlClient.SqlCommand imgSelect = new System.Data.SqlClient.SqlCommand();

        //Message
        selectMessage.CommandText = "select messageContent, date,MessageType from message where (messageType = 1) and FavTenantID in " +
            "(select FavTenantID from FavoritedTenants where TenantID = " + tenantID + " AND HostID = " + Session["AccountId"].ToString() + ")" +
            " Union " +
            "select messageContent, date,MessageType from message where (messageType = 0) and FavTenantID in " +
            "(select FavTenantID from FavoritedTenants where TenantID =" + tenantID + " AND HostID = " + Session["AccountId"].ToString() + ")" +
            " order by date; ";
        imgSelect.CommandText = "SELECT AccountImage FROM Account WHERE AccountID = " + tenantID;

        selectMessage.Connection = sc;
        imgSelect.Connection = sc;
        sc.Open();

        String accountImg = "";
        if(imgSelect.ExecuteScalar() is System.DBNull)
        {
            accountImg = "noprofileimage.png";
        }
        else
        {
            accountImg = (string)imgSelect.ExecuteScalar();
        }

        System.Data.SqlClient.SqlDataReader reader = selectMessage.ExecuteReader();
        while (reader.Read())
        {
            String message = reader["MessageContent"].ToString();
            String date = reader["Date"].ToString();
            int messageType = Convert.ToInt16(reader["MessageType"].ToString());

            if (messageType == 1)
            {
                StringBuilder myCard = new StringBuilder();
                myCard
                .Append("<div class=\"incoming-msg-img\">")
                .Append("   <img src = \"https://duvjxbgjpi3nt.cloudfront.net/UserImages/" + accountImg + "\" class=\"rounded-circle img-fluid\">")
                .Append("</div>")
                .Append("<div class=\"recieved-msg\">")
                .Append("   <div class=\"recieved-withd-msg\">")
                .Append("       <p>" + message + "</p>")
                .Append("       <span class=\"time-date\">" + date + "</span>")
                .Append("   </div>")
                .Append("</div>");

                Message.Text += myCard.ToString();
            }
            else if (messageType == 0)
            {
                StringBuilder myCard = new StringBuilder();
                myCard
                .Append("<div class=\"outgoing-msg\">")
                .Append("   <div class=\"sent-msg\">")
                .Append("       <p>" + message + "</p>")
                .Append("       <span class=\"time-date\">" + date + "</span>")
                .Append("   </div>")
                .Append("</div>");

                Message.Text += myCard.ToString();
            }
        }
        reader.Close();
        sc.Close();
    }

    protected void messagebtn_Click(object sender, EventArgs e)
    {
        int tenantID = Convert.ToInt32(Session["msgTenantID"].ToString());
        int hostID = Convert.ToInt32(Session["AccountId"].ToString());

        //Selecting FavProp and FavTenant
        System.Data.SqlClient.SqlCommand favTenant = new System.Data.SqlClient.SqlCommand();
        favTenant.Connection = sc;

        favTenant.CommandText = "SELECT FavTenantID FROM FavoritedTenants where TenantID = " + tenantID + "AND HostID=" + hostID;
        sc.Open();
        int favTenantID = Convert.ToInt16(favTenant.ExecuteScalar());
        sc.Close();

        //Insert Message Statement 
        String message = txtMessage.Text;
        String date = DateTime.Now.ToString();

        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
        insert.Connection = sc;
        sc.Open();

        insert.CommandText = "INSERT INTO MESSAGE VALUES(@MessageContent,@MessageType,@Date,@FavTenantID);";
        insert.Parameters.Add(new SqlParameter("@MessageContent", message));
        insert.Parameters.Add(new SqlParameter("@MessageType", "0"));
        insert.Parameters.Add(new SqlParameter("@Date", date));
        insert.Parameters.Add(new SqlParameter("@FavTenantID",favTenantID ));

        insert.ExecuteNonQuery();
        sc.Close();
        txtMessage.Text = String.Empty;

        loadMessages(tenantID);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static void CreateLease()
    {

    }

    protected void createLeaseBtn_Click(object sender, EventArgs e)
    {
        //Generates PDF and uploads to aws
        PdfDocument pdf = PdfGenerator.GeneratePdf("<p><h1>Hello World</h1>This is html rendered text</p>", PageSize.A4);
        pdf.Save("Lease.pdf");//NEED PATH FOR LEASE FOLDER

        //Fetching Settings from WEB.CONFIG file.  
        string emailSender = ConfigurationManager.AppSettings["username"].ToString();
        string emailSenderPassword = ConfigurationManager.AppSettings["password"].ToString();
        string emailSenderHost = ConfigurationManager.AppSettings["smtp"].ToString();
        int emailSenderPort = Convert.ToInt16(ConfigurationManager.AppSettings["portnumber"]);
        Boolean emailIsSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSSL"]);
        string subject = "Roommagnet Intent to Lease";

        //Base class for sending email  
        MailMessage _mailmsg = new MailMessage();

        //Make TRUE because our body text is html  
        _mailmsg.IsBodyHtml = true;

        //Set From Email ID  
        _mailmsg.From = new MailAddress(emailSender);

        //Set To Email ID  
        _mailmsg.To.Add("kylermsnell@gmail.com");
        //_mailmsg.To.Add(hostEmail);

        //Set Subject  
        _mailmsg.Subject = subject;

        //Set Body Text of Email   
        _mailmsg.Body = "Please review attached Intent to Lease form.";

        //Add Lease PDF to email
        Attachment data = new Attachment(pdf.ToString(), MediaTypeNames.Application.Octet);
        _mailmsg.Attachments.Add(data);

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
    }
}