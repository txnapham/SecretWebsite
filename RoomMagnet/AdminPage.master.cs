using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class AdminPage : System.Web.UI.MasterPage
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
        if (Session["AccountId"] != null && Convert.ToInt16(Session["type"]) == 1)
        {

        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        //SQL Statement
        int accountID = Convert.ToInt16(HttpContext.Current.Session["AccountId"].ToString());
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        //Connection
        System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection();
        sqlConn.ConnectionString = "server=aawnyfad9tm1sf.cqpnea2xsqc1.us-east-1.rds.amazonaws.com; database =roommagnetdb;uid=admin;password=Skylinejmu2019;";
        sc.ConnectionString = "server=aawnyfad9tm1sf.cqpnea2xsqc1.us-east-1.rds.amazonaws.com; database =roommagnetdb;uid=admin;password=Skylinejmu2019;";
        sc.Open();
        sqlConn.Open();

        System.Data.SqlClient.SqlCommand findPass = new System.Data.SqlClient.SqlCommand();
        findPass.Connection = sc;
        // SELECT PASSWORD STRING WHERE THE ENTERED USERNAME MATCHES
        findPass.CommandText = "SELECT PasswordHash from Password where AccountID = @AccountID";
        findPass.Parameters.Add(new SqlParameter("@AccountID", accountID));

        SqlDataReader reader = findPass.ExecuteReader(); // create a reader
        // If the email exists, it will continue
        if (reader.HasRows)
        {
            // this will read the single record that matches the entered email
            while (reader.Read())
            {
                // store the database password into this variable
                string storedHash = reader["PasswordHash"].ToString();
                // If the entered password matches what is stored, it will allow for password change
                if (PasswordHash.ValidatePassword(txtPrevPassword.Text, storedHash))
                {
                    System.Data.SqlClient.SqlCommand newPass = new System.Data.SqlClient.SqlCommand();
                    newPass.Connection = sqlConn;
                    newPass.CommandText = "UPDATE Password SET PasswordHash = @password WHERE AccountID = @accountID;";
                    //Insert into PASSWORD
                    newPass.Parameters.Add(new SqlParameter("@AccountID", accountID));
                    newPass.Parameters.Add(new SqlParameter("@password", PasswordHash.HashPassword(txtReenterPassword.Text))); // hash entered password
                    newPass.ExecuteNonQuery();
                    sqlConn.Close();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MyFunction()", true);
                }
                else
                {
                    lblPrev.Text = "Incorrect Password";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                }
            }
        }
        else // if the account doesn't exist, it will show failure

            //LABEL FOR FAILURE
            sc.Close();
    }
}
