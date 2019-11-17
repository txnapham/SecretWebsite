﻿<%@ Page Title="" Language="C#" MasterPageFile="~/TenantPage.master" AutoEventWireup="true" CodeFile="TenantEditProfile.aspx.cs" Inherits="TenantEditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>RoomMagnet | Edit Profile</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid px-5">

        <!--BREADCRUMBS-->
        <section>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="TenantDashboard.aspx" class="breadLink">Dashboard</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Edit Profile</li>
                </ol>
            </nav>
        </section>
        <!--END OF BREADCRUMBS-->

        <!--<div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12 text-center">
                <img src="images/rebeccajames.png" alt="..." class="rounded-circle img-fluid" width="20%" height="auto">
                </div>  
            </div>-->

        <section class="mx-auto">
            <div class="row float-left">
                <div class="sm-form md-form lg-form ">
                    <div class="file-field">
                        <div class="mb-4">
                            <img src="images/rebeccajames.png" class="rounded-circle img-fluid" alt="...">
                        </div>
                        <div class="d-flex ">
                            <div class="btn btn-rounded float-left">
                                <span>Add photo</span>
                                <input type="file">
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row ">
                <div class="col-sm-12 col-md-12 col-lg-12">

                    <div class="form-group">
                        <asp:TextBox ID="txtFN" runat="server" class="form-control form-control-lg" aria-describedby="FirstName" placeholder="First Name" MaxLength="50"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtMN" runat="server" class="form-control form-control-lg" aria-describedby="MiddleName" placeholder="Middle Name" MaxLength="50"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtLN" runat="server" class="form-control form-control-lg" aria-describedby="LastName" placeholder="Last Name" MaxLength="50"></asp:TextBox>
                    </div>

                    <div class=" form-group">
                        <asp:TextBox ID="txtBday" runat="server" class="form-control form-control-lg" placeholder="Birthdate (MM-DD-YYYY)" MaxLength="10"></asp:TextBox>
                    </div>

