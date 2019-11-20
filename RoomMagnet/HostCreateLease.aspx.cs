using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HostCreateLease : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AccountId"] != null && Convert.ToInt16(Session["type"]) == 2)
        {

        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }
}