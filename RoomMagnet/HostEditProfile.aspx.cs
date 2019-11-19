using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class HostEditProfile : System.Web.UI.Page
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
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = "server=aa1evano00xv2xb.cqpnea2xsqc1.us-east-1.rds.amazonaws.com;database=roommagnetdb;uid=admin;password=Skylinejmu2019;";
        sc.Open();
        int accountID = Convert.ToInt16(HttpContext.Current.Session["AccountId"].ToString());
        System.Data.SqlClient.SqlCommand search = new System.Data.SqlClient.SqlCommand();
        search.Connection = sc;
        search.CommandText = "SELECT HomeNumber, Street, City, HomeState, Country, Zip, PhoneNumber, Email FROM Account WHERE AccountID = " + accountID + ";";
        SqlDataReader searching = search.ExecuteReader();

        //checks the database for matches
        if (searching.Read())
        {
            txtHouseNum.Text = searching.GetString(0);
            txtStreet.Text = searching.GetString(1);
            txtCity.Text = searching.GetString(2);
            ddState.SelectedValue = searching.GetString(3);
            ddCountry.SelectedValue = searching.GetString(4);
            txtZip.Text = searching.GetString(5);
            txtPhone.Text = searching.GetString(6);
            txtEmail.Text = searching.GetString(7);
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int accountID = Convert.ToInt16(HttpContext.Current.Session["AccountId"].ToString());
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = "server=aa1evano00xv2xb.cqpnea2xsqc1.us-east-1.rds.amazonaws.com;database=roommagnetdb;uid=admin;password=Skylinejmu2019;";
        sc.Open();

        System.Data.SqlClient.SqlCommand update = new System.Data.SqlClient.SqlCommand();
        update.Connection = sc;
        update.CommandText = "UPDATE Account SET PhoneNumber = @number WHERE AccountID = @accountID;";
        update.Parameters.Add(new SqlParameter("@number", txtPhone.Text));
        update.Parameters.Add(new SqlParameter("@email", txtEmail.Text));
        update.Parameters.Add(new SqlParameter("@HouseNbr", this.txtHouseNum.Text));
        update.Parameters.Add(new SqlParameter("@street", this.txtStreet.Text));
        update.Parameters.Add(new SqlParameter("@city", this.txtCity.Text));
        update.Parameters.Add(new SqlParameter("@state", this.ddState.SelectedValue));
        update.Parameters.Add(new SqlParameter("@country", this.ddCountry.SelectedValue));
        update.Parameters.Add(new SqlParameter("@zip", this.txtZip.Text));
        update.Parameters.Add(new SqlParameter("@accountID", accountID));


    }
}