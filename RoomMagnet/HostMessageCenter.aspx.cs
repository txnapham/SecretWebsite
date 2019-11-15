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
        select.CommandText = "select firstName, LastName from account where AccountID in (select tenantID from tenant where TenantID in " +
            "(select tenantID from FavoritedTenants where HostID=3));";
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

            StringBuilder myCard = new StringBuilder();
            myCard
                .Append("<div class=\"chat-list\">")
                .Append("               <div class=\"chat-people\">")
                .Append("                   <div class=\"chat-img\">")
                .Append("                        <img src = \"images/rebeccajames.png\" class=\"rounded-circle img-fluid\"></div>")
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
}