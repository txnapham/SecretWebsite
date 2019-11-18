<%@ Page Title="" Language="C#" MasterPageFile="~/HostPage.master" AutoEventWireup="true" CodeFile="HostMessageCenter.aspx.cs" Inherits="HostMessageCenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>RoomMagnet | Message Center</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
 </asp:ScriptManager>
<script>
    function showMessage(tenantID) {
        PageMethods.MessageShower(tenantID);
    };
</script>
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

        <div class="row">

            <div class="col-md-12">
                <div class="pl-3">
                    <button class="btn btn-sm personality-outline">English</button>
                    <button class="btn btn-sm personality-outline">Active</button>
                    <button class="btn btn-sm personality-outline">Non-Smoker</button>
                    <button class="btn btn-sm personality-outline">Adventurous</button>
                    <button class="btn btn-sm personality-outline">Early Riser</button>
                </div>
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
                    <li class="breadcrumb-item active" aria-current="page">Messages</li>
                </ol>
            </nav>
        </section>
        <!--END OF BREADCRUMBS-->


        <div>
            <h3>Messages</h3>
        </div>

        <section>
            <div class="row">
                <div class="col-md-12">
                    <h6>Notifications</h6>
                    <div class="alert alert-light alert-dismissible fade show" role="alert">
                        <strong>Someone messaged you!</strong> Click view message to respond.
                           
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                </div>
            </div>
        </section>

        <section>
            <div class="row">
                <div class="col-md-12">
                    <h5>Messages</h5>
                </div>
            </div>
        </section>

        <!-- <section class=" shadow-sm ">
                
                <div class="row">
                    <div class="col-md-12">
                        <div class="card px-1 py-1">
                            <div class="card-body">
                                <div class="card-title">Liam Brown</div>
                                <div class="card-subtitle">Subject: Meeting Schedule</div>
                                <a href="#" class="btn btn-info">View Message</a>
                            </div>    
                        </div>    
                    </div>    
                </div>
                
                <div class="row">
                    <div class="col-md-12">
                        <div class="card px-1 py-1">
                            <div class="card-body">
                                <div class="card-title">Jake Smith</div>
                                <div class="card-subtitle">Subject: Meeting Schedule</div>
                                <a href="#" class="btn btn-info">View Message</a>
                            </div>    
                        </div>    
                    </div>    
                </div>
                
                
            </section>-->


        <section class="message-center">
            <div class="inbox-msg">
                <div class="inbox-people">
                    <div class="heading-srch">
                        <div class="recent-heading text-center">
                            <h4>Recent</h4>
                        </div>
                    </div>

                    <div class="inbox-chat">
                        <asp:Literal ID="Card" runat="server" Mode="Transform"></asp:Literal>
                    </div>
                </div>

                <div class="mesgs">
                    <div class="msg-history">
                        <div class="incoming-msg">
                            <!--Put card here -->
                            <asp:Literal ID="TMessage" runat="server" Mode="Transform"></asp:Literal>
                        <!--End card here -->
                        </div>
                        <!--Put Card here-->
                        <asp:Literal ID="message2" runat="server" Mode="Transform"></asp:Literal>


                    </div>
                    <div class="type-msg">
                        <div class="input-msg-write">
                            <%--<input type="text" class="write-msg" placeholder="Type a message">--%>
                            <asp:TextBox ID="txtMessage" runat="server" class="write-msg" placeholder="Please DO NOT Share Any Personal Information"></asp:TextBox>
                            <button class="msg-send-btn" type="button"><i class="fas fa-paper-plane"></i></button>
                            <%--<asp:Button ID="btnMessage" runat="server" class="msg-send-btn" Text="Enter" />--%>
                            <%--not sure how to do the button in aspx to make it look like the html. might have to rededign it to fit aspx--%>
                        </div>
                    </div>

                    <div>
                        <button type="button" class="btn btn-light createLeaseButton btn-block" >Create Lease with TENANT NAME
                            <%--<a href="HostCreateLease.aspx" />--%>
                        </button>

                        <button type="button" class="btn createAppointmentButton btn-block">Create Appointment</button>
                    </div>
                </div>
            </div>
        </section>

    </div>

</asp:Content>

