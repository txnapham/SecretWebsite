 using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewLease : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["roommagnetdbConnectionString"].ToString());
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
        sigErrorMessage.Visible = false;

        SqlCommand selectDate = new SqlCommand();
        SqlCommand selectHostName = new SqlCommand();
        SqlCommand selectTenantName = new SqlCommand();
        SqlCommand selectProp = new SqlCommand();
        SqlCommand selectSig = new SqlCommand();
        selectSig.Connection = sc;
        selectDate.Connection = sc;
        selectHostName.Connection = sc;
        selectTenantName.Connection = sc;
        selectProp.Connection = sc;

        sc.Open();
        selectDate.CommandText = "select ModifiedDate from lease where tenantID = " + Session["AccountID"];
        String date = selectDate.ExecuteScalar().ToString();
        dateTxt.Text = date;

        selectSig.CommandText = "select agreed from lease where tenantID=" + Session["AccountID"];
        

        selectHostName.CommandText = "select firstName, LastName from Account where AccountID in (select HostID from lease where tenantID = "+ Session["AccountID"] + ");";
        SqlDataReader reader = selectHostName.ExecuteReader();
        while (reader.Read())
        {
            String hostFirst = reader["FirstName"].ToString();
            String hostLast = reader["LastName"].ToString();
            hostNametxt.Text = hostFirst + " " + hostLast;
        }
        reader.Close();

        selectTenantName.CommandText = "select firstName, lastName from Account where AccountID in (select TenantId from lease where TenantID = " + Session["AccountID"] + ");";
        SqlDataReader rdr = selectTenantName.ExecuteReader();
        while (rdr.Read())
        {
            String tenantFirst = rdr["FirstName"].ToString();
            String tenantLast = rdr["LastName"].ToString();
            tenantNametxt.Text = tenantFirst + " " + tenantLast;
        }
        rdr.Close();

        selectProp.CommandText = "select HouseNumber, Street, City,HomeState from Property where PropertyID in (select PropertyID from Lease where TenantID = " + Session["AccountID"] + ")";
        SqlDataReader read = selectProp.ExecuteReader();
        while (read.Read())
        {
            String houseNum = read["HouseNumber"].ToString();
            String street = read["Street"].ToString();
            String city = read["City"].ToString();
            String state = read["HomeState"].ToString();
            adressTxt.Text = houseNum + " " + street;
            cityTxt.Text = city;
            stateTxt.Text = state;
        }
        rdr.Close();
        sc.Close();
    }
    protected void submitBtn_Click(object sender, EventArgs e)
    {
        if (tenantNametxt.Text.Equals(sigTxt.Text))
        {
            SqlCommand updateLease = new SqlCommand();
            updateLease.Connection = sc;
            updateLease.CommandText = "Update Lease Set Agreed = 1 where TenantID = @tenant;";
            updateLease.Parameters.Add(new SqlParameter("@tenant", Session["AccountID"]));
            sc.Open();
            updateLease.ExecuteNonQuery();
            sc.Close();

            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MyFunction()", true);
        }
        else
        { 
        }
    }
}