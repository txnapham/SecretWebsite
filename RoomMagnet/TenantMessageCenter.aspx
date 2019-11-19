<%@ Page Title="" Language="C#" MasterPageFile="~/TenantPage.master" AutoEventWireup="true" CodeFile="TenantMessageCenter.aspx.cs" Inherits="TenantMessageCenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>RoomMagnet | Message Center</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--USER DASH-NAV-->
    <div class="container-fluid userDash mb-2 pb-3">
        <div class="navbar navbar-light">
            <p>
                <img src="images/rebeccajames.png" alt="..." class=" rounded-circle img-fluid" width="30%" height="auto">
                Welcome USER,</p>


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
                    <li class="breadcrumb-item"><a href="TenantDashboard.aspx" class="breadLink">Dashboard</a></li>
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



        <section class="message-center">
            <div class="inbox-msg">
                <div class="inbox-people">
                    <div class="heading-srch">
                        <div class="recent-heading text-center">
                            <h4>Recent</h4>
                        </div>
                    </div>

                    <div class="inbox-chat">
                        <div class="chat-list">
                            <div class="chat-people">
                                <div class="chat-img">
                                    <img src="images/bettyBrown.png" class="rounded-circle img-fluid"></div>
                                <div class="chat-ib">
                                    <h5>Karen Smith<span class="chat-date">Nov 12</span></h5>
                                    <p>text</p>
                                </div>
                            </div>
                        </div>
                        <div class="chat-list">
                            <div class="chat-people">
                                <div class="chat-img">
                                    <img src="images/bettyBrown.png" class="rounded-circle img-fluid"></div>
                                <div class="chat-ib">
                                    <h5>Name <span class="chat-date">Nov 12</span></h5>
                                    <p>text</p>
                                </div>
                            </div>
                        </div>
                        <div class="chat-list">
                            <div class="chat-people">
                                <div class="chat-img">
                                    <img src="images/bettyBrown.png" class="rounded-circle img-fluid"></div>
                                <div class="chat-ib">
                                    <h5>Name <span class="chat-date">Nov 12</span></h5>
                                    <p>text</p>
                                </div>
                            </div>
                        </div>
                        <div class="chat-list">
                            <div class="chat-people">
                                <div class="chat-img">
                                    <img src="images/bettyBrown.png" class="rounded-circle img-fluid"></div>
                                <div class="chat-ib">
                                    <h5>Name <span class="chat-date">Nov 12</span></h5>
                                    <p>text</p>
                                </div>
                            </div>
                        </div>
                        <div class="chat-list">
                            <div class="chat-people">
                                <div class="chat-img">
                                    <img src="images/bettyBrown.png" class="rounded-circle img-fluid"></div>
                                <div class="chat-ib">
                                    <h5>Name <span class="chat-date">Nov 12</span></h5>
                                    <p>text</p>
                                </div>
                            </div>
                        </div>
                        <div class="chat-list">
                            <div class="chat-people">
                                <div class="chat-img">
                                    <img src="images/bettyBrown.png" class="rounded-circle img-fluid"></div>
                                <div class="chat-ib">
                                    <h5>Name <span class="chat-date">Nov 12</span></h5>
                                    <p>text</p>
                                </div>
                            </div>
                        </div>
                        <div class="chat-list">
                            <div class="chat-people">
                                <div class="chat-img">
                                    <img src="images/bettyBrown.png" class="rounded-circle img-fluid"></div>
                                <div class="chat-ib">
                                    <h5>Name <span class="chat-date">Nov 12</span></h5>
                                    <p>text</p>
                                </div>
                            </div>
                        </div>
                        <div class="chat-list">
                            <div class="chat-people">
                                <div class="chat-img">
                                    <img src="images/bettyBrown.png" class="rounded-circle img-fluid"></div>
                                <div class="chat-ib">
                                    <h5>Name <span class="chat-date">Nov 12</span></h5>
                                    <p>text</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="mesgs">
                    <div class="msg-history">
                        <div class="incoming-msg">
                            <div class="incoming-msg-img">
                                <img src="images/bettyBrown.png" class="rounded-circle img-fluid">
                            </div>
                            <div class="recieved-msg">
                                <div class="recieved-withd-msg">
                                    <p>Message sent to property owner</p>
                                    <span class="time-date">11:21 AM   |   Nov 11</span>
                                </div>
                            </div>
                        </div>
                        <div class="outgoing-msg">
                            <div class="sent-msg">
                                <p>Test of outgoing message</p>
                                <span class="time-date">11:30 AM    |   Nov 11</span>
                            </div>
                        </div>
                        <div class="incoming-msg">
                            <div class="incoming-msg-img">
                                <img src="images/bettyBrown.png" class="rounded-circle img-fluid">
                            </div>
                            <div class="recieved-msg">
                                <div class="recieved-withd-msg">
                                    <p>Message sent to property owner</p>
                                    <span class="time-date">11:21 AM   |   Nov 11</span>
                                </div>
                            </div>
                        </div>
                        <div class="outgoing-msg">
                            <div class="sent-msg">
                                <p>Test of outgoing message</p>
                                <span class="time-date">11:30 AM    |   Nov 11</span>
                            </div>
                        </div>
                        <div class="incoming-msg">
                            <div class="incoming-msg-img">
                                <img src="images/bettyBrown.png" class="rounded-circle img-fluid">
                            </div>
                            <div class="recieved-msg">
                                <div class="recieved-withd-msg">
                                    <p>Message sent to property owner</p>
                                    <span class="time-date">11:21 AM   |   Nov 11</span>
                                </div>
                            </div>
                        </div>
                        <div class="outgoing-msg">
                            <div class="sent-msg">
                                <p>Test of outgoing message</p>
                                <span class="time-date">11:30 AM    |   Nov 11</span>
                            </div>
                        </div>
                        <div class="incoming-msg">
                            <div class="incoming-msg-img">
                                <img src="images/bettyBrown.png" class="rounded-circle img-fluid">
                            </div>
                            <div class="recieved-msg">
                                <div class="recieved-withd-msg">
                                    <p>Message sent to property owner</p>
                                    <span class="time-date">11:21 AM   |   Nov 11</span>
                                </div>
                            </div>
                        </div>
                        <div class="outgoing-msg">
                            <div class="sent-msg">
                                <p>Test of outgoing message</p>
                                <span class="time-date">11:30 AM    |   Nov 11</span>
                            </div>
                        </div>
                        <div class="incoming-msg">
                            <div class="incoming-msg-img">
                                <img src="images/bettyBrown.png" class="rounded-circle img-fluid">
                            </div>
                            <div class="recieved-msg">
                                <div class="recieved-withd-msg">
                                    <p>Message sent to property owner</p>
                                    <span class="time-date">11:21 AM   |   Nov 11</span>
                                </div>
                            </div>
                        </div>
                        <div class="outgoing-msg">
                            <div class="sent-msg">
                                <p>Test of outgoing message</p>
                                <span class="time-date">11:30 AM    |   Nov 11</span>
                            </div>
                        </div>

                    </div>
                    <div class="type-msg">
                        <div class="input-msg-write">
                            <asp:TextBox ID="txtMessage" runat="server" class="write-msg" placeholder="Type a message"></asp:TextBox>
                            <button class="msg-send-btn" type="button"><i class="fas fa-paper-plane"></i></button>
                            <%--<asp:Button ID="btnMessage" runat="server" class="msg-send-btn" Text="Enter" />--%>
                            <%--not sure how to do the button in aspx to make it look like the html. might have to rededign it to fit aspx--%>
                        </div>
                    </div>
                    <div>
                        <button type="button" class="btn btn-light createLeaseButton btn-block" href="HostCreateLease.aspx">Create Lease with TENANT NAME</button>

                        <button type="button" class="btn createAppointmentButton btn-block">Create Appointment</button>
                    </div>
                </div>
            </div>
        </section>



    </div>

</asp:Content>

