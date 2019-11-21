using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class TenantEditProfile : System.Web.UI.Page
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
        if (Session["AccountId"] != null && Convert.ToInt16(Session["type"]) == 3)
        {
            if (IsPostBack != true)
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
        }
        else
        {
            Response.Redirect("Home.aspx");
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
        update.CommandText = "UPDATE Account SET PhoneNumber = @number, Email = @email, HomeNumber = @HouseNbr, Street = @street, City = @city, HomeState = @state, Country = @country, Zip = @zip WHERE AccountID = @accountID;";
        update.Parameters.Add(new SqlParameter("@number", txtPhone.Text));
        update.Parameters.Add(new SqlParameter("@email", txtEmail.Text));
        update.Parameters.Add(new SqlParameter("@HouseNbr", this.txtHouseNum.Text));
        update.Parameters.Add(new SqlParameter("@street", this.txtStreet.Text));
        update.Parameters.Add(new SqlParameter("@city", this.txtCity.Text));
        update.Parameters.Add(new SqlParameter("@state", this.ddState.SelectedValue));
        update.Parameters.Add(new SqlParameter("@country", this.ddCountry.SelectedValue));
        update.Parameters.Add(new SqlParameter("@zip", this.txtZip.Text));
        update.Parameters.Add(new SqlParameter("@accountID", accountID));

        update.ExecuteNonQuery();
        sc.Close();



    }

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        int accountID = Convert.ToInt16(HttpContext.Current.Session["AccountId"].ToString());
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection();
        sqlConn.ConnectionString = "server=aa1evano00xv2xb.cqpnea2xsqc1.us-east-1.rds.amazonaws.com;database=roommagnetdb;uid=admin;password=Skylinejmu2019;";
        sc.ConnectionString = "server=aa1evano00xv2xb.cqpnea2xsqc1.us-east-1.rds.amazonaws.com;database=roommagnetdb;uid=admin;password=Skylinejmu2019;";
        sc.Open();
        sqlConn.Open();

        System.Data.SqlClient.SqlCommand findPass = new System.Data.SqlClient.SqlCommand();
        findPass.Connection = sc;
        // SELECT PASSWORD STRING WHERE THE ENTERED USERNAME MATCHES
        findPass.CommandText = "SELECT PasswordHash from Password where AccountID = @AccountID";
        findPass.Parameters.Add(new SqlParameter("@AccountID", accountID));

        SqlDataReader reader = findPass.ExecuteReader(); // create a reader

        if (reader.HasRows) // if the email exists, it will continue
        {
            while (reader.Read()) // this will read the single record that matches the entered email
            {
                string storedHash = reader["PasswordHash"].ToString(); // store the database password into this variable

                if (PasswordHash.ValidatePassword(txtPrevPassword.Text, storedHash)) // if the entered password matches what is stored, it will allow for password change
                {
                    System.Data.SqlClient.SqlCommand newPass = new System.Data.SqlClient.SqlCommand();
                    newPass.Connection = sqlConn;
                    newPass.CommandText = "UPDATE Password SET PasswordHash = @password WHERE AccountID = @accountID;";
                    //Insert into PASSWORD
                    newPass.Parameters.Add(new SqlParameter("@AccountID", accountID));
                    newPass.Parameters.Add(new SqlParameter("@password", PasswordHash.HashPassword(txtReenterPassword.Text))); // hash entered password
                    lblPrev.Text = "Success";
                    newPass.ExecuteNonQuery();
                    sqlConn.Close();
                }
                else
                {
                    lblPrev.Text = "Incorrect Password";
                }
            }
        }
        else // if the account doesn't exist, it will show failure

            sc.Close();
    }

}