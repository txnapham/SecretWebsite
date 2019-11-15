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
        //if (string.IsNullOrEmpty(HttpContext.Current.Session["AccountId"].ToString()))
        //{
        //}
        //else
        //{
        //}
        System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
        select.CommandText = "select accountID, firstName, LastName from account where AccountID in (select tenantID from tenant where TenantID in " +
            "(select tenantID from FavoritedTenants where HostID=3));";//change to session
        select.Connection = sc;
        sc.Open();
        //Get Month and Day
        String sDate = DateTime.Now.ToString();
        DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
        String dy = datevalue.Day.ToString();
        String mn = datevalue.Month.ToString();
        String yy = datevalue.Year.ToString();
        //Reader to populate card 
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
                .Append("                        <img src = \"images/rebeccajames.png\" class=\"rounded-circle img-fluid\" onClick=\"showMessage("+tenantID+")\"></div>")
                .Append("                   <div class=\"chat-ib\">")
                .Append("                       <h5>" + firstName + " " + lastName + "<span class=\"chat-date\">" + mn+"/"+dy+"/"+yy + "</span></h5>")
                .Append("                        <p>text</p>")
                .Append("                    </div>")
                .Append("                </div>")
                .Append("            </div>");
            Card.Text += myCard.ToString();
        }
        reader.Close();
        sc.Close();
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static void MessageShower(int tenantID)
    {
        System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ToString());

        System.Data.SqlClient.SqlCommand tenantMessage = new System.Data.SqlClient.SqlCommand();
        System.Data.SqlClient.SqlCommand hostMessage = new System.Data.SqlClient.SqlCommand();
        //Tenant Message
        tenantMessage.CommandText = "select messageContent, date from message where (messageType = 1) and FavPropID in (select FavPropID from FavoritedProperties where PropertyID in " +
            " (select PropertyID from Property where HostID = 3)) and " +//change to session
            "FavTenantID in (select FavTenantID from FavoritedTenants where TenantID = "+tenantID+"); ";
        //Host Message
        hostMessage.CommandText = "select messageContent, date from message where (messageType = 0) and FavPropID in (select FavPropID from FavoritedProperties where PropertyID in " +
            " (select PropertyID from Property where HostID = 3)) and " +//change to session
            "FavTenantID in (select FavTenantID from FavoritedTenants where TenantID = " + tenantID + ");"; 
        tenantMessage.Connection = sqlConn;
        hostMessage.Connection = sqlConn;
        sqlConn.Open();
        System.Data.SqlClient.SqlDataReader reader = tenantMessage.ExecuteReader();
        while (reader.Read())
        {
            String message = reader["MessageContent"].ToString();
            String date = reader["Date"].ToString();

            StringBuilder myCard = new StringBuilder();
            myCard
            .Append("    <div class=\"incoming-msg-img\">")
            .Append("                    <img src = \"images/rebeccajames.png\" class=\"rounded-circle img-fluid\">")
            .Append("                </div>")
            .Append("                <div class=\"recieved-msg\">")
            .Append("                    <div class=\"recieved-withd-msg\">")
            .Append("                        <p>"+message+"</p>")
            .Append("                        <span class=\"time-date\">"+date+"</span>")
            .Append("                    </div>")
            .Append("                </div>");

            HostMessageCenter x = new HostMessageCenter();
            x.TenantCardBuilder(myCard);
        }
        reader.Close();
        System.Data.SqlClient.SqlDataReader rdr = hostMessage.ExecuteReader();
        while (rdr.Read())
        {
            String message = rdr["MessageContent"].ToString();
            String date = rdr["Date"].ToString();

            StringBuilder myCard = new StringBuilder();
            myCard
            .Append("<div class=\"outgoing - msg\">")
            .Append("                <div class=\"sent - msg\">")
            .Append("                   <p>"+message+"</p>")
            .Append("                   <span class=\"time - date\">"+date+"</span>")
            .Append("                </div>")
            .Append("            </div>");

            HostMessageCenter x = new HostMessageCenter();
            x.HostCardBuilder(myCard);
        }
        rdr.Close();
        sqlConn.Close();
    }
    public void TenantCardBuilder(StringBuilder myCard)
    {
        StringBuilder card = myCard;
        TMessage.Text += card.ToString();
    }
    public void HostCardBuilder(StringBuilder myCard)
    {
        StringBuilder card = myCard;
        message2.Text += card.ToString();
    }
}