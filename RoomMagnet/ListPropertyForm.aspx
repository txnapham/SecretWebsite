<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/HostPage.master" AutoEventWireup="true" CodeFile="ListPropertyForm.aspx.cs" Inherits="ListPropertyForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>RoomMagnet | List Property Form</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--USER DASH-NAV-->
    <div class="container-fluid userDash mb-2 pb-3">
        <div class="navbar navbar-light">
            <p>
                <asp:Literal ID="HostCard" runat="server" Mode="Transform"></asp:Literal>
            </p>
        </div>

    </div>
    <!--END OF USER DASH-NAV-->



    <div class="container-fluid px-5">

        <!--BREADCRUMBS-->
        <section>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="HostDashboard.aspx" class="breadLink">Dashboard</a></li>
<%--                    <li class="breadcrumb-item"><a href="ListedProperties.aspx" class="breadLink">Rooms</a></li>--%>
                    <li class="breadcrumb-item active" aria-current="page">List Room</li>
                </ol>
            </nav>
        </section>
        <!--END OF BREADCRUMBS-->

        <!--BODY CONTENT-->
        <div class="container-fluid px-5  propListingPage">
            <section>

                <div class="row">
                    <div class="col-md-12">
                        <h3>List Room</h3>
                    </div>
                </div>
            </section>



            <section class="pt-3">


                <div class="form-group">
                    <asp:RegularExpressionValidator ID="houseNumValidatorNumbers" Display="Dynamic" runat="server" ErrorMessage="Please enter a valid house number" Text="*Please enter a valid house number" ControlToValidate="txtHouseNum" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="houseNumReqField" Display="Dynamic" runat="server" ErrorMessage="Please enter a house number." ControlToValidate="txtHouseNum" Text="*Please enter a house number"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtHouseNum" runat="server" class="form-control form-control-lg" placeholder="House Number"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:RequiredFieldValidator ID="streetReqFieldValidator" Display="Dynamic" runat="server" ErrorMessage="Please enter a street." ControlToValidate="txtStreet" Text="*Please enter a street"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="streetLetters" Display="Dynamic" runat="server" ErrorMessage="Please enter a valid street name" Text="*Please enter a valid street name" ControlToValidate="txtStreet" ValidationExpression="^[a-zA-Z_ ]+$"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="txtStreet" runat="server" class="form-control form-control-lg" placeholder="Street" MaxLength="30"></asp:TextBox>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-7">
                        <asp:RequiredFieldValidator ID="cityReqFieldValidator" Display="Dynamic" runat="server" ErrorMessage="Please enter a city." ControlToValidate="txtCity" Text="*Please enter a city"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="cityLetters" Display="Dynamic" runat="server" ErrorMessage="Please enter a valid city name" Text="*Please enter a valid city name" ControlToValidate="txtCity" ValidationExpression="^[a-zA-Z_ ]+$"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtCity" runat="server" class="form-control form-control-lg" placeholder="City"></asp:TextBox>
                    </div>

                    <asp:RequiredFieldValidator ID="stateReqFieldValidator" Display="Dynamic" runat="server" ErrorMessage="Please select a state." ControlToValidate="ddState" Text="*Please select a state"></asp:RequiredFieldValidator>
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
                        <asp:RequiredFieldValidator ID="zipReqFieldValidator" Display="Dynamic" runat="server" ErrorMessage="Please enter a zip code." ControlToValidate="txtZip" Text="*Please enter a zip code"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="zipNumValidator" Display="Dynamic" runat="server" ErrorMessage="Please enter a valid zip code" Text="*Please enter a valid zip code" ControlToValidate="txtZip" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtZip" runat="server" class="form-control form-control-lg" placeholder="Zip"></asp:TextBox>
                    </div>
                </div>


                <div class="form-group">
                    <asp:RequiredFieldValidator ID="RequiredFieldCountry" Display="Dynamic" runat="server" ErrorMessage="Please enter a country." ControlToValidate="txtCountry" Text="*Please enter a country"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtCountry" runat="server" class="form-control form-control-lg" placeholder="Country" MaxLength="2"></asp:TextBox>
                </div>

                <div class="form-group">
                    <small id="addressDisclosure" class="form-text text-muted">*We will never share your address until you begin the lease process.</small>
                </div>


            </section>


            <%--            <section>
                <div class="row pt-3">
                    <div class="col-md-12">
                        <h5>Please provide a brief description of your room:</h5>
                    </div>
                </div>
            </section>



            <section>
                 
                    <div class="form-group descripmessagebox">
                        <textarea class="form-control " id="descriptionMessagebox" runat="server"> </textarea>
                    </div>

                 
            </section>--%>

            <div>
                <button type="button" class="btn btn-info btn-block" data-toggle="modal" data-dismiss="modal" data-target="#addRoom">
                    Add Rooms
                </button>
            </div>

            <!--HOST OR TENANT MOD-->
            <div class="modal justify-content-center" id="addRoom">
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
                            <asp:TextBox ID="txtPrice" runat="server" class="form-control form-control-lg" placeholder="Price"></asp:TextBox>
                            <br />
                            <br />
                            <asp:TextBox ID="txtDescription" runat="server" class="form-control form-control-lg" placeholder="Description" Height="100px"></asp:TextBox>

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
                                                    <asp:CheckBox ID="cbConnBath" runat="server" />
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
                                                    <asp:CheckBox ID="cbDryer" runat="server" />
                                                    <span class="slider round"></span>
                                                </label>
                                                <div>Washer / Dryer</div>
                                            </div>
                                        </div>


