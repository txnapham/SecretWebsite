using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OpenTokSDK;

public partial class HostVideoChat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int ApiKey = 46470112; //API KEY
        string ApiSecret = "e93bf5dabccdc750e965266bd57fdede1e384157";
        var OpenTok = new OpenTok(ApiKey, ApiSecret);

        // Create a session that will attempt to transmit streams directly between clients
        var session = OpenTok.CreateSession();
        // Store this sessionId in the database for later use:
        string sessionId = session.Id;

        // Generate a token from a sessionId (fetched from database)
        string token = OpenTok.GenerateToken(sessionId);
    }
}