<div class="form-group">
                        <asp:TextBox ID="txtHouseNum" runat="server" class="form-control form-control-lg" placeholder="House Number" MaxLength="10"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtStreet" runat="server" class="form-control form-control-lg" placeholder="Street" MaxLength="30"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtCity" runat="server" class="form-control form-control-lg" placeholder="City" MaxLength="30"></asp:TextBox>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <asp:DropDownList ID="ddState" runat="server" class="form-control  form-control-lg">
                                <asp:ListItem Value="">State</asp:ListItem>
                                <asp:ListItem>AL</asp:ListItem>
                                <asp:ListItem>AK</asp:ListItem>
                                <asp:ListItem>AZ</asp:ListItem>
                                <asp:ListItem>AR</asp:ListItem>
                                <asp:ListItem>CA</asp:ListItem>
                                <asp:ListItem>CO</asp:ListItem>
                                <asp:ListItem>CT</asp:ListItem>
                                <asp:ListItem>DE</asp:ListItem>
                                <asp:ListItem>FL</asp:ListItem>
                                <asp:ListItem>GA</asp:ListItem>
                                <asp:ListItem>HI</asp:ListItem>
                                <asp:ListItem>ID</asp:ListItem>
                                <asp:ListItem>IL</asp:ListItem>
                                <asp:ListItem>IN</asp:ListItem>
                                <asp:ListItem>IA</asp:ListItem>
                                <asp:ListItem>KS</asp:ListItem>
                                <asp:ListItem>KY</asp:ListItem>
                                <asp:ListItem>LA</asp:ListItem>
                                <asp:ListItem>ME</asp:ListItem>
                                <asp:ListItem>MD</asp:ListItem>
                                <asp:ListItem>MA</asp:ListItem>
                                <asp:ListItem>MI</asp:ListItem>
                                <asp:ListItem>MN</asp:ListItem>
                                <asp:ListItem>MS</asp:ListItem>
                                <asp:ListItem>MO</asp:ListItem>
                                <asp:ListItem>MT</asp:ListItem>
                                <asp:ListItem>NE</asp:ListItem>
                                <asp:ListItem>NV</asp:ListItem>
                                <asp:ListItem>NH</asp:ListItem>
                                <asp:ListItem>NJ</asp:ListItem>
                                <asp:ListItem>NM</asp:ListItem>
                                <asp:ListItem>NY</asp:ListItem>
                                <asp:ListItem>NC</asp:ListItem>
                                <asp:ListItem>ND</asp:ListItem>
                                <asp:ListItem>OH</asp:ListItem>
                                <asp:ListItem>OK</asp:ListItem>
                                <asp:ListItem>OR</asp:ListItem>
                                <asp:ListItem>PA</asp:ListItem>
                                <asp:ListItem>RI</asp:ListItem>
                                <asp:ListItem>SC</asp:ListItem>
                                <asp:ListItem>SD</asp:ListItem>
                                <asp:ListItem>TN</asp:ListItem>
                                <asp:ListItem>TX</asp:ListItem>
                                <asp:ListItem>UT</asp:ListItem>
                                <asp:ListItem>VT</asp:ListItem>
                                <asp:ListItem>VA</asp:ListItem>
                                <asp:ListItem>WA</asp:ListItem>
                                <asp:ListItem>WV</asp:ListItem>
                                <asp:ListItem>WI</asp:ListItem>
                                <asp:ListItem>WY</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-2">
                            <asp:TextBox ID="txtZip" runat="server" class="form-control form-control-lg" placeholder="Zip" MaxLength="9"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:DropDownList ID="ddCountry" runat="server" class="form-control  form-control-lg">
                                <asp:ListItem Value="US">US</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <small id="addressDisclosure" class="form-text text-muted">*We will never share your address until you begin the lease process.</small>
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtPhone" runat="server" class="form-control form-control-lg" placeholder="Phone Number (XXX-XXX-XXXX)" MaxLength="20"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtEmail" runat="server" class="form-control form-control-lg" aria-describedby="emailHelp" placeholder="Email" MaxLength="50"></asp:TextBox>
                        <small id="emailHelp" class="form-text text-muted">*We will never share your email with anyone else.</small>
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtPassword" runat="server" class="form-control form-control-lg" placeholder="Password" TextMode="Password" MaxLength="256"></asp:TextBox>
                    </div>

                </div>
            </div>
        </section>


        <section>
            <div class="row pt-3">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <h5>Please select your preferred language:</h5>
                </div>
            </div>
        </section>


        <section>
            <div class="row px-5 py-3">
                <!--LANGUAGE FILTER START HERE-->

                <div class="col-sm-4 col-md-4 col-lg-4">

                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <div class="switchwrapper">
                            <label class="switch">
                                <asp:CheckBox ID="cbEnglish" runat="server" />
                                <span class="slider round"></span>
                            </label>
                            <div>English</div>
                        </div>
                    </div>

                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <div class="switchwrapper">
                            <label class="switch">
                                <asp:CheckBox ID="cbSpanish" runat="server" />
                                <span class="slider round"></span>
                            </label>
                            <div>Spanish</div>
                        </div>
                    </div>

                </div>


                <div class="col-sm-4 col-md-4 col-lg-4">

                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <div class="switchwrapper">
                            <label class="switch">
                                <asp:CheckBox ID="cbMandarin" runat="server" />
                                <span class="slider round"></span>
                            </label>
                            <div>Mandarin</div>
                        </div>
                    </div>

                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <div class="switchwrapper">
                            <label class="switch">
                                <asp:CheckBox ID="cbJapanese" runat="server" />
                                <span class="slider round"></span>
                            </label>
                            <div>Japanese</div>
                        </div>
                    </div>

                </div>

                <div class="col-sm-4 col-md-4 col-lg-4">

                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <div class="switchwrapper">
                            <label class="switch">
                                <asp:CheckBox ID="cbGerman" runat="server" />
                                <span class="slider round"></span>
                            </label>
                            <div>German</div>
                        </div>
                    </div>

                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <div class="switchwrapper">
                            <label class="switch">
                                <asp:CheckBox ID="cbFrench" runat="server" />
                                <span class="slider round"></span>
                            </label>
                            <div>French</div>
                        </div>
                    </div>

                </div>




                <!--END OF LANGUAGE FILTER-->
            </div>
        </section>


        <section>
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <h5>Please select statements that apply to you:</h5>
                </div>
            </div>
        </section>


        <section>
            <div class="row px-5 py-3">
                <!--PERSONALITY FILTER START HERE-->


                <div class="col-sm-4 col-md-4 col-lg-4">

                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <div class="switchwrapper">
                            <label class="switch">
                                <asp:CheckBox ID="cbEarlyRiser" runat="server" />
                                <span class="slider round"></span>
                            </label>
                            <div>Early Riser</div>
                        </div>
                    </div>

                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <div class="switchwrapper">
                            <label class="switch">
                                <asp:CheckBox ID="cbNightOwl" runat="server" />
                                <span class="slider round"></span>
                            </label>
                            <div>Night Owl</div>
                        </div>
                    </div>

                </div>


                <div class="col-sm-4 col-md-4 col-lg-4">

                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <div class="switchwrapper">
                            <label class="switch">
                                <asp:CheckBox ID="cbIntrovert" runat="server" />
                                <span class="slider round"></span>
                            </label>
                            <div>Introvert</div>
                        </div>
                    </div>

                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <div class="switchwrapper">
                            <label class="switch">
                                <asp:CheckBox ID="cbExtrovert" runat="server" />
                                <span class="slider round"></span>
                            </label>
                            <div>Extrovert</div>
                        </div>
                    </div>

                </div>

                <div class="col-sm-4 col-md-4 col-lg-4">

                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <div class="switchwrapper">
                            <label class="switch">
                                <asp:CheckBox ID="fbFamily" runat="server" />
                                <span class="slider round"></span>
                            </label>
                            <div>Family-Oriented</div>
                        </div>
                    </div>

                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <div class="switchwrapper">
                            <label class="switch">
                                <asp:CheckBox ID="cbReligious" runat="server" />
                                <span class="slider round"></span>
                            </label>
                            <div>Religious</div>
                        </div>
                    </div>

                </div>

                <div class="col-sm-4 col-md-4 col-lg-4">

                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <div class="switchwrapper">
                            <label class="switch">
                                <asp:CheckBox ID="cbTechSavy" runat="server" />
                                <span class="slider round"></span>
                            </label>
                            <div>Tech-Savvy</div>
                        </div>
                    </div>

                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <div class="switchwrapper">
                            <label class="switch">
                                <asp:CheckBox ID="cbSportsFan" runat="server" />
                                <span class="slider round"></span>
                            </label>
                            <div>Sports Fan</div>
                        </div>
                    </div>

                </div>

                <div class="col-sm-4 col-md-4 col-lg-4">

                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <div class="switchwrapper">
                            <label class="switch">
                                <asp:CheckBox ID="cbAdventurous" runat="server" />
                                <span class="slider round"></span>
                            </label>
                            <div>Adventurous</div>
                        </div>
                    </div>

                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <div class="switchwrapper">
                            <label class="switch">
                                <asp:CheckBox ID="cbMusicAf" runat="server" />
                                <span class="slider round"></span>
                            </label>
                            <div>Music Aficionado</div>
                        </div>
                    </div>

                </div>

                <div class="col-sm-3 col-md-3 col-lg-3">

                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <div class="switchwrapper">
                            <label class="switch">
                                <asp:CheckBox ID="cbNonSmoker" runat="server" />
                                <span class="slider round"></span>
                            </label>
                            <div>Non-Smoker</div>
                        </div>
                    </div>

                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <div class="switchwrapper">
                            <label class="switch">
                                <asp:CheckBox ID="cbHomebody" runat="server" />
                                <span class="slider round"></span>
                            </label>
                            <div>Homebody</div>
                        </div>
                    </div>

                </div>



                <!--END OF PERSONALITY FILTER-->
            </div>
        </section>






    </div>

    <button type="button" class="btn btn-info btn-lg btn-block">Save</button>
</asp:Content>