<asp:Button ID="Button1" runat="server" class="btn btn-info btn-block" Text="List Room" CausesValidation="true" OnClick="btnListProperty_Click" />

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
                                                    <asp:CheckBox ID="cbHeating" runat="server" />
                                                    <span class="slider round"></span>
                                                </label>
                                                <div>Heating / Air Conditioning</div>
                                            </div>
                                        </div>

                                    </div>
                                </div>

                            </section>
                            <!--end of amenities-->

                        </div>
                    </div>
                </div>
            </div>




            <section>
                <div class="row pt-3">
                    <div class="col-md-12">
                        <h5>Please select your property type:</h5>
                    </div>
                </div>
            </section>



            <!--property type start here-->
            <section>
                <div class="row px-5 py-3">
                    <div class="col-md-6">
                        <div class="col-md-12">
                            <div class="switchwrapper">
                                <asp:RadioButtonList ID="RadioButtonList" runat="server" RepeatLayout="Table" RepeatColumns="2" Width="100%">
                                    <asp:ListItem>Apartment</asp:ListItem>
                                    <asp:ListItem>Loft</asp:ListItem>
                                    <asp:ListItem>House</asp:ListItem>
                                    <asp:ListItem>Townhouse</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
<%--                            <div class="switchwrapper">
                                <label class="switch">
                                    <asp:CheckBox ID="cbApartment" runat="server" />
                                    <span class="slider round"></span>
                                </label>
                                <div>Apartment</div>
                            </div>
                        </div>

                        <div class="col-md-12">
                            <div class="switchwrapper">
                                <label class="switch">
                                    <asp:CheckBox ID="cbLoft" runat="server" />
                                    <span class="slider round"></span>
                                </label>
                                <div>Loft</div>
                            </div>
                        </div>--%>
                    </div>


