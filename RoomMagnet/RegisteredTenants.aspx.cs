﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class RegisteredTenants : System.Web.UI.Page
{
    System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ToString());
    List<BackgroundStatus> backStatusL = new List<BackgroundStatus>();
    int searchCheck = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AccountId"] != null && Convert.ToInt16(Session["type"]) == 1)
        {
            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
            select.Connection = sc;
            sc.Open();
            select.CommandText = "";


            if (searchCheck == 0)
            {
                select.CommandText += "SELECT AccountID, CONCAT(FirstName, ' ', LastName) AS Name, BackgroundCheckStatus " +
                "FROM Account INNER JOIN Tenant ON AccountID = TenantID " +
                "ORDER BY Name";
            }
            if (searchCheck == 1)
            {
                select.CommandText += "SELECT AccountID, CONCAT(FirstName, ' ', LastName) AS Name, BackgroundCheckStatus " +
                "FROM Account INNER JOIN Tenant ON AccountID = TenantID " +
                "WHERE CONCAT(FirstName, ' ', LastName) = @Name";

                select.Parameters.AddWithValue("@Name", txtSearch.Text);
            }

            string backCheckS = "";

            backStatusL.Clear();

            System.Data.SqlClient.SqlDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                String tenantName = reader["Name"].ToString();
                int tenantID = Convert.ToInt16(reader["AccountID"].ToString());
                int backCheckStatus = Convert.ToInt16(reader["BackgroundCheckStatus"].ToString());
                if (backCheckStatus == 1) backCheckS = "Complete";
                if (backCheckStatus == 0) backCheckS = "Incomplete";

                backStatusL.Add(new BackgroundStatus() { accountName = tenantName, accountID = tenantID, backStatus = backCheckS });
            }
            sc.Close();

            regTenantRepeater.DataSource = backStatusL;
            regTenantRepeater.DataBind();

            searchCheck = 0;
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button updateB = sender as Button;
        int tenantID = Convert.ToInt16(updateB.Attributes["CustomParameter"].ToString());

        //Update Background Status Query
        System.Data.SqlClient.SqlCommand backCheck = new System.Data.SqlClient.SqlCommand();
        System.Data.SqlClient.SqlCommand update = new System.Data.SqlClient.SqlCommand();
        backCheck.CommandText = "SELECT BackgroundCheckStatus FROM Tenant WHERE TenantID = @TenantID";
        update.CommandText = "UPDATE Tenant SET BackgroundCheckStatus = @BackStatus WHERE TenantID = @TenantID;";

        //Connection
        backCheck.Connection = sc;
        update.Connection = sc;
        sc.Open();

        backCheck.Parameters.AddWithValue("@TenantID", tenantID);
        update.Parameters.AddWithValue("@TenantID", tenantID);

        int currentBC = (int)backCheck.ExecuteScalar();


        if (currentBC == 1)
        {
            update.Parameters.AddWithValue("@BackStatus", 0);
        }
        else if(currentBC == 0)
        {
            update.Parameters.AddWithValue("@BackStatus", 1);
        }

        //Execute Query 
        update.ExecuteNonQuery();
        sc.Close();

        Page_Load(sender, e);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Button deleteB = sender as Button;
        int tenantID = Convert.ToInt16(deleteB.Attributes["CustomParameter"].ToString());

        //Update Background Status Query
        System.Data.SqlClient.SqlCommand delete = new System.Data.SqlClient.SqlCommand();
        delete.CommandText = "DELETE FROM Appointment WHERE FavTenantID IN (SELECT FavTenantID FROM FavoritedTenants WHERE TenantID = @TenantID);" +
            "DELETE FROM Message WHERE FavTenantID IN (SELECT FavTenantID FROM FavoritedTenants WHERE TenantID = @TenantID);" +
            "DELETE FROM FavoritedTenants WHERE TenantID = @TenantID;" +
            "DELETE FROM Payment WHERE TenantID = @TenantID;" +
            "DELETE FROM Review WHERE LeaseID IN (SELECT LeaseID FROM Lease WHERE TenantID = @TenantID;" +
            "DELETE FROM Lease WHERE TenantID = @TenantID;" +
            "DELETE FROM FavoritedProperties WHERE TenantID = @TenantID;" +
            "DELETE FROM ViewedProperties WHERE TenantID = @TenantID;" +
            "DELETE FROM Recommendation WHERE TenantID = @TenantID;" +
            "DELETE FROM Characteristics WHERE AccountID = @TenantID;" +
            "DELETE FROM Password WHERE Email = (SELECT Email FROM Account WHERE AccountID = @TenantID);" +
            "DELETE FROM Tenant WHERE TenantID = @TenantID; " +
            "DELETE FROM Account WHERE AccountID = @TenantID;";
        
        //Connection
        delete.Connection = sc;
        sc.Open();

        delete.Parameters.AddWithValue("@TenantID", tenantID);

        delete.ExecuteNonQuery();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        searchCheck++;
        Page_Load(sender, e);
    }
}