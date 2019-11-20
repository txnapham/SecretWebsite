using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HostMessageCenter : System.Web.UI.Page
{
    System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ToString());

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
        Message.Text = String.Empty;
        Card.Text = String.Empty;

        if (Session["AccountId"] != null && Convert.ToInt16(Session["type"]) == 2)
        { 
            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
            select.CommandText = "select accountID, firstName, LastName from account where AccountID in (select tenantID from tenant where TenantID in " +
                "(select tenantID from FavoritedTenants where HostID = "+Session["AccountId"]+"));";
            select.Connection = sc;
            sc.Open();
            //Get Month and Day
            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
            String dy = datevalue.Day.ToString();
            String mn = datevalue.Month.ToString();
            String yy = datevalue.Year.ToString();
        //Reader to populate card 
            int count = 0;
            System.Data.SqlClient.SqlDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                String firstName = reader["FirstName"].ToString();
                String lastName = reader["LastName"].ToString();
                String tenantID = reader["AccountID"].ToString();

                StringBuilder myCard = new StringBuilder();
                myCard
                    .Append("<div class=\"chat-list\">")
                .Append("               <div class=\"chat-people\">")
                .Append("                   <div class=\"chat-img\">")
                //.Append("                        <asp:ImageButton id=\"btnSubmit" + count + "\" runat=\"server\" this.src=\"images/rebeccajames.png\" class=\"rounded-circle img-fluid\" CustomParameter=\"" + tenantID + "\" onClick= \"btnSubmit_Click\"/>")
                .Append("<input type=\"image\" name=\"ctl00$ContentPlaceHolder1$btnSubmit"+count+"\" id=\"ContentPlaceHolder1_btnSubmit"+count+"\" class=\"rounded-circle img-fluid\" customparameter=\""+tenantID+"\" src=\"images/rebeccajames.png\">")
                .Append("                       </div>")
                .Append("                   <div class=\"chat-ib\">")
                .Append("                       <h5>" + firstName + " " + lastName + "<span class=\"chat-date\">" + mn + "/" + dy + "/" + yy + "</span></h5>")
                .Append("                        <p>text</p>")
                .Append("                    </div>")
                .Append("                </div>")
                .Append("            </div>");

                Card.Text += myCard.ToString();
                count++;
            }
            reader.Close();
            sc.Close();
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
        
    }
    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton lnk = sender as ImageButton;
        String tenantID = lnk.Attributes["CustomParameter"].ToString();

        System.Data.SqlClient.SqlCommand selectMessage = new System.Data.SqlClient.SqlCommand();
        //Message
        selectMessage.CommandText = "select messageContent, date,MessageType from message where (messageType = 1) and FavPropID in (select FavPropID " +
            "from FavoritedProperties where PropertyID in (select PropertyID from Property where HostID =" + Session["AccountId"] + ")) and FavTenantID in (select FavTenantID from " +
            "FavoritedTenants where TenantID = " + tenantID + ")" +
            "Union " +
            "select messageContent, date,MessageType from message where(messageType = 0) and FavPropID in (select FavPropID from FavoritedProperties where " +
            "PropertyID in (select PropertyID from Property where HostID="+ Session["AccountId"]+")) and FavTenantID in (select FavTenantID from FavoritedTenants where TenantID=" +tenantID+")" +
            " order by date; ";
        selectMessage.Connection = sc;
        sc.Open();
        System.Data.SqlClient.SqlDataReader reader = selectMessage.ExecuteReader();
        Message.Text = String.Empty;
        while (reader.Read())
        {
            String message = reader["MessageContent"].ToString();
            String date = reader["Date"].ToString();
            int messageType = Convert.ToInt16(reader["MessageType"].ToString());

            if (messageType == 1)
            {
                StringBuilder myCard = new StringBuilder();
                myCard
                .Append("    <div class=\"incoming-msg-img\">")
                .Append("                    <img src = \"images/rebeccajames.png\" class=\"rounded-circle img-fluid\">")
                .Append("                </div>")
                .Append("                <div class=\"recieved-msg\">")
                .Append("                    <div class=\"recieved-withd-msg\">")
                .Append("                        <p>" + message + "</p>")
                .Append("                        <span class=\"time-date\">" + date + "</span>")
                .Append("                    </div>")
                .Append("                </div>");

                Message.Text += myCard.ToString();
            }
            else if(messageType == 0)
            {
                StringBuilder myCard = new StringBuilder();
                myCard
                .Append("<div class=\"outgoing-msg\">")
                .Append("                <div class=\"sent-msg\">")
                .Append("                   <p>" + message + "</p>")
                .Append("                   <span class=\"time-date\">" + date + "</span>")
                .Append("                </div>")
                .Append("            </div>");

                Message.Text += myCard.ToString();
            }
        }
        reader.Close();
        sc.Close();
    }

    protected void messagebtn_Click(object sender, EventArgs e)
    {
        //Selecting FavProp and FavTenant
        System.Data.SqlClient.SqlCommand favTenant = new System.Data.SqlClient.SqlCommand();
        System.Data.SqlClient.SqlCommand favProp = new System.Data.SqlClient.SqlCommand();
        favProp.Connection = sc;
        favTenant.Connection = sc;
        sc.Open();
        favProp.CommandText = "SELECT FavoritedProperties.FavPropID FROM FavoritedProperties INNER JOIN Message ON FavoritedProperties.FavPropID = " +
            "Message.FavPropID INNER JOIN Property ON FavoritedProperties.PropertyID = Property.PropertyID AND Property.HostID =" + Session["AccountId"] + ";";
        int favPropID = Convert.ToInt16(favProp.ExecuteScalar());
        sc.Close();
        favTenant.CommandText = "SELECT FavTenantID FROM Message where FavPropID = " + favPropID + ";";
        sc.Open();
        int favTenantID = Convert.ToInt16(favTenant.ExecuteScalar());
        sc.Close();

        //Insert Message Statement 
        String message = txtMessage.Text;
        String date = DateTime.Now.ToString();

        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
        insert.Connection = sc;
        sc.Open();
        insert.CommandText = "INSERT INTO MESSAGE VALUES(@MessageContent,@MessageType,@Date,@FavPropID,@FavTenantID);";
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MessageContent", message));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MessageType", "0"));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Date", date));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FavPropID", favPropID));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FavTenantID",favTenantID ));

        insert.ExecuteNonQuery();
        sc.Close();
        txtMessage.Text = String.Empty;
        //e as ImageClickEventArgs;
        //btnSubmit_Click(sender,e);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static void CreateLease()
    {

    }
}