<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>RoomMagnet | Home</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container-fluid homepageAbove">


        <!--BEGINNING OF ROOMMAGNET IMAGE HEADER/JUMBOTRON-->
        <header>
            <div class="container-fluid carouselHOMEPAGEspace px-0 py-0">

                <!--BACKGROUND IMAGE HERE-->
                <div id="homePageCarousel" class="carousel slide" data-ride="carousel">
                    <div class="carousel-inner">
                        <div class="carousel-item active" data-interval="10000">
                            <div class="carousel-caption">
                                <h1 class="caption-headline-main">Age in place without worrying about the financial strain.</h1>                                
                                </div>
                                <img class="d-block w-100 img-fluid" src="images/senior-woman-learning-on-computer.jpg" alt="First slide" style="opacity:0.9;">
                        </div>

                        <div class="carousel-item" data-interval="10000">
                            <div class="carousel-caption">
                                <h1 class="caption-headline-dog">Don't leave your best friend behind.</h1>
                                <p class="caption-tagline">Search for pet-friendly homes near you.</p>
                            </div>
                            <img class="d-block w-100 img-fluid" src="images/girlwithdog.jpg" alt="third slide">
                        </div>

                        <div class="carousel-item" data-interval="10000">
                            <div class="carousel-caption">
                                <h1 class="caption-headline">Looking for help around the house?</h1>
                                <p class="caption-tagline-cooking">Search for a roommate near you.</p>
                            </div>
                            <img class="d-block w-100 img-fluid" src="images/cooking.jpg" alt="Second slide">
                        </div>


                    </div>
                </div>

                <a class="carousel-control-prev" href="#homePageCarousel" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="carousel-control-next" href="#homePageCarousel" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>


                <section class="searchform">
                    <div class="row">
                        <div class="col-sm-12 col-md-12 col-lg-12">
                            <!--FILTER BUTTON AND FILTER FORM-->
                            <div class="form-row">
                                <%--<button type="button" class="btn btn-info" data-toggle="modal" data-target="#filterOptions">Filter</button>
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

         



                                                <button type="button" class="btn btn-info btn-block">
                                                    Apply Filters
                                           
                                                </button>


                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!--END OF FILTER FORM-->--%>


                                <!--SEARCH BAR-->
                                <div class="col-md-6 searchBar">
                                    <asp:TextBox ID="txtSearch" runat="server" class="form-control form-control-lg " placeholder="Enter City, State" ClientIDMode="Static"></asp:TextBox>
                                </div>
                                <!--END OF SEARCH BAR-->

                                <!--BEGINNING OF SEARCH BUTTON-->
                                <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-info" OnClick="btnSearch_Click" />
                                <!--END OF SERACH BUTTON-->
                            </div>
                        </div>
                    </div>
                </section>

            </div>
        </header>
        <!--END OF IMAGE HEADER/JUMBOTRON-->




        <!--BEGINNING OF BODY CONTENT-->


        <!--BEGINNING OF SECTION 1 Why is there a need for ...-->
        <section class="px-5 py-2 mt-2">
            <!--FIRST ROW-->
            <div class="row">
                <div class="col-md-5 rounded oldandYoungImage">
                </div>

                <div class="col-md-7 rounded aboutusInfoBox ">
                    <div class="pt-3 pb-1">
                        <img src="images/roommagnetLOGO.png" alt="" class="img-fluid mx-auto d-block" width="500">
                    </div>

                    <p class="px-3">
                        roommagnet was created with a mission of matching together
                            an older generation looking to monetize their extra living 
                            space and a younger generation looking for a discounted rent. 
                            Do you want some extra help around the house? Do you need
                            someone to do your grocery shopping for you? Enjoy our HomeshareSmarter® Living feature and in exchange for a modest rent
                            cost, get a little help around the house.
                    </p>

                    <div class="learnmore text-center">
                        <a class="btn btn-md btn-info mb-3" href="AboutUs.aspx">
                            <h3>Learn More</h3>
                        </a>
                    </div>
                </div>
            </div>



        </section>
        <!--END OF SECTION 1 Why is there a need for ...-->



        <!--BEGINNING OF How it works-->
        <section class="px-5 py-2">
            <div class="row">
                <div class="col-md-7 rounded howItWorksBox">
                    <h2 class="text-center pt-3">How it works</h2>
                    <div class="col-md-12 rounded hwaccount mb-4 mt-3 text-center">
                        <p>1. Create an account</p>
                    </div>
                    <div class="col-md-12 rounded hwaccount mb-4 text-center">
                        <p>2. Set personality and housing preferences</p>
                    </div>
                    <div class="col-md-12 rounded hwaccount mb-4 text-center">
                        <p>3. Get matched!</p>
                    </div>
                    <div class="learnmore text-center">
                        <a class="btn btn-md btn-info" data-toggle="modal" data-dismiss="modal" data-target="#chooseAccountType">
                            <h3>Create Account</h3>
                        </a>
                    </div>

                </div>

                <!--HOST OR TENANT MOD-->
                <div class="modal justify-content-center" id="chooseAccountType">
                    <div class="modal-dialog">
                        <div class="modal-content pb-1">

                            <!-- Modal Header -->
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>

                            <!-- Modal body -->
                            <div class="modal-body ">
                                 
                                    <h4 class="modal-title pb-3">Are you a</h4>

                                    <a class="btn btn-info btn-block" href="HostCreateAccount.aspx">Host</a>

                                    <a class="btn btn-info btn-block" href="TenantCreateAccount.aspx">Tenant</a>
                                    <!--TENANT A TAG GOES IN BUTTON-->
                                 
                            </div>
                        </div>
                    </div>
                </div>
                <!--END OF HOST OR TENANT MOD-->

                <div class="col-md-5 rounded roomimagehomepage">
                </div>
            </div>
        </section>

        <!--END OF SECTION 2 RENT NEAR YOU IMAGES-->



        <!--BEGINNING OF SECTION 3 Testimonials  -->

        <section class="rounded px-5 py-5 mt-2 homepageCallaction text-center">
            <!--BEGINNING OF THIRD ROW CONTENT-->
            <h2>It's more than just finding a room.</h2>

            <!--END OF THIRD ROW CONTENT-->
        </section>

        <!--END OF SECTION  3 testimonials -->

        <!-- Section: Testimonials -->
        <section class="text-center my-5">

            <!-- Section heading -->
            <h2 class="h1-responsive font-weight-bold my-5" id="testimonials">Testimonials</h2>

            <div class="wrapper-carousel-fix">
                <!-- Carousel Wrapper -->
                <div id="carousel-example-1" class="carousel no-flex testimonial-carousel slide carousel slide" data-ride="carousel">
                    <!--Slides-->
                    <div class="carousel-inner" role="listbox">
                        <!--First slide-->
                        <div class="carousel-item active">
                            <div class="testimonial">
                                <!--Avatar-->
                                <div class="avatar mx-auto mb-4">
                                    <img src="images/bettyBrown.png" class="rounded-circle img-fluid"
                                        alt="First sample avatar image">
                                </div>
                                <!--Content-->
                                <p>
                                    <i class="fas fa-quote-left"></i>As a single mother who was living alone, I was hesitant to bring someone new into the house.
                                    <br>
                                    The background check feature made me feel secure and confident in the roommate pairing process. <i class="fas fa-quote-right"></i>
                                </p>
                                <h4 class="font-weight-bold">Karen Smith</h4>
                                <h6 class="font-weight-bold my-3">Empty-Nester, Homeowner, Age 65</h6>
                                <!--Review-->
                                <i class="fas fa-star blue-text"></i>
                                <i class="fas fa-star blue-text"></i>
                                <i class="fas fa-star blue-text"></i>
                                <i class="fas fa-star blue-text"></i>
                                <i class="fas fa-star-half-alt blue-text"></i>
                            </div>
                        </div>
                        <!--First slide-->
                        <!--Second slide-->
                        <div class="carousel-item">
                            <div class="testimonial">
                                <!--Avatar-->
                                <div class="avatar mx-auto mb-4">
                                    <img src="images/sam.png" class="rounded-circle img-fluid"
                                        alt="Second sample avatar image">
                                </div>
                                <!--Content-->
                                <p>
                                    <i class="fas fa-quote-left"></i>Through roommagnet I was able to find affordable housing because of the HomeshareSmarter® Living option. If I was living with other college students
                                    <br>
                                    I would most likely be grocery shopping for them anyways. With the HomeshareSmarter® Living option I am able to do these every day activities,
                                    <br>
                                    earn a discounted rent, and help my roommates in the process.  <i class="fas fa-quote-right"></i>
                                </p>
                                <h4 class="font-weight-bold">Liam Brown</h4>
                                <h6 class="font-weight-bold my-3">Student, Tenant, Age 21</h6>
                                <!--Review-->
                                <i class="fas fa-star blue-text"></i>
                                <i class="fas fa-star blue-text"></i>
                                <i class="fas fa-star blue-text"></i>
                                <i class="fas fa-star blue-text"></i>
                                <i class="fas fa-star blue-text"></i>
                            </div>
                        </div>
                        <!--Second slide-->
                        <!--Third slide-->
                        <div class="carousel-item">
                            <div class="testimonial">
                                <!--Avatar-->
                                <div class="avatar mx-auto mb-4">
                                    <img src="images/rebeccajames.png" class="rounded-circle img-fluid"
                                        alt="Third sample avatar image">
                                </div>
                                <!--Content-->
                                <p>
                                    <i class="fas fa-quote-left"></i>Coming to America, I was nervous about finding a place that felt like home. The roommagnet filters allowed me to search for potential roommates,
                                    <br>
                                    not only by house amentities, but by qualities such as language spoken. With this filter I was able to find a host that spoke the same
                                    <br>
                                    language as me, and understood my customs and values. <i class="fas fa-quote-right"></i>
                                </p>
                                <h4 class="font-weight-bold">Natalia Russo</h4>
                                <h6 class="font-weight-bold my-3">Graduate Student, Tenant, Age 23 </h6>
                                <!--Review-->
                                <i class="fas fa-star blue-text"></i>
                                <i class="fas fa-star blue-text"></i>
                                <i class="fas fa-star blue-text"></i>
                                <i class="fas fa-star blue-text"></i>
                                <i class="far fa-star blue-text"></i>
                            </div>
                        </div>

                    </div>
                    <!--Slides-->
                    <!--Controls-->
                    <a class="carousel-control-prev left carousel-control" href="#carousel-example-1" role="button"
                        data-slide="prev">
                        <span class="icon-prev" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="carousel-control-next right carousel-control" href="#carousel-example-1" role="button"
                        data-slide="next">
                        <span class="icon-next" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                    </a>
                    <!--Controls-->
                </div>
                <!-- Carousel Wrapper -->
            </div>

        </section>
        <!-- Section: Testimonials -->



        

            

    </div>
    <!--END OF BODY CONTENT-->

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
        };
        ajax.send();
    </script>
</asp:Content>

