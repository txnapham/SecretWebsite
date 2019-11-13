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
                                <h1 class="caption-headline-main">Matching students and empty-nesters.</h1>
                            </div>
                            <img class="d-block w-100 img-fluid" src="images/senior-woman-learning-on-computer.jpg" alt="First slide">
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
                        <div class="col-md-12">
                            <!--FILTER BUTTON AND FILTER FORM-->
                            <div class="form-row">
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
                                                                <input type="checkbox" class="form-check-input" id="filterPetFriendly">
                                                                <label class="form-check-lable" for="filterPetFriendly">Connected Bathroom</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterSportsFan">
                                                                <label class="form-check-lable" for="filterSportsFan">Walk-In Closet</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterSportsFan">
                                                                <label class="form-check-lable" for="filterSportsFan">Dryer</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterSportsFan">
                                                                <label class="form-check-lable" for="filterSportsFan">Ceiling Fan</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterSportsFan">
                                                                <label class="form-check-lable" for="filterSportsFan">Kitchen</label>
                                                            </div>
                                                        </div>

                                                    </div>

                                                    <div class="col-sm-6">

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterPetFriendly">
                                                                <label class="form-check-lable" for="filterPetFriendly">Separate Entrance</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterSportsFan">
                                                                <label class="form-check-lable" for="filterSportsFan">Air Conditioning</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterSportsFan">
                                                                <label class="form-check-lable" for="filterSportsFan">Washer</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterSportsFan">
                                                                <label class="form-check-lable" for="filterSportsFan">Wifi</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterSportsFan">
                                                                <label class="form-check-lable" for="filterSportsFan">Heating</label>
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
                                                                <input type="checkbox" class="form-check-input" id="filterPetFriendly">
                                                                <label class="form-check-lable" for="filterPetFriendly">Street Parking</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterSportsFan">
                                                                <label class="form-check-lable" for="filterSportsFan">Pool</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterSportsFan">
                                                                <label class="form-check-lable" for="filterSportsFan">Deck</label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-6">

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterPetFriendly">
                                                                <label class="form-check-lable" for="filterPetFriendly">Garage Parking</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterSportsFan">
                                                                <label class="form-check-lable" for="filterSportsFan">Backyard</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterSportsFan">
                                                                <label class="form-check-lable" for="filterSportsFan">Porch</label>
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
                                                                <input type="checkbox" class="form-check-input" id="filterPetFriendly">
                                                                <label class="form-check-lable" for="filterPetFriendly">Introvert</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterSportsFan">
                                                                <label class="form-check-lable" for="filterSportsFan">Extrovert</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterSportsFan">
                                                                <label class="form-check-lable" for="filterSportsFan">Family-Oriented</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterSportsFan">
                                                                <label class="form-check-lable" for="filterSportsFan">Tech-Savvy</label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-6">

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterPetFriendly">
                                                                <label class="form-check-lable" for="filterPetFriendly">Early Riser</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterSportsFan">
                                                                <label class="form-check-lable" for="filterSportsFan">Night Owl</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterSportsFan">
                                                                <label class="form-check-lable" for="filterSportsFan">Religious</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterSportsFan">
                                                                <label class="form-check-lable" for="filterSportsFan">Non-Smoker</label>
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
                                                                <input type="checkbox" class="form-check-input" id="filterPetFriendly">
                                                                <label class="form-check-lable" for="filterPetFriendly">English</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterSportsFan">
                                                                <label class="form-check-lable" for="filterSportsFan">Spanish</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterSportsFan">
                                                                <label class="form-check-lable" for="filterSportsFan">Mandarin</label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-6">

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterPetFriendly">
                                                                <label class="form-check-lable" for="filterPetFriendly">Japanese </label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterSportsFan">
                                                                <label class="form-check-lable" for="filterSportsFan">German</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterSportsFan">
                                                                <label class="form-check-lable" for="filterSportsFan">French</label>
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
                                                                <input type="checkbox" class="form-check-input" id="filterhomeshareYES">
                                                                <label class="form-check-lable" for="filterhomeshareYES">Yes</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="filterhomeshareNO">
                                                                <label class="form-check-lable" for="filterhomeshareNO">No</label>
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
                                <div class="col-md-7 searchBar">
                                    <input type="text" class="form-control form-control-lg" placeholder="Search">
                                </div>
                                <!--END OF SEARCH BAR-->

                                <!--BEGINNING OF SEARCH BUTTON-->
                                <button type="submit" class="btn btn-info" style="width=100px;">Search</button>
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
                        <a class="btn btn-md btn-info mb-3" href="about-us.html">
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
                        <a class="btn btn-md btn-info" href="#">
                            <h3>Create Account</h3>
                        </a>
                    </div>
                </div>

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



        <section class="rounded  px-5 py-5 mt-2 homepageCallaction homepageCallaction">
            <!--BEGINNING OF THIRD ROW CONTENT-->


            <div class="row">
                <div class="col-md-4 text-center">

                    <span style="color: #f7f7ff">
                        <i class="fas fa-user-check fa-7x  "></i>
                    </span>
                    <h2>Background Checks</h2>
                    =
                   
                </div>

                <div class="col-md-4 text-center">
                    <span style="color: #f7f7ff">
                        <i class="fas fa-heart fa-7x"></i>
                    </span>
                    <h2>Customer Support</h2>


                </div>

                <div class="col-md-4 text-center">
                    <span style="color: #f7f7ff">
                        <i class="fas fa-star fa-7x "></i>
                    </span>
                    <h2>Rating System</h2>

                </div>

            </div>
            <!--END OF THIRD ROW CONTENT-->
        </section>



    </div>
    <!--END OF BODY CONTENT-->

</asp:Content>

