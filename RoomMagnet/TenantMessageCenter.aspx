<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/TenantPage.master" AutoEventWireup="true" CodeFile="TenantMessageCenter.aspx.cs" Inherits="TenantMessageCenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>RoomMagnet | Message Center</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
                                <asp:Literal ID="Message" runat="server" Mode="Transform"></asp:Literal>
                            </div>
                        </div>
                    <div class="type-msg">
                        <div class="input-msg-write">
                            <asp:TextBox ID="txtMessage" runat="server" class="write-msg" placeholder="Type a message"></asp:TextBox>
                            <asp:LinkButton id="LinkButton2" runat="server" class="msg-send-btn" type="button" Text ="Send" OnClick="messagebtn_Click"/>
                        </div>
                    </div>
                    <div>
                        <button type="button" class="btn btn-light createLeaseButton btn-block" href="HostCreateLease.aspx">Create Lease with TENANT NAME</button>
                        <button type="button" class="btn createAppointmentButton btn-block">Create Appointment</button>
                        <a href="TenantTest.aspx" class="btn btn-light vidChat btn-block">Video Chat</a>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

