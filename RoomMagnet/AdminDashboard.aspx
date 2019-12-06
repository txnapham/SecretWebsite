<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.master" AutoEventWireup="true" CodeFile="AdminDashboard.aspx.cs" Inherits="AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>RoomMagnet | Dashboard</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid mt-5 pt-5">
        <!--Cards start here-->
        <section>
            <div class="card-deck row">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <div class="card shadow-sm  mb-4">
                        <div class="card-body">
                            <div class='tableauPlaceholder' id='viz1574151971348' style='position: relative'>
                                <noscript>
                                    <a href='#'><img alt=' ' src='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;Ro&#47;RoommagnetUsers&#47;Dashboard2&#47;1_rss.png' style='border: none' /></a>
                                </noscript>
                                <object class='tableauViz'  style='display:none;'>
                                    <param name='host_url' value='https%3A%2F%2Fpublic.tableau.com%2F' /> 
                                    <param name='embed_code_version' value='3' /> <param name='site_root' value='' />
                                    <param name='name' value='RoommagnetUsers&#47;Dashboard2' />
                                    <param name='tabs' value='no' /><param name='toolbar' value='yes' />
                                    <param name='static_image' value='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;Ro&#47;RoommagnetUsers&#47;Dashboard2&#47;1.png' /> 
                                    <param name='animate_transition' value='yes' /><param name='display_static_image' value='yes' />
                                    <param name='display_spinner' value='yes' /><param name='display_overlay' value='yes' />
                                    <param name='display_count' value='yes' /><param name='filter' value='publish=yes' />
                                </object>
                            </div>
                            
                            <script type='text/javascript'>                    
                                var divElement = document.getElementById('viz1574151971348');
                                var vizElement = divElement.getElementsByTagName('object')[0];
                                if (divElement.offsetWidth > 800) { vizElement.style.width = '100%'; vizElement.style.height = '700px'; }
                                else if (divElement.offsetWidth > 500) { vizElement.style.width = '100%'; vizElement.style.height = '700px'; }
                                else { vizElement.style.width = '100%'; vizElement.style.height = '927px'; }
                                var scriptElement = document.createElement('script');
                                scriptElement.src = 'https://public.tableau.com/javascripts/api/viz_v1.js';
                                vizElement.parentNode.insertBefore(scriptElement, vizElement);                
                            </script>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        
        <section>
            <div class="card-deck row">
                <div class="col-sm-4 col-md-4 col-lg-4">
                    <div class="card  shadow-sm  mb-4">
                        <div class="card-body">
                            <h5 class="card-title">Registered Hosts</h5>
                            <ul><asp:Literal id="RegHost" runat="server" mode="Transform"></asp:Literal></ul>
                            <div class="text-center">
                                <a href="RegisteredHosts.aspx" class="btn btn-info text-center">View more</a>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-sm-4 col-md-4 col-lg-4">
                    <div class="card  shadow-sm  mb-4">
                        <div class="card-body">
                            <h5 class="card-title">Registered Tenants</h5>
                            <ul>
                                <asp:Literal id="RegTenant" runat="server" mode="Transform"></asp:Literal>
                            </ul>
                            <div class="text-center">
                                <a href="RegisteredTenants.aspx" class="btn btn-info text-center">View more</a>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-sm-4 col-md-4 col-lg-4">
                    <div class="card  shadow-sm  mb-4">
                        <div class="card-body">
                            <h5 class="card-title">Intended Leases</h5>
                            <ul><asp:Literal id="IntLease" runat="server" mode="Transform"></asp:Literal></ul>
                            <div class="text-center">
                                <a href="IntendedLeases.aspx" class="btn btn-info text-center">View more</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
     
        <section>
            <div class="card-deck row">
                <div class="col-sm-4 col-md-4 col-lg-4">
                    <div class="card shadow-sm  mb-4">
                        <div class="card-body">
                            <h5 class="card-title">RoomMagnet Data</h5>
                            <ul>
                                <asp:Literal id="UserCount" runat="server" mode="Transform"></asp:Literal>
                                <asp:Literal id="LeaseCount" runat="server" mode="Transform"></asp:Literal>
                            </ul>
                        </div>
                    </div>
                </div>
 
                <div class="col-sm-4 col-md-4 col-lg-4">
                    <div class="card shadow-sm  mb-4">
                        <div class="card-body">
                            <h5 class="card-title">Emails for Intellicorp</h5>
                            <ul>
                                <asp:Literal id="futureEmails" runat="server" mode="Transform"></asp:Literal>
                            </ul>
                            <div class="text-center">
                                <a href="#" class="btn btn-info text-center">View more</a>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-sm-4 col-md-4 col-lg-4">
                    <div class="card shadow-sm  mb-4">
                        <div class="card-body">
                            <h5 class="card-title">Create Admin Account</h5>
                            <div class="form-group">
                                <asp:RequiredFieldValidator ID="fnReqFieldValidator" Display ="Dynamic" runat="server" ErrorMessage="Please enter a first name" Visible="False" Text="*Please enter a first name" ControlToValidate="txtFN"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="fnLettersValidator" Display="Dynamic" runat="server" ErrorMessage="Please enter a valid first name" Text="*Please enter a valid first name" ControlToValidate="txtFN" ValidationExpression="^[a-zA-Z]+$"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="txtFN" runat="server" class="form-control form-control-lg" aria-describedby="FirstName" placeholder="First Name" MaxLength="50"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:RequiredFieldValidator ID="lnReqFieldValidator" Display ="Dynamic" runat="server" ErrorMessage="Please enter a last name." ControlToValidate="txtLN" Text="*Please enter a last name"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="lnLetters" Display="Dynamic" runat="server" ErrorMessage="Please enter a valid last name" Text="*Please enter a valid last name" ControlToValidate="txtLN" ValidationExpression="^[a-zA-Z]+$"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="txtLN" runat="server" class="form-control form-control-lg" aria-describedby="LastName" placeholder="Last Name" MaxLength="50"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:RegularExpressionValidator ID="regexEmailValid" Display="Dynamic" runat="server" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="emailReqFieldValidator" Display ="Dynamic" runat="server" ErrorMessage="Please enter an email." ControlToValidate="txtEmail" Text="*Please enter an email"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtEmail" runat="server" class="form-control form-control-lg" aria-describedby="emailHelp" placeholder="Email" MaxLength="50"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                 <asp:RegularExpressionValidator ID="passwordValidator" Display="Dynamic" runat="server" ErrorMessage="Please enter a valid password" Text="*Please enter a password with at least 1 uppercase, 1 lowercase, 1 number, and 1 special character (example: !#&%) " ControlToValidate="txtPassword" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="passwordReqField" Display ="Dynamic" runat="server" ErrorMessage="Please enter a password." ControlToValidate="txtPassword" Text="*Please enter a password"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtPassword" runat="server" class="form-control form-control-lg" placeholder="Password" TextMode="Password" MaxLength="256"></asp:TextBox>
                            </div>
                            <asp:Button ID="btnCreateAdmin" runat="server" Text="Create New Admin" class="btn btn-md btn-info btn-block" CausesValidation="false" OnClick="btnCreateAdmin_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
    <!--END OF DASHBOARD CARDS-->
</asp:Content>

