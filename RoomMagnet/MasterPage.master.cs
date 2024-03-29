﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = "server=aawnyfad9tm1sf.cqpnea2xsqc1.us-east-1.rds.amazonaws.com;database=roommagnetdb;uid=admin;password=Skylinejmu2019;"
        + "MultipleActiveResultSets=True";
        sc.Open();

        System.Data.SqlClient.SqlCommand findPass = new System.Data.SqlClient.SqlCommand();
        findPass.Connection = sc;
        // SELECT PASSWORD STRING WHERE THE ENTERED USERNAME MATCHES
        findPass.CommandText = "SELECT PasswordHash from Password where Email = @email";
        findPass.Parameters.Add(new SqlParameter("@email", txtEmail.Text));

        SqlDataReader reader = findPass.ExecuteReader(); // create a reader

        if (reader.HasRows) // if the email exists, it will continue
        {
            while (reader.Read()) // this will read the single record that matches the entered email
            {
                string storedHash = reader["PasswordHash"].ToString(); // store the database password into this variable

                if (PasswordHash.ValidatePassword(txtPassword.Text, storedHash)) // if the entered password matches what is stored, it will show success
                {
                    System.Data.SqlClient.SqlCommand search = new System.Data.SqlClient.SqlCommand();
                    search.Connection = sc;
                    //select variables for current user
                    search.CommandText = "SELECT AccountType from Account where Email = @email";
                    search.Parameters.Add(new SqlParameter("@email", txtEmail.Text));
                    int type = (int)search.ExecuteScalar();

                    Session["type"] = type;

                    //Current User id
                    System.Data.SqlClient.SqlCommand getAcctID = new System.Data.SqlClient.SqlCommand();
                    getAcctID.Connection = sc;
                    getAcctID.CommandText = "SELECT AccountID from Account where Email = @email";
                    getAcctID.Parameters.Add(new SqlParameter("@email", txtEmail.Text));
                    HttpContext.Current.Session["AccountId"] = getAcctID.ExecuteScalar();


                    if (type == 1)
                    {
                        Response.Redirect("AdminDashboard.aspx");
                    }
                    if (type == 2)
                    {
                        Response.Redirect("HostDashboard.aspx");
                    }
                    if (type == 3)
                    {
                        Response.Redirect("TenantDashboard.aspx");
                    }
                }
                else
                {
                    lblPass.Text = "Invalid Password";
                    lblEmail.Text = "";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                }
            }
        }
        else // if the email doesn't exist, it will show failure
        {
            lblEmail.Text = "Invalid Email";
            lblPass.Text = "";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
        sc.Close();
    }
}