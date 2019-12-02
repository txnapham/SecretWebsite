<%@ Page Title="" Language="C#" MasterPageFile="~/HostPage.master" AutoEventWireup="true" CodeFile="HostVideoChat.aspx.cs" Inherits="HostVideoChat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- <!-- OpenTok.js library -->
            <script src="https://static.opentok.com/v2/js/opentok.js"></script>
            <script>

                // credentials

                var apiKey = '45828062';
                var sessionId = '2_MX40NTgyODA2Mn5-MTU3NDIyNTcyMDMxMn51WENZdlQ5Y0NRY0xJdk8rdS9ud0lGZkR-UH4';
                var token = 'T1==cGFydG5lcl9pZD00NTgyODA2MiZzaWc9ZThhNGUyODllZWQyZGUzYTUwMjEzODJjOTQzNDdjMmVjMjJhNTZlZjpzZXNzaW9uX2lkPTJfTVg0ME5UZ3lPREEyTW41LU1UVTNOREl5TlRjeU1ETXhNbjUxV0VOWmRsUTVZME5SWTB4SmRrOHJkUzl1ZDBsR1prUi1VSDQmY3JlYXRlX3RpbWU9MTU3NDIyNTc5MiZub25jZT0wLjY2MDkzOTkxNTkwOTI3OTMmcm9sZT1wdWJsaXNoZXImZXhwaXJlX3RpbWU9MTU3NDMxMjE5Mg==';

                // connect to session
                var session = OT.initSession(apiKey, sessionId);

                // create publisher
                var publisher = OT.initPublisher();
                session.connect(token, function (err) {
                    // publish publisher
                    session.publish(publisher);

                });

                // create subscriber
                session.on('streamCreated', function (event) {
                    session.subscribe(event.stream);
                });


            </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="css/app.css" rel="stylesheet" type="text/css">
    <script src="https://static.opentok.com/v2/js/opentok.min.js"></script>

    <div id="videos">
        <div id="subscriber"></div>
        <div id="publisher"></div>
    </div>

    <script type="text/javascript" src="js/apps.js"></script>
    
</asp:Content>

