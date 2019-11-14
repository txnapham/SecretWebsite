<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.master" AutoEventWireup="true" CodeFile="AdminDashboard.aspx.cs" Inherits="AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>RoomMagnet | Dashboard</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid px-5">
        <!--Cards start here-->
        <section>
            <div class="card-deck">
                <div class="card  shadow-sm  mb-4">
                    <div class="card-body">
                        <h5 class="card-title">Registered Hosts</h5>

                        <ul>
                            <li><a class="tenantdashlist" href="#">Karen Smith</a></li>
                            <li><a class="tenantdashlist" href="#">Robert Johnson</a></li>
                            <li><a class="tenantdashlist" href="#">Betty Brown</a></li>
                            <li><a class="tenantdashlist" href="#">John Miller</a></li>
                        </ul>


                        <a href="#" class="btn btn-info">View more</a>
                    </div>
                </div>

                <div class="card  shadow-sm  mb-4">
                    <div class="card-body">
                        <h5 class="card-title">Registered Tenants</h5>

                        <ul>
                            <li><a class="tenantdashlist" href="#">Liam Brown</a></li>
                            <li><a class="tenantdashlist" href="#">Jessica Cruz</a></li>
                            <li><a class="tenantdashlist" href="#">Jake Smith</a></li>
                            <li><a class="tenantdashlist" href="#">Hellen Wilson</a></li>
                        </ul>


                        <a href="#" class="btn btn-info">View more</a>
                    </div>
                </div>

                <div class="card  shadow-sm  mb-4">
                    <div class="card-body">
                        <h5 class="card-title">Intended Leases</h5>

                        <ul>
                            <li><a class="tenantdashlist" href="#"></a></li>
                            <li><a class="tenantdashlist" href="#"></a></li>
                            <li><a class="tenantdashlist" href="#"></a></li>
                            <li><a class="tenantdashlist" href="#"></a></li>
                        </ul>


                        <a href="intent-to-lease.html" class="btn btn-info">View more</a>
                    </div>
                </div>



            </div>

        </section>


        <section>
            <div class="card  shadow-sm  mb-4">
                <div class="card-body">
                    <h5 class="card-title">RoomMagnet Data</h5>
                    <p>Number of Users: 5260</p>
                    <p>Number of Leases: 735</p>

                    <a href="#" class="btn btn-info">View more</a>
                </div>
            </div>

        </section>



    </div>
    <!--END OF DASHBOARD CARDS-->
</asp:Content>

