using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegisteredHosts : System.Web.UI.Page
{
    System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ToString());
    List<BackgroundStatus> backStatusL = new List<BackgroundStatus>();
    int searchCheck = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Admin access 
        if (Session["AccountId"] != null && Convert.ToInt16(Session["type"]) == 1)
        {
            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
            select.Connection = sc;
            sc.Open();

            //Search the background check status of individuals
            if (searchCheck == 0)
            {
                select.CommandText = "SELECT AccountID, CONCAT(FirstName, ' ', LastName) AS Name, BackgroundCheckStatus " +
                "FROM Account INNER JOIN Host ON AccountID = HostID " +
                "ORDER BY Name";
            }
            if (searchCheck == 1)
            {
                select.CommandText += "SELECT AccountID, CONCAT(FirstName, ' ', LastName) AS Name, BackgroundCheckStatus " +
                "FROM Account INNER JOIN Host ON AccountID = HostID " +
                "WHERE CONCAT(FirstName, ' ', LastName) = @Name";

                select.Parameters.AddWithValue("@Name", txtSearch.Text);
            }

            string backCheckS = "";

            backStatusL.Clear();

            System.Data.SqlClient.SqlDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                //Change background check status from incomplete to complete 
                String hostName = reader["Name"].ToString();
                int hostID = Convert.ToInt16(reader["AccountID"].ToString());
                int backCheckStatus = Convert.ToInt16(reader["BackgroundCheckStatus"].ToString());
                if (backCheckStatus == 1) backCheckS = "Complete";
                if (backCheckStatus == 0) backCheckS = "Incomplete";

                backStatusL.Add(new BackgroundStatus() { accountName = hostName, accountID = hostID, backStatus = backCheckS });
            }
            sc.Close();

            regHostRepeater.DataSource = backStatusL;
            regHostRepeater.DataBind();

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
        int hostID = Convert.ToInt16(updateB.Attributes["CustomParameter"].ToString());

        //Update Background Status Query
        System.Data.SqlClient.SqlCommand backCheck = new System.Data.SqlClient.SqlCommand();
        System.Data.SqlClient.SqlCommand update = new System.Data.SqlClient.SqlCommand();
        backCheck.CommandText = "SELECT BackgroundCheckStatus FROM Host WHERE HostID = @HostID";
        update.CommandText = "UPDATE HOST SET BackgroundCheckStatus = @BackStatus WHERE HostID = @HostID;";

        //Connection
        backCheck.Connection = sc;
        update.Connection = sc;
        sc.Open();

        backCheck.Parameters.AddWithValue("@HostID", hostID);
        update.Parameters.AddWithValue("@HostID", hostID);

        int currentBC = (int)backCheck.ExecuteScalar();

        if (currentBC == 1)
        {
            update.Parameters.AddWithValue("@BackStatus", 0);
        }
        else if (currentBC == 0)
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
        int hostID = Convert.ToInt16(deleteB.Attributes["CustomParameter"].ToString());

        //Update Background Status Query
        System.Data.SqlClient.SqlCommand delete = new System.Data.SqlClient.SqlCommand();
        delete.CommandText = ""; //delete statement

        //Connection
        delete.Connection = sc;
        sc.Open();

        delete.Parameters.AddWithValue("@HostID", hostID);

        delete.ExecuteNonQuery();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        searchCheck++;
        Page_Load(sender, e);
    }
}