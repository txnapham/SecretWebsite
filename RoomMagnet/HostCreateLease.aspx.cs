using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HostCreateLease : System.Web.UI.Page
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
    }

    protected void btnCreateLease_Click(object sender, EventArgs e)
    {
        try
        {
            //Setting textboxes to variables for queries later
            String hostFirst = txtHFN.Text;
            String hostLast = txtHLN.Text;
            String tenantFirst = txtTFN.Text;
            String tenantLast = txtTLN.Text;
            String houseNum = txtHouseNum.Text;
            String street = txtStreet.Text;
            String rent = txtMoney.Text;
            String startDate = txtStartDate.Text;
            String endDate = txtEndDate.Text;
            String modifiedDate = DateTime.Now.ToString();

            //Select Statements and Connections 
            System.Data.SqlClient.SqlCommand selectHost = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand selectTenant = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand selectProperty = new System.Data.SqlClient.SqlCommand();
            selectHost.Connection = sc;
            selectTenant.Connection = sc;
            selectProperty.Connection = sc;
            //Selecting Host based off of entered in data
            selectTenant.CommandText = "select AccountID from Account where firstName = '" + tenantFirst + "' and LastName = '" + tenantLast + "' and AccountID in (select tenantID from FavoritedTenants)";
            //Selecting tenant based off of entered in data 
            selectHost.CommandText = "select AccountID from Account where firstName = '" + hostFirst + "' and LastName = '" + hostLast + "' and AccountID in (select hostID from FavoritedTenants)";
            //selecting property based off entered in data
            selectProperty.CommandText = "select RoomID from PropertyRoom where MonthlyPrice ='200.00' and PropertyID in(select PropertyId from Property where HouseNumber = '2314' and Street = 'Test Rd')";
            sc.Open();
            int tenantID = Convert.ToInt16(selectTenant.ExecuteScalar());
            int hostID = Convert.ToInt16(selectHost.ExecuteScalar());
            int roomID = Convert.ToInt16(selectProperty.ExecuteScalar());
            //Insert Statements
            System.Data.SqlClient.SqlCommand insertLease = new System.Data.SqlClient.SqlCommand();
            insertLease.Connection = sc;
            //Insert into SQL Lease Table
            insertLease.CommandText = "INSERT INTO Lease Values(@MonthlyPrice, @EffectiveDate,@TerminationDate, @ModifiedDate, @TenantID, @HostID, @RoomID);";
            insertLease.Parameters.Add(new SqlParameter("@MonthlyPrice", rent));
            insertLease.Parameters.Add(new SqlParameter("@EffectiveDate", startDate));
            insertLease.Parameters.Add(new SqlParameter("@TerminationDate", endDate));
            insertLease.Parameters.Add(new SqlParameter("@ModifiedDate", modifiedDate));
            insertLease.Parameters.Add(new SqlParameter("@TenantID", tenantID));
            insertLease.Parameters.Add(new SqlParameter("@HostID", hostID));
            insertLease.Parameters.Add(new SqlParameter("@RoomID", roomID));
            insertLease.ExecuteNonQuery();
            sc.Close();
            Response.Redirect("HostDashboard.aspx");
        }
        catch
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MyFunction()", true);
        }
    }
}