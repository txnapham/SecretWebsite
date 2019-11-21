<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search-Tenant.aspx.cs" Inherits="Search_Tenant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        #map {
            height: 300px;
            width: 100%;
            box-shadow: 0px 5px 5px 0px rgba(0,0,0,0.3);
            -webkit-box-shadow: 0px 5px 5px 0px rgba(0,0,0,0.3);
            -moz-box-shadow: 0px 5px 5px 0px rgba(0,0,0,0.3);
            margin-bottom: 3%;
        }
    </style>

    


    <script>
        var map;
        function initMap() {
            var latitude = 38.4496;
            var longitude = -78.8689;
            map = new google.maps.Map(document.getElementById('map'),
                {
                    center: { lat: latitude, lng: longitude },
                    zoom: 8
                });
        }

        function newLocation(newLat, newLng) {
            map.setCenter({ newLat, newLng })
            return false;
        }
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCNcHEQpOGd14rKFMgFTgbH-fZS2dD1UBw&callback=initMap"
        async defer></script>

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <script>
        function favoriteBtn(propertyID, city, state, priceLow, priceHigh) {
            PageMethods.MiddleMan(propertyID, city, state, priceLow, priceHigh);
        };
    </script>

    <!--BEGINNING OF SEARCH BAR-->
    <div class="container-fluid searchPageBodyContent">
        <section>

        <div align="center" class>
            <div id="map">
            </div>
          </div>
        </section>


        <section>
            <div class="row pb-2">

                <div class="col-md-12">
                    <!--FILTER BUTTON AND FILTER FORM-->
                    <div class="form-row justify-content-center">
                        <button type="button" class="btn btn-info" data-toggle="modal" data-target="#filterOptions">Filter</button>
                        <!--END OF FILTER BUTTON-->

                        <!--filter form starts-->
                                <div class="modal" id="filterOptions">
                                    <div class="modal-dialog modal-lg">
                                        <div class="modal-content">

                                            <div class="modal-body">

                                                <button type="button" class="close" data-dismiss="modal">&times;</button>

                                                <!--start of personality-->
                                                <h6>Personality/Lifestyle</h6>
                                                <div class="form-group row">

                                                    <div class="col-sm-6">

                                                       
                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbExtrovert" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterSportsFan">Extrovert</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbIntrovert" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterPetFriendly">Introvert</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbNonSmoker" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterSportsFan">Non-Smoker</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbEarlyRiser" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterPetFriendly">Early Riser</label>
                                                            </div>
                                                        </div>

                                                        
                                                    </div>

                                                    <div class="col-sm-6">

                                                        

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbNightOwl" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterSportsFan">Night Owl</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbTechSavvy" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterSportsFan">Tech-Savvy</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbFamily" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterSportsFan">Family-Oriented</label>
                                                            </div>
                                                        </div>
                                                        

                                                    </div>
                                                </div>
                                                <!--end of personality-->

                                                <!--start of amentities-->
                                                <h6>Amenities</h6>
                                                <div class="form-group row">

                                                    <div class="col-sm-6">

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbKitchen" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterSportsFan">Kitchen</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbHVAC" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterSportsFan">Heating / Air Conditioning</label>
                                                            </div>
                                                        </div>

                                                         <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbWifi" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterSportsFan">Wifi</label>
                                                            </div>
                                                        </div>

                                                        

                                                        

                                                        

                                                    </div>

                                                    <div class="col-sm-6">

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbPrivateBath" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterPetFriendly">Private Bathroom</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbWalkInCloset" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterSportsFan">Walk-In Closet</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbWashDry" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterSportsFan">Washer / Dryer</label>
                                                            </div>
                                                        </div>


                                                    </div>
                                                </div>
                                                <!--end of amenities-->

                                       <!--start of homesharesmarter-->
                                      <h6>HomeshareSmarter<a href="#" data-toggle="tooltip" data-placement="right" title="Perform basic chores to receive a discount on housing">®</a>Living</h6>

                                                <div class="form-group row">

                                                    <div class="col-sm-12">

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbHomeShareYES" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterhomeshareYES">Yes</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbHomeShareNO" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterhomeshareNO">No</label>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                                <!--end of homesharesmarter-->



                                                <!--start of facilites-->
                                                <h6>Facilities</h6>
                                                <div class="form-group row">

                                                    <div class="col-sm-6">

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbStreetPark" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterPetFriendly">Street Parking</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbGarPark" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterPetFriendly">Garage Parking</label>
                                                            </div>
                                                        </div>

                                                         <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbBackyard" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterSportsFan">Backyard</label>
                                                            </div>
                                                        </div>

   
                                                    </div>

                                                    <div class="col-sm-6">

                                                        
                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbPorch" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterSportsFan">Porch / Deck</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbPool" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterSportsFan">Pool</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--end of facilities-->


                                                





                                                <!--start of languages-->
                                                <h6>Languages</h6>
                                                <div class="form-group row">

                                                    <div class="col-sm-6">

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbEnglish" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterPetFriendly">English</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbSpanish" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterSportsFan">Spanish</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbMandarin" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterSportsFan">Mandarin</label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-6">

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbJapanese" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterPetFriendly">Japanese </label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbGerman" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterSportsFan">German</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="cbFrench" runat="server" class="form-check-input" />
                                                                <label class="form-check-label" for="filterSportsFan">French</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--end of languages-->

         



                                                <button type="button" class="btn btn-info btn-block" data-dismiss="modal"> Apply Filters</button>


                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!--END OF FILTER FORM-->

                        <!--SEARCH BAR-->
                        <div class="col-md-6 searchBar">
                            <asp:TextBox ID="txtSearch" runat="server" class="form-control form-control-lg" placeholder="Search" ClientIDMode="Static" ></asp:TextBox>
                        </div>
                        <!--END OF SEARCH BAR-->


                        <!--BEGINNING OF SEARCH BUTTON-->
                        <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Text="Search" class="btn btn-info"/>

                        <!--END OF SERACH BUTTON-->
                    </div>
                </div>
            </div>
        </section>
        <!--END OF FILTER, SEARCH BAR, AND SEARCH BUTTON -->

        <!--BREADCRUMBS-->
        <section>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="Home.aspx" class="breadLink">Home</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Search</li>
                </ol>
            </nav>
        </section>
        <!--END OF BREADCRUMBS-->

        <!-- number of properties listed on search-->
        <section>
            <div class="row">
                <div class="col-md-12">
                    <h3></h3>
                </div>
            </div>
        </section>

        <!--BEGINNING OF HOUSE LISTINGS-->
        <section>
            <div class="row px-3 py-3">
                <asp:Literal ID="Card1" runat="server" Mode="Transform"></asp:Literal>
            </div>
        </section>

        <!--END OF HOUSE LISTINGS-->


        <!--PAGINATION-->
        <section>
            <nav aria-label="Search results pages">
                <ul class="pagination justify-content-center">
                    <li class="page-item"><a class="page-link" href="#" tabindex="-1" aria-disabled="true">Previous</a></li>
                    <li class="page-item active"><a class="page-link" href="#">1<span class="sr-only"></span></a></li>
                    <li class="page-item"><a class="page-link" href="#">2</a></li>
                    <li class="page-item"><a class="page-link" href="#">3</a></li>
                    <li class="page-item"><a class="page-link" href="#">Next</a></li>
                </ul>
            </nav>
        </section>
        <!--END OF PAGINATION-->

    </div>

    <script src="awesomplete.js"></script>
    <script type="text/javascript">

        var ajax = new XMLHttpRequest();
        ajax.open("GET", "csvjson.json", true);
        ajax.onload = function () {
            var list = JSON.parse(ajax.responseText).map(function (i) { return i.CityState; });
            new Awesomplete(document.querySelector("#<%=txtSearch.ClientID %>"), {
                list: list,
                minChars: 1
            });
            awesomplete.list = list;
            $(input).change(function () {
                //check whether the entered value is in the list
                if (jQuery.inArray($(this).val(), list == -1)) {
                    $("#txtSearch").html("\"" + $(this).val() + "\" not in the list")
                    $(this).val("");
                }
            });
        };
        ajax.send();
    </script>
</asp:Content>

