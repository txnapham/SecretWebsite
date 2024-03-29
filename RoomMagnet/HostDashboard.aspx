﻿<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/HostPage.master" AutoEventWireup="true" CodeFile="HostDashboard.aspx.cs" Inherits="HostDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>RoomMagnet | Dashboard</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <script>
        function insertMessage(tenantID, hostID) {
            PageMethods.MessageInsert(tenantID, hostID);
        };
    </script>
    <!--USER DASH-NAV-->
    <div class="container-fluid mb-2 pb-3 mt-5 pt-4" style="padding-right: 0px; padding-left: 0px">
        <div class="card" style="background-color: #f7f7ff; margin-right: 0px; margin-left: 0px">
            <table style="width: 100%; border:hidden;">
                <tr>
                    <td style="width:200px; height: auto;">
                        <asp:Literal ID="HostCard" runat="server" Mode="Transform"></asp:Literal>
                    </td>
                    <td class="pb-5" style="vertical-align:bottom">
                        <asp:Literal ID="HostCard2" runat="server" Mode="Transform"></asp:Literal>
                    </td>
                    <td>
                        <asp:Literal ID="progressBar" runat="server" Mode="Transform"></asp:Literal>
                    </td>
                </tr>
            </table>
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
    <div class="container-fluid px-5 ">
        <section>
            <div class="row">
                <div class="col-md-6">

                    <!--PROPERTIES MOD-->
                    <div class="col-md-12">
                        <div class="card  shadow-sm  mb-4">
                            <h5 class="card-header">Properties</h5>
                            <div class="card-body">
                                

                                <div class="text-center" style="padding-left: 90%;">
                                    <a class="dropdown-toggle btn-info addmorePropButton" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">+</a>
                                    <div class="dropdown-menu">
                                        <a class="dropdown-item js-scroll-trigger" href="ListPropertyForm.aspx">Add Property</a>
                                        <button style="color: #000;" type="button" class="btn  dropdown-item js-scroll-trigger" data-toggle="modal" data-dismiss="modal" data-target="#addRoom">
                                        Add Room</>
                                    </div>
                                </div>

                                <!--ADD ROOM MOD-->
                                <div class="modal justify-content-center from-control" id="addRoom">
                                    <div class="modal-dialog modal-lg">
                                        <div class="modal-content pb-1">

                                            <!-- Modal Header -->
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            </div>

                                            <!-- Modal body -->
                                            <div class="modal-body ">
                                                <div class="pb-3">
                                                    <h5 class="modal-title">Add Your Room:</h5>
                                                </div>

                                                <div class="form-group">
                                                    <%--<asp:TextBox ID="txtRecipient" runat="server" class="form-control" placeholder="Recipient"></asp:TextBox>--%>
                                                    <asp:DropDownList ID="ddProperty" runat="server" AppendDataBoundItems="True" class="form-control form-control-lg" DataSourceID="propertyDataSource" DataTextField="Address" DataValueField="PropertyID">
                                                        <asp:ListItem>Please Select a Property</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource ID="propertyDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:roommagnetdbConnectionString %>" SelectCommand="SELECT PropertyID, (HouseNumber + ' ' + Street + ', ' + City + ', ' + HomeState) AS Address FROM PROPERTY WHERE HostID = @AccountId">
                                                        <SelectParameters>
                                                            <asp:SessionParameter Name="AccountId" SessionField="AccountId" />
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>
                                                </div>

                                                <asp:TextBox ID="txtPrice" runat="server" class="form-control form-control-lg" placeholder="Price"></asp:TextBox>
                                                <br />
                                                <asp:TextBox ID="txtDescription" name="txtDescription" runat="server" class="form-control form-control-lg" placeholder="Description" Height="100px"></asp:TextBox>

                                                <section>
                                                    <div class="row pt-3">
                                                        <div class="col-md-12">
                                                            <h5>Please select amenities that apply to you:</h5>
                                                        </div>
                                                    </div>
                                                </section>
                                                <!--Amenities Start here-->
                                                <section>
                                                    <div class="row px-3 py-3">
                                                        <div class="col-md-6">

                                                            <div class="col-md-12">
                                                                <div class="switchwrapper">
                                                                    <label class="switch">
                                                                        <asp:CheckBox ID="cbPrivateBR" runat="server" />
                                                                        <span class="slider round"></span>
                                                                    </label>
                                                                    <div>Private Bathroom</div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12">
                                                                <div class="switchwrapper">
                                                                    <label class="switch">
                                                                        <asp:CheckBox ID="cbWalkInClos" runat="server" />
                                                                        <span class="slider round"></span>
                                                                    </label>
                                                                    <div>Walk-In Closet</div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12">
                                                                <div class="switchwrapper">
                                                                    <label class="switch">
                                                                        <asp:CheckBox ID="cbWashDry" runat="server" />
                                                                        <span class="slider round"></span>
                                                                    </label>
                                                                    <div>Washer / Dryer</div>
                                                                </div>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-6">
                                                            <div class="col-md-12">
                                                                <div class="switchwrapper">
                                                                    <label class="switch">
                                                                        <asp:CheckBox ID="cbKitchen" runat="server" />
                                                                        <span class="slider round"></span>
                                                                    </label>
                                                                    <div>Kitchen</div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12">
                                                                <div class="switchwrapper">
                                                                    <label class="switch">
                                                                        <asp:CheckBox ID="cbWifi" runat="server" />
                                                                        <span class="slider round"></span>
                                                                    </label>
                                                                    <div>Wifi</div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12">
                                                                <div class="switchwrapper">
                                                                    <label class="switch">
                                                                        <asp:CheckBox ID="cbHVAC" runat="server" />
                                                                        <span class="slider round"></span>
                                                                    </label>
                                                                    <div>Heating / Air Conditioning</div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </section>
                                                <!--end of amenities-->

                                                <asp:Button ID="btnAddRoom" runat="server" Text="Add Room" class="btn btn-md btn-info btn-block" CausesValidation="true" OnClick="btnAddRoom_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <ul>
                                    <asp:Literal ID="properties" runat="server" Mode="Transform"></asp:Literal>
                                </ul>
                                <!--BUTTON-->
                                <div class=" text-center">
                                    <a href="EditProperty.aspx" class="btn btn-info">Edit Properties</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--END OF PROPERTIES MOD-->

                    <!--message mod-->
                    <div class="col-md-12">
                        <div class="card shadow-sm  mb-4">
                            <h5 class="card-header">Tenants Who Like My Property</h5>
                            <div class="card-body">
                                <asp:Literal ID="favTen" runat="server" Mode="Transform"></asp:Literal>
                                <!--BUTTON-->
                                <div class=" text-center pt-3 pb-3">
                                    <a href="HostMessageCenter.aspx" class="btn btn-info">View Message Center</a>
                                </div>
                                <!--END OF BUTTON-->
                            </div>
                        </div>
                    </div>
                </div>
                <!--END OF MESSAGE MOD-->

                <div class="col-md-6">
                    <!--TENANT/HOST MOD-->
                    <div class="col-md-12">
                        <div class="card  shadow-sm  mb-4">
                            <h5 class="card-header">Current Tenants</h5>
                            <div class="card-body">
                                <ul>
                                    <asp:Literal ID="currTen" runat="server" Mode="Transform"></asp:Literal>
                                </ul>
                                <!--BUTTON-->
                                <div class=" text-center">
                                    <a href="#" class="btn btn-info">View more</a>
                                </div>
                                <!--END OF BUTTON-->
                            </div>
                        </div>
                    </div>
                    <!--END OF TENANT/HOST MOD-->

                    <!--APPOINTMENT MOD-->
                    <div class="col-md-12">
                        <div class="card  shadow-sm  mb-4">
                            <h5 class="card-header">My Appointments</h5>
                            <div class="card-body">
                                <!-- <div class="container-fluid cal pb-3">
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
                                        <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate d-none d-sm-inline-block  text-muted">
                                            <h5 class="row align-items-center">
                                                <span class="date col-1">29</span>
                                                <small class="col d-sm-none text-center text-muted">Sunday</small>
                                                <span class="col-1"></span>
                                            </h5>
                                            <p class="d-sm-none">No events</p>
                                        </div>
                                        <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate d-none d-sm-inline-block  text-muted">
                                            <h5 class="row align-items-center">
                                                <span class="date col-1">30</span>
                                                <small class="col d-sm-none text-center text-muted">Monday</small>
                                                <span class="col-1"></span>
                                            </h5>
                                            <p class="d-sm-none">No events</p>
                                        </div>
                                        <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate d-none d-sm-inline-block  text-muted">
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
                                            <a class="event d-block p-1 pl-2 pr-2 mb-1 rounded text-truncate small bg-info text-white" title="Test Event 1">Meeting</a>
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
                                            <a class="event d-block p-1 pl-2 pr-2 mb-1 rounded text-truncate small bg-primary text-white" title="Test Event with Super Duper Really Long Title">Meeting</a>
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
                                        <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate d-none d-sm-inline-block  text-muted">
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
                                        <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate d-none d-sm-inline-block  text-muted">
                                            <h5 class="row align-items-center">
                                                <span class="date col-1">4</span>
                                                <small class="col d-sm-none text-center text-muted">Monday</small>
                                                <span class="col-1"></span>
                                            </h5>
                                            <p class="d-sm-none">No events</p>
                                        </div>
                                        <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate d-none d-sm-inline-block  text-muted">
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
                                        <div class="day col-sm p-2 border border-left-0 border-top-0 text-truncate d-none d-sm-inline-block  text-muted">
                                            <h5 class="row align-items-center">
                                                <span class="date col-1">9</span>
                                                <small class="col d-sm-none text-center text-muted">Saturday</small>
                                                <span class="col-1"></span>
                                            </h5>
                                            <p class="d-sm-none">No events</p>
                                        </div>
                                    </div>
                                </div>-->
                                <%--<div class="container-fluid cal pb-3">
                                    <asp:Calendar id="apptCal" runat="server"></asp:Calendar>
                                </div>--%>
                                <div>
                                    <table style="width: 95%; border:none;">
                                        <tr>
                                            <td style="border-bottom: none;">
                                                <h5>Tenant</h5>
                                                <asp:Literal ID="apptName" runat="server"></asp:Literal></td>
                                            <td style="border-bottom: none;">
                                                <h5>Time</h5>
                                                <asp:Literal ID="apptDate" runat="server"></asp:Literal></td>
                                        </tr>

                                    </table>

                                </div>
                                <!--BUTTON-->
                                <button class="nav-item btn btn-block createAppointment" type="button" data-toggle="modal" data-target="#createAppointment">
                                    <a class="btn btn-md btn-info " href="#">Create Appointment</a>
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
                                                    <asp:SqlDataSource ID="tenantDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:roommagnetdbConnectionString %>" SelectCommand="SELECT AccountID, (FirstName + ' ' + LastName) AS NAME FROM Account WHERE AccountID IN (SELECT TenantID FROM FavoritedTenants WHERE HostID = @AccountId ) ORDER BY (FirstName + ' ' + LastName)">
                                                        <SelectParameters>
                                                            <asp:SessionParameter Name="AccountId" SessionField="AccountId" />
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>
                                                    <asp:Label ID="lblRError" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                </div>

                                                <div class="form-group">
                                                    <%--<input class="form-control" id="date" name="date" placeholder="MM/DD/YYY" type="text">--%>
                                                    <asp:TextBox type="date" ID="txtDate" runat="server" class="form-control form-control-lg" placeholder="Date (MM/DD/YYYY)" MaxLength="10"></asp:TextBox>
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
            </div>
        </section>
    </div>
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

    <script>
        function MyFunction() {
            alert("Success!")
        }
    </script>
</asp:Content>

