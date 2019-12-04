using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TenantMessageCenter : System.Web.UI.Page
{
    System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["roommagnetdbConnectionString"].ToString());

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
        //Set Message Center Compenents to non visbile
        if(!IsPostBack)
        {
            txtMessage.Visible = false;
            aptBtn.Visible = false;
            videoChat.Visible = false;
            LinkButton2.Visible = false;
            viewLeaseBtn.Visible = false;
        }
        //Tenant Access
        if (Session["AccountId"] != null && Convert.ToInt16(Session["type"]) == 3)
        {
            Message.Text = String.Empty;

            System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["roommagnetdbConnectionString"].ToString());

            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
            select.CommandText = "select accountID, firstName, LastName, AccountImage from account where AccountID in (select HostID from Host where HostID in " +
                "(select HostID from FavoritedTenants where TenantID = " + Session["AccountId"] + "));";
            select.Connection = sc;
            sc.Open();

            System.Data.SqlClient.SqlCommand messageC = new System.Data.SqlClient.SqlCommand();
            messageC.Connection = sqlConn;
            sqlConn.Open();

            List<MessageInbox> lst = new List<MessageInbox>();

            System.Data.SqlClient.SqlDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                //Profile Image 
                String imgURL = reader["AccountImage"].ToString();
                if (imgURL == "") imgURL = "noprofileimage.png";
                int hostID = Convert.ToInt32(reader["accountID"].ToString());
                //Show Host Name
                String hostName = reader["firstName"].ToString() + " " + reader["lastName"].ToString();
                //Latest Message
                messageC.CommandText = "select top(1) MessageContent from Message where FavTenantID in " +
                   "(select FavTenantID from FavoritedTenants where tenantID=" + Session["AccountId"].ToString() + "and hostID=" + hostID + ")" +
                   "order by messageID desc";
                String latestMsg = (string)messageC.ExecuteScalar();

                lst.Add(new MessageInbox() {imageURL = "https://duvjxbgjpi3nt.cloudfront.net/UserImages/" + imgURL, messagerID = hostID, messagerName = hostName, latestMessage = latestMsg});
            }
            reader.Close();
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
        int hostID = Convert.ToInt32(lnk.Attributes["CustomParameter"].ToString());
        Session["msgHostID"] = hostID;
        int tenantID = Convert.ToInt32(Session["AccountId"].ToString());

        SqlCommand selectLease = new SqlCommand();
        selectLease.Connection = sc;
        selectLease.CommandText = "Select Agreed from lease where TenantID =" + tenantID + " AND " + "HostID =" +hostID;
        sc.Open();
        int agreed = Convert.ToInt16(selectLease.ExecuteScalar().ToString());
        sc.Close();

        loadMessages(hostID);
        txtMessage.Visible = true;
        aptBtn.Visible = true;
        videoChat.Visible = true;
        LinkButton2.Visible = true;
        if(agreed == 1)
        {
            viewLeaseBtn.Visible = true;
        }
    }

    public void loadMessages(int hostID)
    {
        System.Data.SqlClient.SqlCommand selectMessage = new System.Data.SqlClient.SqlCommand();
        System.Data.SqlClient.SqlCommand imgSelect = new System.Data.SqlClient.SqlCommand();

        //Message
        selectMessage.CommandText = "select messageContent, date, MessageType from message where (messageType = 1) and FavTenantID in " +
            "(select FavTenantID from FavoritedTenants where HostID = " + hostID + " AND TenantID = " + Session["AccountId"].ToString() + ")" +
            " Union " +
            "select messageContent, date, MessageType from message where (messageType = 0) and FavTenantID in " +
            "(select FavTenantID from FavoritedTenants where HostID = " + hostID + " AND TenantID = " + Session["AccountId"].ToString() + ")" +
            " order by date; ";
        imgSelect.CommandText = "SELECT AccountImage FROM Account WHERE AccountID = " + hostID;

        selectMessage.Connection = sc;
        imgSelect.Connection = sc;
        sc.Open();

        String accountImg = "";
        if (imgSelect.ExecuteScalar() is System.DBNull)
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
                .Append("<div class=\"outgoing-msg\">")
                .Append("   <div class=\"sent-msg\">")
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
                .Append("<div>")
                .Append("   <div class=\"incoming-msg-img\">")
                .Append("       <img src = \"https://duvjxbgjpi3nt.cloudfront.net/UserImages/" + accountImg + "\" class=\"rounded-circle img-fluid\">")
                .Append("   </div>")
                .Append("   <div class=\"recieved-msg\">")
                .Append("       <div class=\"recieved-withd-msg\">")
                .Append("           <p>" + message + "</p>")
                .Append("           <span class=\"time-date\">" + date + "</span>")
                .Append("       </div>")
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
        int hostID = Convert.ToInt32(Session["msgHostID"].ToString());
        int tenantID = Convert.ToInt32(Session["AccountId"].ToString());

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
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MessageContent", message));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MessageType", "1"));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Date", date));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FavTenantID", favTenantID));

        insert.ExecuteNonQuery();
        sc.Close();
        txtMessage.Text = String.Empty;

        loadMessages(hostID);
    }

    protected void viewLeaseBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewLease.aspx");
    }

    protected void videoChat_Click(object sender, EventArgs e)
    {
        Response.Redirect("TenantVideoChat.aspx");
    }
}