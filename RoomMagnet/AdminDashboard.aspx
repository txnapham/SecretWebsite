<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.master" AutoEventWireup="true" CodeFile="AdminDashboard.aspx.cs" Inherits="AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>RoomMagnet | Dashboard</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid userDash mb-5">
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



    <div class="container-fluid px-5">
        <!--Cards start here-->
        <section>
            <div class="card-deck">
                <div class="card  shadow-sm  mb-4">
                    <div class="card-body">
                        <h5 class="card-title">Registered Hosts</h5>

                        <ul>
                            <asp:literal id="Card" runat="server" mode="Transform"></asp:literal>

                        </ul>


                        <a href="#" class="btn btn-info">View more</a>
                    </div>
                </div>

                <div class="card  shadow-sm  mb-4">
                    <div class="card-body">
                        <h5 class="card-title">Registered Tenants</h5>

                        <ul>
                            <asp:literal id="Card2" runat="server" mode="Transform"></asp:literal>
                        </ul>


                        <a href="#" class="btn btn-info">View more</a>
                    </div>
                </div>

                <div class="card  shadow-sm  mb-4">
                    <div class="card-body">
                        <h5 class="card-title">Intended Leases</h5>

                        <ul>
                            <asp:literal id="Card3" runat="server" mode="Transform"></asp:literal>
                        </ul>


                        <%--<a href="intent-to-lease.html" class="btn btn-info">View more</a> --%>
                        <%--should not go to intent to lease--%>
                    </div>
                </div>



            </div>

        </section>


        <section>
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

        </section>



    </div>
    <!--END OF DASHBOARD CARDS-->
</asp:Content>

