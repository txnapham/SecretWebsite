<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.master" AutoEventWireup="true" CodeFile="AdminDashboard.aspx.cs" Inherits="AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>RoomMagnet | Dashboard</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid userDash mb-2">
        <!--USER DASH-NAV-->
        <div class="container-fluid userDash pt-2">
            <div class="navbar navbar-light">
                <%--<h4><img src="images/robert.png" alt="..." class="rounded-circle img-fluid" width="30%" height="auto">
                        Welcome Admin,</h4>--%>
                <ul>
                    <asp:literal id="UserNameCard" runat="server" mode="Transform"></asp:literal>
                </ul>
            </div>

        </div>
        <!--END OF USER DASH-NAV-->
    </div>



    <div class="container-fluid">
        <!--Cards start here-->
        <section>
            <div class="card-deck row">
                <div class="col-sm-4 col-md-4 col-lg-4">
                    <div class="card  shadow-sm  mb-4">
                        <div class="card-body">
                            <h5 class="card-title">Registered Hosts</h5>
                            <ul><asp:literal id="Card" runat="server" mode="Transform"></asp:literal></ul>
                            <a href="RegisteredHosts.aspx" class="btn btn-info">View more</a>
                        </div>
                    </div>
                </div>

                <div class="col-sm-4 col-md-4 col-lg-4">
                    <div class="card  shadow-sm  mb-4">
                        <div class="card-body">
                            <h5 class="card-title">Registered Tenants</h5>
                            <ul>
                                <asp:literal id="Card2" runat="server" mode="Transform"></asp:literal>
                            </ul>
                            <a href="RegisteredTenants.aspx" class="btn btn-info">View more</a>
                        </div>
                    </div>
                </div>

                <div class="col-sm-4 col-md-4 col-lg-4">
                    <div class="card  shadow-sm  mb-4">
                        <div class="card-body">
                            <h5 class="card-title">Intended Leases</h5>
                            <ul><asp:literal id="Card3" runat="server" mode="Transform"></asp:literal></ul>
                            <a href="ViewLeases.aspx" class="btn btn-info">View more</a>
                        </div>
                    </div>
                </div>
            </div>
        </section>


        <%--<section>
            <div class="card  shadow-sm  mb-4">
                <div class="card-body">
                    <h5 class="card-title">RoomMagnet Data</h5>
                    <ul>
                        <asp:literal id="Card4" runat="server" mode="Transform"></asp:literal>
                        <asp:literal id="Card5" runat="server" mode="Transform"></asp:literal>
                    </ul>
                    <a href="#" class="btn btn-info">View more</a>
                </div>
            </div>
        </section>--%>
        
        <section>
            <div class="card-deck row">
                <div class="col-sm-8 col-md-8 col-lg-8">
                    <div class="card shadow-sm  mb-4">
                        <div class="card-body">
                            <h5 class="card-title">RoomMagnet Data</h5>
                            <ul>
                                <asp:literal id="Card4" runat="server" mode="Transform"></asp:literal>
                                <asp:literal id="Card5" runat="server" mode="Transform"></asp:literal>
                            </ul>

                            <a href="#" class="btn btn-info">View more</a>
                        </div>
                    </div>
                </div>

                <div class="col-sm-4 col-md-4 col-lg-4">
                    <div class="card shadow-sm  mb-4">
                        <div class="card-body">
                            <h5 class="card-title">Create Admin Account</h5>
                            <div class="form-group">
                                <asp:TextBox ID="txtFN" runat="server" class="form-control form-control-lg" aria-describedby="FirstName" placeholder="First Name" MaxLength="50"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="txtLN" runat="server" class="form-control form-control-lg" aria-describedby="LastName" placeholder="Last Name" MaxLength="50"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="txtEmail" runat="server" class="form-control form-control-lg" aria-describedby="emailHelp" placeholder="Email" MaxLength="50"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="txtPassword" runat="server" class="form-control form-control-lg" placeholder="Password" TextMode="Password" MaxLength="256"></asp:TextBox>
                            </div>

                            <asp:Button ID="btnCreateAdmin" runat="server" Text="Create New Admin" class="btn btn-info" CausesValidation="false" OnClick="btnCreateAdmin_Click"/>
                        </div>
                    </div>
                </div>
            </div>

        </section>



    </div>
    <!--END OF DASHBOARD CARDS-->
</asp:Content>

