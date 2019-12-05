<%@ Page Title="" Language="C#" MasterPageFile="~/TenantPage.master" AutoEventWireup="true" CodeFile="TenantDashboard.aspx.cs" Inherits="TenantDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>RoomMagnet | Dashboard</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!--USER DASH-NAV-->
    <div class="container-fluid userDash mb-2 pb-3">
        <div class="navbar navbar-light">
            <u1>
                <asp:Literal ID="TenantCard" runat="server" Mode="Transform"></asp:Literal>
                <asp:Literal ID="progressBar" runat="server" Mode="Transform"></asp:Literal>
            </u1>
        </div>
    </div>
    <!--END OF USER DASH-NAV-->



    <!--reminders-->
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-12">
                    <asp:Literal ID="alert1" runat="server" Mode="Transform"></asp:Literal>
                </div>

                <div class="col-md-12">
                    <asp:Literal ID="alert2" runat="server" Mode="Transform"></asp:Literal>
                </div>
            </div>
        </div>
    </div>
    <!--end of reminders-->

    <!--DASHBOARD CARDS-->
    <div class="container-fluid px-5">
        <section>
            <div class="row">
                <div class="col-md-8">
                    <!--PROPERTIES-->
                    <div class="card  shadow-sm  mb-4">
                        <div class="card-body">
                            <h5 class="card-title dash-card-titles">Favorite Properties</h5>

                            <ul>
                                <div class="row px-4 py-3">
                                    <asp:Literal ID="favProp" runat="server" Mode="Transform"></asp:Literal>
                                </div>
                            </ul>

                            <div class=" text-center">
                                <a href="FavoritedProperties.aspx" class="btn btn-info text-center">View more</a>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="card  shadow-sm  mb-4">
                        <div class="card-body">
                            <h5 class="card-title dash-card-titles">Message Center</h5>
                            <asp:Literal ID="hostMsg" runat="server" Mode="Transform"></asp:Literal>

                            <div class=" text-center pt-3">
                                <a href="TenantMessageCenter.aspx" class="btn btn-info">View Messages</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row pt-4">
                <div class="col-md-12">
                    <div class="card  shadow-sm  mb-4">
                        <div class="card-body">
                            <h5 class="card-title dash-card-titles">My Appointments</h5>
                            <%--<div class="container-fluid cal pb-3">
                                <div>
                                    <h4 class="mb-4 text-center">November 2019</h4>
                                    <div class="row d-none d-sm-flex p-1 bg-dark text-white">
                                        <p class="col-sm p-1 text-center">Sun</p>
                                        <p class="col-sm p-1 text-center">Mon</p>
                                        <p class="col-sm p-1 text-center">Tues</p>
                                        <p class="col-sm p-1 text-center">Wed</p>
                                        <p class="col-sm p-1 text-center">Thurs</p>
                                        <p class="col-sm p-1 text-center">Fri</p>
                                        <p class="col-sm p-1 text-center">Sat</p>
                                    </div>
                                </div>
                                <div class="row border border-right-0 border-bottom-0">
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate d-none d-sm-inline-block text-muted">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">29</span>
                                            <small class="col d-sm-none text-center text-muted">Sunday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate d-none d-sm-inline-block text-muted">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">30</span>
                                            <small class="col d-sm-none text-center text-muted">Monday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate d-none d-sm-inline-block text-muted">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">31</span>
                                            <small class="col d-sm-none text-center text-muted">Tuesday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">1</span>
                                            <small class="col d-sm-none text-center text-muted">Wednesday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">2</span>
                                            <small class="col d-sm-none text-center text-muted">Thursday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">3</span>
                                            <small class="col d-sm-none text-center text-muted">Friday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <a class="event d-block p-1 pl-2 pr-2 mb-1 rounded text-truncate small bg-info text-white" title="Test Event 1">Meeting with Robert Johnson</a>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">4</span>
                                            <small class="col d-sm-none text-center text-muted">Saturday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="w-100"></div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">5</span>
                                            <small class="col d-sm-none text-center text-muted">Sunday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">6</span>
                                            <small class="col d-sm-none text-center text-muted">Monday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">7</span>
                                            <small class="col d-sm-none text-center text-muted">Tuesday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">8</span>
                                            <small class="col d-sm-none text-center text-muted">Wednesday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">9</span>
                                            <small class="col d-sm-none text-center text-muted">Thursday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">10</span>
                                            <small class="col d-sm-none text-center text-muted">Friday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">11</span>
                                            <small class="col d-sm-none text-center text-muted">Saturday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="w-100"></div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">12</span>
                                            <small class="col d-sm-none text-center text-muted">Sunday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">13</span>
                                            <small class="col d-sm-none text-center text-muted">Monday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">14</span>
                                            <small class="col d-sm-none text-center text-muted">Tuesday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">15</span>
                                            <small class="col d-sm-none text-center text-muted">Wednesday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">16</span>
                                            <small class="col d-sm-none text-center text-muted">Thursday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">17</span>
                                            <small class="col d-sm-none text-center text-muted">Friday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">18</span>
                                            <small class="col d-sm-none text-center text-muted">Saturday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="w-100"></div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">19</span>
                                            <small class="col d-sm-none text-center text-muted">Sunday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">20</span>
                                            <small class="col d-sm-none text-center text-muted">Monday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <a class="event d-block p-1 pl-2 pr-2 mb-1 rounded text-truncate small bg-primary text-white" title="Test Event with Super Duper Really Long Title">Meeting with Karen Smith</a>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">21</span>
                                            <small class="col d-sm-none text-center text-muted">Tuesday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">22</span>
                                            <small class="col d-sm-none text-center text-muted">Wednesday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">23</span>
                                            <small class="col d-sm-none text-center text-muted">Thursday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">24</span>
                                            <small class="col d-sm-none text-center text-muted">Friday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">25</span>
                                            <small class="col d-sm-none text-center text-muted">Saturday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="w-100"></div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">26</span>
                                            <small class="col d-sm-none text-center text-muted">Sunday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">27</span>
                                            <small class="col d-sm-none text-center text-muted">Monday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">28</span>
                                            <small class="col d-sm-none text-center text-muted">Tuesday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">29</span>
                                            <small class="col d-sm-none text-center text-muted">Wednesday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate ">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">30</span>
                                            <small class="col d-sm-none text-center text-muted">Thursday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate d-none d-sm-inline-block  text-muted">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">1</span>
                                            <small class="col d-sm-none text-center text-muted">Friday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate d-none d-sm-inline-block text-muted">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">2</span>
                                            <small class="col d-sm-none text-center text-muted">Saturday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="w-100"></div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate d-none d-sm-inline-block text-muted">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">3</span>
                                            <small class="col d-sm-none text-center text-muted">Sunday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate d-none d-sm-inline-block text-muted">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">4</span>
                                            <small class="col d-sm-none text-center text-muted">Monday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate d-none d-sm-inline-block text-muted">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">5</span>
                                            <small class="col d-sm-none text-center text-muted">Tuesday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate d-none d-sm-inline-block  text-muted">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">6</span>
                                            <small class="col d-sm-none text-center text-muted">Wednesday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate d-none d-sm-inline-block  text-muted">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">7</span>
                                            <small class="col d-sm-none text-center text-muted">Thursday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate d-none d-sm-inline-block  text-muted">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">8</span>
                                            <small class="col d-sm-none text-center text-muted">Friday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                    <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate d-none d-sm-inline-block text-muted">
                                        <h5 class="row align-items-center">
                                            <span class="date col-1">9</span>
                                            <small class="col d-sm-none text-center text-muted">Saturday</small>
                                            <span class="col-1"></span>
                                        </h5>
                                        <p class="d-sm-none">No events</p>
                                    </div>
                                </div>
                            </div>--%>

                            <div>
                                <table style="width: 100%;">
                                    <tr>
                                        <td><asp:Literal ID="apptName" runat="server"></asp:Literal></td>
                                        <td><asp:Literal ID="apptDate" runat="server"></asp:Literal></td>
                                    </tr>
                                </table>

                            </div>


                            <button class="nav-item btn createAppointment btn-block" type="button" data-toggle="modal" data-target="#createAppointment">
                                <a class="btn btn-md btn-info" href="#">Create Appointment</a>
                            </button>
                            <div class="modal" id="createAppointment">
                                <div class="modal-dialog">
                                    <div class="modal-content">

                                        <div class="modal-body">
                                            <button type="button" class="close" data-dismiss="modal">&times;</button>

                                            <div class="form-group">
                                                <%--<asp:TextBox ID="txtRecipient" runat="server" class="form-control" placeholder="Recipient"></asp:TextBox>--%>
                                                <asp:DropDownList ID="ddRecipient" runat="server" AppendDataBoundItems="True" class="form-control form-control-lg" DataSourceID="tenantDataSource" DataTextField="NAME" DataValueField="AccountID">
                                                    <asp:ListItem>Please Select a Recipient</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="tenantDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:roommagnetdbConnectionString %>" SelectCommand="SELECT AccountID, (FirstName + ' ' + LastName) AS NAME FROM Account WHERE AccountID IN (SELECT HostID FROM FavoritedTenants WHERE TenantID = @AccountId ) ORDER BY (FirstName + ' ' + LastName)">
                                                    <SelectParameters>
                                                        <asp:SessionParameter Name="AccountId" SessionField="AccountId" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                                <asp:Label ID="lblRError" runat="server" Text="" ForeColor="Red"></asp:Label>
                                            </div>

                                            <div class="form-group">
                                                <asp:TextBox ID="txtDate" type="date" runat="server" class="form-control form-control-lg" placeholder="Date (MM/DD/YYYY)"></asp:TextBox>
                                                <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
                                            </div>


                                            <asp:Button ID="btnCreateAppt" runat="server" Text="Create Appointment " class="btn btn-md btn-info btn-block" OnClick="btnCreateAppt_Click " />





                                        </div>
                                    </div>
                                </div>
                            </div>

                            <!--END OF BUTTON-->
                        </div>
                    </div>
                </div>
            </div>
        </section>





    </div>
    <!--END OF DASHBOARD CARDS-->

        <!-- script to keep modal open -->
    <script type="text/javascript">
        function showModal() {
            $('#createAppointment').modal('show');
        }

        $(function () {
            $("#btnCreateAppt").click(function () {
                showModal();
            });
        });
    </script>

</asp:Content>

