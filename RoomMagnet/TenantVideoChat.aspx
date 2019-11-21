<%@ Page Title="" Language="C#" MasterPageFile="~/TenantPage.master" AutoEventWireup="true" CodeFile="TenantVideoChat.aspx.cs" Inherits="TenantVideoChat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
       <div class="col-md-12">
            
        </div> 
    </div>


    <script src="https://static.opentok.com/v2/js/opentok.js" charset="utf-8"></script>
    <script charset="utf-8">
        function video() {
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
            })


            // create subscriber
            session.on('streamCreated', function (event) {
                session.subscribe(event.stream);
            });
        }

    </script>

</asp:Content>

