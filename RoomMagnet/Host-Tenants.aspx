<%@ Page Title="" Language="C#" MasterPageFile="~/HostPage.master" AutoEventWireup="true" CodeFile="Host-Tenants.aspx.cs" Inherits="Host_Tenants" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>RoomMagnet | Dashboard | Tenants</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--USER DASH-NAV-->
    <div class="container-fluid userDash mb-2 pb-3">
        <div class="navbar navbar-light">
            <p>
                <img src="images/bettyBrown.png" alt="..." class=" rounded-circle img-fluid" width="30%" height="auto">
                Welcome USER,
            </p>


            <div class="progress" style="height: 30px;">
                <div class="progress-bar bg-info" role="progressbar" style="width: 66%; color: #fff; font-size: 15px; font-weight: bold;" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100">Profile Completion</div>
            </div>
        </div>

    </div>
    <!--END OF USER DASH-NAV-->



    <div class="container-fluid px-5">
        <!--BREADCRUMBS-->
        <section>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="HostDashboard.aspx" class="breadLink">Dashboard</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Tenants</li>
                </ol>
            </nav>
        </section>
        <!--END OF BREADCRUMBS-->


        <div>
            <h3>Tenants</h3>
        </div>

        <section>
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <h6>Notification</h6>
                    <div class="alert alert-light alert-dismissible fade show" role="alert">
                        Someone favorited your property!
                           
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                </div>
            </div>
        </section>


        <section>
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12">

                    <div class="text-center">
                        <img src="images/rebeccajames.png" alt="..." class=" rounded-circle img-fluid" width="20%" height="auto">
                        <h3>Natalia Russo</h3>
                    </div>
                </div>
            </div>
        </section>



    </div>
</asp:Content>

