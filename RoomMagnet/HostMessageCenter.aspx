﻿<%@ Page MaintainScrollPositionOnPostback="true" Title="" Language="C#" MasterPageFile="~/HostPage.master" AutoEventWireup="true" CodeFile="HostMessageCenter.aspx.cs" Inherits="HostMessageCenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>RoomMagnet | Message Center</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
 </asp:ScriptManager>
<script>
    function createLease() {
        PageMethods.CreateLease();
    };
</script>
<script>
    function ApproveFunction() {
        alert("Lease has been sent for tenant approval!")
    }
</script>

<script>
    function SentFunction() {
        alert("Lease is currently is pending tenant approval!")
    }
</script>

<%--    <!--USER DASH-NAV-->
    <div class="container-fluid userDash mb-2 pb-3">
        <div class="navbar navbar-light">
            <p>
                            <asp:Literal ID="HostCard" runat="server" Mode="Transform"></asp:Literal>
            </p>


            <div class="progress" style="height: 30px;">
                <div class="progress-bar bg-info" role="progressbar" style="width: 66%; color: #fff; font-size: 15px; font-weight: bold;" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100">Profile Completion</div>
            </div>
        </div>

    </div>
    <!--END OF USER DASH-NAV-->--%>

    <div class="container-fluid mt-5 px-5">
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

<%--        <section>
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
        </section>--%>

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
                        <asp:Repeater id="inboxRepeater" runat="server">
                            <ItemTemplate>
                                <div class="chat-list">
                                    <div class="chat-people">
                                        <div class="chat-img">
                                            <asp:ImageButton 
                                                id="imageButton" 
                                                runat="server" 
                                                ImageUrl='<%# Eval("imageURL") %>' 
                                                class="rounded-circle img-fluid" 
                                                CustomParameter='<%# Eval("messagerID") %>' 
                                                onClick= "btnSubmit_Click"/>
                                        </div>
                                        
                                        <div class="chat-ib">
                                            <h5><%# Eval("messagerName") %></h5>
                                            <p><%# Eval("latestMessage") %></p>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

                <div class="mesgs">
                    <div class="msg-history">
                        <div class="incoming-msg">
                            <!--Put card here -->
                            
                            <asp:Literal ID="Message" runat="server" Mode="Transform"></asp:Literal>
                        <!--End card here -->
                    </div>
                        </div>
                    <div class="type-msg">
                        <div class="input-msg-write">
                            <%--<input type="text" class="write-msg" placeholder="Type a message">--%>
                            <asp:TextBox ID="txtMessage" runat="server" class="write-msg" placeholder="Please DO NOT Share Any Personal Information" Width="665px"></asp:TextBox>
                            <asp:LinkButton id="LinkButton2" runat="server" class="msg-send-btn" type="button" Text ="Send" OnClick="messagebtn_Click"/>
                        </div>
                    </div>

                    <div>
<%--                        <asp:Button ID="createLeaseBtn" runat="server" Text="Create Lease" class="btn btn-light createLeaseButton btn-block" OnClick="createLeaseBtn_Click"></asp:Button>--%>
                        <asp:Button ID="createLeaseBtn" runat="server" CssClass="btn btn-light createLeaseButton btn-block" data-toggle="modal" data-target="#createLease" Text="Create Lease" OnClientClick="return false;" />
<%--                        <button text="Create Lease" class="btn btn-light createLeaseButton btn-block" type="button" data-toggle="modal" data-target="#createLease">
                            <a class="btn btn-light createLeaseButton btn-block" href="#">Create Lease</a>
                        </button>
                        <asp:Button ID="aptBtn" runat="server" Text="Create Appointment" class="btn createAppointmentButton btn-block"></asp:Button>--%>
                        <asp:Button ID="videoChat" runat="server" Text="Video Chat" class="btn btn-light vidChat btn-block mb-4" OnClick="videoChat_Click"></asp:Button>
                    </div>

                    <div class="modal" id="createLease">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-body">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>

                                    <div class="form-group">
                                        <%--<asp:TextBox ID="txtRecipient" runat="server" class="form-control" placeholder="Recipient"></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddProperty" runat="server" AppendDataBoundItems="True" class="form-control form-control-lg" DataSourceID="propertyDataSource" DataTextField="Address" DataValueField="PropertyID">
                                            <asp:ListItem>Select a Property for Lease</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="propertyDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:roommagnetdbConnectionString %>" SelectCommand="SELECT PropertyID, (HouseNumber + ' ' + Street + ', ' + City + ', ' + HomeState) AS Address FROM PROPERTY WHERE HostID = @AccountId">
                                            <SelectParameters>
                                                <asp:SessionParameter Name="AccountId" SessionField="AccountId"/>
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </div>

                                    <asp:Button ID="createLeaseClick" runat="server" Text="Create Lease" class="btn btn-md btn-info btn-block" OnClick="createLeaseBtn_Click"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>


    </div>
</asp:Content>

