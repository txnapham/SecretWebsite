using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MessageInbox
/// </summary>
public class MessageInbox
{
    public string imageURL { get; set; }
    public int messagerID { get; set; }
    public string messagerName { get; set; }
    public string latestMessage { get; set; }

    public MessageInbox()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}