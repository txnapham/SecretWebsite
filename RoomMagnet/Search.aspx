﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>RoomMagnet | Search</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--BEGINNING OF SEARCH BAR-->
    <div class="container-fluid searchPageBodyContent">

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

                                        <!--start of amentities-->
                                        <h6>Amenities</h6>
                                        <div class="form-group row">

                                            <div class="col-sm-6">

                                                <div class="col-sm-12">
                                                    <div class="form-check">
                                                        <asp:CheckBox ID="cbConBath" runat="server" class="form-check-input" />
                                                        <label class="form-check-label" for="filterPetFriendly">Connected Bathroom</label>
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
                                                        <asp:CheckBox ID="cbDryer" runat="server" class="form-check-input" />
                                                        <label class="form-check-label" for="filterSportsFan">Dryer</label>
                                                    </div>
                                                </div>

                                                <div class="col-sm-12">
                                                    <div class="form-check">
                                                        <asp:CheckBox ID="cbCeilFan" runat="server" class="form-check-input" />
                                                        <label class="form-check-label" for="filterSportsFan">Ceiling Fan</label>
                                                    </div>
                                                </div>

                                                <div class="col-sm-12">
                                                    <div class="form-check">
                                                        <asp:CheckBox ID="cbKitchen" runat="server" class="form-check-input" />
                                                        <label class="form-check-label" for="filterSportsFan">Kitchen</label>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="col-sm-6">

                                                <div class="col-sm-12">
                                                    <div class="form-check">
                                                        <asp:CheckBox ID="cbSepEntr" runat="server" class="form-check-input" />
                                                        <label class="form-check-label" for="filterPetFriendly">Separate Entrance</label>
                                                    </div>
                                                </div>

                                                <div class="col-sm-12">
                                                    <div class="form-check">
                                                        <asp:CheckBox ID="cbAirCon" runat="server" class="form-check-input" />
                                                        <label class="form-check-label" for="filterSportsFan">Air Conditioning</label>
                                                    </div>
                                                </div>

                                                <div class="col-sm-12">
                                                    <div class="form-check">
                                                        <asp:CheckBox ID="cbWasher" runat="server" class="form-check-input" />
                                                        <label class="form-check-label" for="filterSportsFan">Washer</label>
                                                    </div>
                                                </div>

                                                <div class="col-sm-12">
                                                    <div class="form-check">
                                                        <asp:CheckBox ID="cbWifi" runat="server" class="form-check-input" />
                                                        <label class="form-check-label" for="filterSportsFan">Wifi</label>
                                                    </div>
                                                </div>

                                                <div class="col-sm-12">
                                                    <div class="form-check">
                                                        <asp:CheckBox ID="cbHeating" runat="server" class="form-check-input" />
                                                        <label class="form-check-label" for="filterSportsFan">Heating</label>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                        <!--end of amenities-->


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
                                                        <asp:CheckBox ID="cbPool" runat="server" class="form-check-input" />
                                                        <label class="form-check-label" for="filterSportsFan">Pool</label>
                                                    </div>
                                                </div>

                                                <div class="col-sm-12">
                                                    <div class="form-check">
                                                        <asp:CheckBox ID="cbDeck" runat="server" class="form-check-input" />
                                                        <label class="form-check-label" for="filterSportsFan">Deck</label>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-sm-6">

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

                                                <div class="col-sm-12">
                                                    <div class="form-check">
                                                        <asp:CheckBox ID="cbPorch" runat="server" class="form-check-input" />
                                                        <label class="form-check-label" for="filterSportsFan">Porch</label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!--end of facilities-->


                                        <!--start of personality-->
                                        <h6>Personality/Lifestyle</h6>
                                        <div class="form-group row">

                                            <div class="col-sm-6">

                                                <div class="col-sm-12">
                                                    <div class="form-check">
                                                        <asp:CheckBox ID="cbIntrovert" runat="server" class="form-check-input" />
                                                        <label class="form-check-label" for="filterPetFriendly">Introvert</label>
                                                    </div>
                                                </div>

                                                <div class="col-sm-12">
                                                    <div class="form-check">
                                                        <asp:CheckBox ID="cbExtrovert" runat="server" class="form-check-input" />
                                                        <label class="form-check-label" for="filterSportsFan">Extrovert</label>
                                                    </div>
                                                </div>

                                                <div class="col-sm-12">
                                                    <div class="form-check">
                                                        <asp:CheckBox ID="cbFamily" runat="server" class="form-check-input" />
                                                        <label class="form-check-label" for="filterSportsFan">Family-Oriented</label>
                                                    </div>
                                                </div>

                                                <div class="col-sm-12">
                                                    <div class="form-check">
                                                        <asp:CheckBox ID="cbTechSavy" runat="server" class="form-check-input" />
                                                        <label class="form-check-label" for="filterSportsFan">Tech-Savvy</label>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-sm-6">

                                                <div class="col-sm-12">
                                                    <div class="form-check">
                                                        <asp:CheckBox ID="cbEarlyRiser" runat="server" class="form-check-input" />
                                                        <label class="form-check-label" for="filterPetFriendly">Early Riser</label>
                                                    </div>
                                                </div>

                                                <div class="col-sm-12">
                                                    <div class="form-check">
                                                        <asp:CheckBox ID="cbNightOwl" runat="server" class="form-check-input" />
                                                        <label class="form-check-label" for="filterSportsFan">Night Owl</label>
                                                    </div>
                                                </div>

                                                <div class="col-sm-12">
                                                    <div class="form-check">
                                                        <asp:CheckBox ID="cbReligious" runat="server" class="form-check-input" />
                                                        <label class="form-check-label" for="filterSportsFan">Religious</label>
                                                    </div>
                                                </div>

                                                <div class="col-sm-12">
                                                    <div class="form-check">
                                                        <asp:CheckBox ID="cbNonSmoker" runat="server" class="form-check-input" />
                                                        <label class="form-check-label" for="filterSportsFan">Non-Smoker</label>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                        <!--end of personality-->





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

                                        <!--start of homesharesmarter-->
                                        <h6>HomeshareSmarter® Living</h6>
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



                                        <button type="button" class="btn btn-info btn-block">
                                            Apply Filters
                                           
                                        </button>


                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--END OF FILTER FORM-->

                        <!--SEARCH BAR-->
                        <div class="col-md-6 searchBar">
                            <asp:TextBox ID="txtSearch" runat="server" class="form-control form-control-lg" placeholder="Search" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <!--END OF SEARCH BAR-->


                        <!--BEGINNING OF SEARCH BUTTON-->
                        <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-info"/>
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



        <!--GOOGLE MAPS GOES HERE-->
        <section>
            <div class="row">
            </div>
        </section>
        <!--END OF GOOGLE MAPS-->


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
                <div class="col-md-3">
                    <div class="card  shadow-sm  mb-4">
                        <img src="images/scott-webb-1ddol8rgUH8-unsplash.jpg" class="card-img-top" alt="image">
                        <a href="PropertyDetails.aspx" class="cardLinks">
                            <div class="card-body">
                                <h5 class="card-title">Card title</h5>
                                <p class="card-text">This is a longer c </p>
                            </div>
                        </a>

                        <!--FAVORITE BUTTON-->
                        <div>
                            <button id="heartbtn" class="btn favoriteHeartButton"><i id="hearti" class="far fa-heart"></i></button>
                        </div>
                        <!--END OF FABORITE BUTTON-->
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card  shadow-sm mb-4">
                        <img src="images/scott-webb-1ddol8rgUH8-unsplash.jpg" class="card-img-top" alt="image">
                        <a href="PropertyDetails.aspx" class="cardLinks">
                            <div class="card-body">
                                <h5 class="card-title">Card title</h5>
                                <p class="card-text">This is a longer c </p>
                            </div>
                        </a>

                        <!--FAVORITE BUTTON-->
                        <div>
                            <button id="heartbtn" class="btn favoriteHeartButton"><i id="hearti" class="far fa-heart"></i></button>
                        </div>
                        <!--END OF FABORITE BUTTON-->
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card  shadow-sm mb-4">
                        <img src="images/scott-webb-1ddol8rgUH8-unsplash.jpg" class="card-img-top" alt="image">
                        <a href="PropertyDetails.aspx" class="cardLinks">
                            <div class="card-body">
                                <h5 class="card-title">Card title</h5>
                                <p class="card-text">This is a longer c </p>
                            </div>
                        </a>

                        <!--FAVORITE BUTTON-->
                        <div>
                            <button id="heartbtn" class="btn favoriteHeartButton"><i id="hearti" class="far fa-heart"></i></button>
                        </div>
                        <!--END OF FABORITE BUTTON-->
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card  shadow-sm mb-4">
                        <img src="images/scott-webb-1ddol8rgUH8-unsplash.jpg" class="card-img-top" alt="image">
                        <a href="PropertyDetails.aspx" class="cardLinks">
                            <div class="card-body">
                                <h5 class="card-title">Card title</h5>
                                <p class="card-text">This is a longer c </p>
                            </div>
                        </a>

                        <!--FAVORITE BUTTON-->
                        <div>
                            <button id="heartbtn" class="btn favoriteHeartButton"><i id="hearti" class="far fa-heart"></i></button>
                        </div>
                        <!--END OF FABORITE BUTTON-->
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card  shadow-sm mb-4">
                        <img src="images/scott-webb-1ddol8rgUH8-unsplash.jpg" class="card-img-top" alt="image">
                        <a href="PropertyDetails.aspx" class="cardLinks">
                            <div class="card-body">
                                <h5 class="card-title">Card title</h5>
                                <p class="card-text">This is a longer c </p>
                            </div>
                        </a>

                        <!--FAVORITE BUTTON-->
                        <div>
                            <button id="heartbtn" class="btn favoriteHeartButton"><i id="hearti" class="far fa-heart"></i></button>
                        </div>
                        <!--END OF FABORITE BUTTON-->
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card shadow-sm  mb-4">
                        <img src="images/scott-webb-1ddol8rgUH8-unsplash.jpg" class="card-img-top" alt="image">
                        <a href="PropertyDetails.aspx" class="cardLinks">
                            <div class="card-body">
                                <h5 class="card-title">Card title</h5>
                                <p class="card-text">This is a longer c </p>
                            </div>
                        </a>

                        <!--FAVORITE BUTTON-->
                        <div>
                            <button id="heartbtn" class="btn favoriteHeartButton"><i id="hearti" class="far fa-heart"></i></button>
                        </div>
                        <!--END OF FABORITE BUTTON-->
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card shadow-sm  mb-4">
                        <img src="images/scott-webb-1ddol8rgUH8-unsplash.jpg" class="card-img-top" alt="image">
                        <a href="PropertyDetails.aspx" class="cardLinks">
                            <div class="card-body">
                                <h5 class="card-title">Card title</h5>
                                <p class="card-text">This is a longer c </p>
                            </div>
                        </a>

                        <!--FAVORITE BUTTON-->
                        <div>
                            <button id="heartbtn" class="btn favoriteHeartButton"><i id="hearti" class="far fa-heart"></i></button>
                        </div>
                        <!--END OF FABORITE BUTTON-->
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card  shadow-sm mb-4">
                        <img src="images/scott-webb-1ddol8rgUH8-unsplash.jpg" class="card-img-top" alt="image">
                        <a href="PropertyDetails.aspx" class="cardLinks">
                            <div class="card-body">
                                <h5 class="card-title">Card title</h5>
                                <p class="card-text">This is a longer c </p>
                            </div>
                        </a>

                        <!--FAVORITE BUTTON-->
                        <div>
                            <button id="heartbtn" class="btn favoriteHeartButton"><i id="hearti" class="far fa-heart"></i></button>
                        </div>
                        <!--END OF FABORITE BUTTON-->
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card  shadow-sm mb-4">
                        <img src="images/scott-webb-1ddol8rgUH8-unsplash.jpg" class="card-img-top" alt="image">
                        <a href="PropertyDetails.aspx" class="cardLinks">
                            <div class="card-body">
                                <h5 class="card-title">Card title</h5>
                                <p class="card-text">This is a longer c </p>
                            </div>
                        </a>

                        <!--FAVORITE BUTTON-->
                        <div>
                            <button id="heartbtn" class="btn favoriteHeartButton"><i id="hearti" class="far fa-heart"></i></button>
                        </div>
                        <!--END OF FABORITE BUTTON-->
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card shadow-sm  mb-4">
                        <img src="images/scott-webb-1ddol8rgUH8-unsplash.jpg" class="card-img-top" alt="image">
                        <a href="PropertyDetails.aspx" class="cardLinks">
                            <div class="card-body">
                                <h5 class="card-title">Card title</h5>
                                <p class="card-text">This is a longer c </p>
                            </div>
                        </a>

                        <!--FAVORITE BUTTON-->
                        <div>
                            <button id="heartbtn" class="btn favoriteHeartButton"><i id="hearti" class="far fa-heart"></i></button>
                        </div>
                        <!--END OF FABORITE BUTTON-->
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card shadow-sm  mb-4">
                        <img src="images/scott-webb-1ddol8rgUH8-unsplash.jpg" class="card-img-top" alt="image">
                        <a href="PropertyDetails.aspx" class="cardLinks">
                            <div class="card-body">
                                <h5 class="card-title">Card title</h5>
                                <p class="card-text">This is a longer c </p>
                            </div>
                        </a>

                        <!--FAVORITE BUTTON-->
                        <div>
                            <button id="heartbtn" class="btn favoriteHeartButton"><i id="hearti" class="far fa-heart"></i></button>
                        </div>
                        <!--END OF FABORITE BUTTON-->
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card  shadow-sm mb-4">
                        <img src="images/scott-webb-1ddol8rgUH8-unsplash.jpg" class="card-img-top" alt="image">
                        <a href="PropertyDetails.aspx" class="cardLinks">
                            <div class="card-body">
                                <h5 class="card-title">Card title</h5>
                                <p class="card-text">This is a longer c </p>
                            </div>
                        </a>

                        <!--FAVORITE BUTTON-->
                        <div>
                            <button id="heartbtn" class="btn favoriteHeartButton"><i id="hearti" class="far fa-heart"></i></button>
                        </div>
                        <!--END OF FABORITE BUTTON-->
                    </div>
                </div>
            </div>
        </section>
        <!--END OF HOUSE LISTINGS-->


        <!--PAGINATION-->
        <section>
            <nav aria-label="Search results pages">
                <ul class="pagination justify-content-center">
                    <li class="page-item"><a class="page-link" href="#" tabindex="-1" aria-disabled="true">Previous</a></li>
                    <li class="page-item page-active"><a class="page-link" href="#">1<span class="sr-only"></span></a></li>
                    <li class="page-item"><a class="page-link" href="#">2</a></li>
                    <li class="page-item"><a class="page-link" href="#">3</a></li>
                    <li class="page-item"><a class="page-link" href="#">Next</a></li>
                </ul>
            </nav>
        </section>
        <!--END OF PAGINATION-->

    </div>
</asp:Content>