<%--                    <div class="col-md-6">

                        <div class="col-md-12">
                            <div class="switchwrapper">
                                <label class="switch">
                                    <asp:CheckBox ID="cbHouse" runat="server" />
                                    <span class="slider round"></span>
                                </label>
                                <div>House</div>
                            </div>
                        </div>

                        <div class="col-md-12">
                            <div class="switchwrapper">
                                <label class="switch">
                                    <asp:CheckBox ID="cbTownhouse" runat="server" />
                                    <span class="slider round"></span>
                                </label>
                                <div>Townhouse</div>
                            </div>
                        </div>
                    </div>--%>
                </div>
            </section>
            <!--end of property type-->

            <%--<section>
                <div class="row pt-3">
                    <div class="col-md-12">
                        <h5>Please select amenities that apply to you:</h5>
                    </div>
                </div>
            </section>--%>

            <%--<!--Amenities Start here-->
            <section>
                <div class="row px-5 py-3">
                    <div class="col-md-6">

                        <div class="col-md-12">
                            <div class="switchwrapper">
                                <label class="switch">
                                    <asp:CheckBox ID="cbConnBath" runat="server" />
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
                                    <asp:CheckBox ID="cbDryer" runat="server" />
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
                                    <asp:CheckBox ID="cbHeating" runat="server" />
                                    <span class="slider round"></span>
                                </label>
                                <div>Heating / Air Conditioning</div>
                            </div>
                        </div>

                    </div>
                </div>

            </section>
            <!--end of amenities-->--%>

            <section>
                <div class="row">
                    <div class="col-md-12">
                        <h5>Please select facilities that apply to you:</h5>
                    </div>
                </div>
            </section>

            <!--facilites start here-->
            <section>
                <div class="row px-5 py-3">
                    <div class="col-md-6">

                        <div class="col-md-12">
                            <div class="switchwrapper">
                                <label class="switch">
                                    <asp:CheckBox ID="cbStPark" runat="server" />
                                    <span class="slider round"></span>
                                </label>
                                <div>Street Parking</div>
                            </div>
                        </div>

                        <div class="col-md-12">
                            <div class="switchwrapper">
                                <label class="switch">
                                    <asp:CheckBox ID="cbPool" runat="server" />
                                    <span class="slider round"></span>
                                </label>
                                <div>Pool</div>
                            </div>
                        </div>

                        <div class="col-md-12">
                            <div class="switchwrapper">
                                <label class="switch">
                                    <asp:CheckBox ID="cbPorch" runat="server" />
                                    <span class="slider round"></span>
                                </label>
                                <div>Porch / Deck</div>
                            </div>
                        </div>


                    </div>


                    <div class="col-md-6">

                        <div class="col-md-12">
                            <div class="switchwrapper">
                                <label class="switch">
                                    <asp:CheckBox ID="cbGarPark" runat="server" />
                                    <span class="slider round"></span>
                                </label>
                                <div>Garage Parking</div>
                            </div>
                        </div>

                        <div class="col-md-12">
                            <div class="switchwrapper">
                                <label class="switch">
                                    <asp:CheckBox ID="cbBackyard" runat="server" />
                                    <span class="slider round"></span>
                                </label>
                                <div>Backyard</div>
                            </div>
                        </div>

                    </div>
                </div>
            </section>
            <!--end of facilites-->


            <section>
                <div class="row pt-3">
                    <div class="col-md-12">
                        <h5>Please select any house rules that apply to you:</h5>
                    </div>
                </div>
            </section>



            <!--property type start here-->
            <section>
                <div class="row px-5 py-3">
                    <div class="col-md-6">

                        <div class="col-md-12">
                            <div class="switchwrapper">
                                <label class="switch">
                                    <asp:CheckBox ID="cbPets" runat="server" />
                                    <span class="slider round"></span>
                                </label>
                                <div>Pets Allowed</div>
                            </div>
                        </div>

                        <div class="col-md-12">
                            <div class="switchwrapper">
                                <label class="switch">
                                    <asp:CheckBox ID="cbSmoke" runat="server" />
                                    <span class="slider round"></span>
                                </label>
                                <div>Smoking Allowed</div>
                            </div>
                        </div>
                    </div>


                    <div class="col-md-6">

                        <div class="col-md-12">
                            <div class="switchwrapper">
                                <label class="switch">
                                    <asp:CheckBox ID="cbGuest" runat="server" />
                                    <span class="slider round"></span>
                                </label>
                                <div>Guest Allowed</div>
                            </div>
                        </div>



<%--                        <h6>Don't see one that applies to you? Fill out the form below:</h6>
                        <div class="form-group">
                            <asp:TextBox ID="txtOtherRules" runat="server" class="form-control" aria-describedby="HouseRule" placeholder="Type your house rule here"></asp:TextBox>
                        </div>--%>



                    </div>
                </div>
            </section>
            <!--end of property type-->



            <section>
                <div class="row pt-3">
                    <div class="col-md-12">
                        <h5>HomeShareSmarter</h5>
                    </div>
                </div>
            </section>



            <!--homesharesmarter start here-->
            <section>
                <div class="row px-5 py-3">
                    <div class="col-md-12">

                        <div class="col-md-12">
                            <div class="switchwrapper">
                                <label class="switch">
                                    <asp:CheckBox ID="cbHSS" runat="server" />
                                    <span class="slider round"></span>
                                </label>
                                <div>Allowed</div>
                            </div>
                        </div>

                    </div>

                </div>
            </section>
            <!--end of homesharesmarter-->

            <div class="form-group">
                <h5>Upload room images here:</h5>
                <asp:FileUpload ID="FileUploadControl" runat="server" AllowMultiple="False" />
                <asp:Button runat="server" ID="FilesUpload" Text="Save to Room" AutoPostBack="false" OnClientClick="FileUpload1_Click" />
                <br />
                <br />
                <asp:Label runat="server" ID="StatusLabel" Text="Upload status: " />
            </div>


            <div class="form-group form-check">
                <asp:CustomValidator ID="cbAgreementValidator" runat="server" Display="Dynamic" ErrorMessage="*Please accept the terms and conditions</br>" ClientValidationFunction="validateTerms" ></asp:CustomValidator>
                <asp:CheckBox ID="cbAgreement" runat="server" class="form-check-input" />
                <label class="form-check-label" for="exampleCheck1">Agreement to Terms &amp; Conditions</label>
            </div>



            <asp:Button ID="btnListProperty" runat="server" class="btn btn-info btn-block" Text="List Room" CausesValidation="true" OnClick="btnListProperty_Click" />
        </div>
        
        <script>
        function validateTerms(source, arguments) {
            var $c = $('#<%= cbAgreement.ClientID %>');
            if($c.prop("checked")){
                arguments.IsValid = true;
            } else {
                arguments.IsValid = false;
            }
        }
    </script>
        <!--END OF BODY CONTENT-->
</asp:Content>

