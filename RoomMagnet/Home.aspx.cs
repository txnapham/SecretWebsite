﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    private static string connection = ConfigurationManager.ConnectionStrings["roommagnetdbConnectionString"].ConnectionString;
    SqlConnection sc = new SqlConnection(connection);
    protected void Page_PreInit(object sender, EventArgs e)
    {
        //Allows which type of user to have access
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Search button for registered tenants
        Session["Search"] = txtSearch.Text;
        if (Session["type"] != null)
        {
            if ((int)Session["type"] == 3)
            {
                Response.Redirect("Search-Tenant.aspx");
            }
        }
        else
        {
            //Search for browsing 
            Response.Redirect("Search.aspx");
        }
    }
}