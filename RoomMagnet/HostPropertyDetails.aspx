<%@ Page Title="" Language="C#" MasterPageFile="~/HostPage.master" AutoEventWireup="true" CodeFile="HostPropertyDetails.aspx.cs" Inherits="HostPropertyDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>RoomMagnet | Property Detail</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--Propterty Detail-->
    <div class="container-fluid searchpageDetailBodyContent pl-0 pr-0 mt-0">

        <!--Carousel Wrapper-->
        <div id="carousel-thumb" class="carousel slide carousel-fade carousel-thumbnails" data-ride="carousel">
            <!--Slides-->
            <div class="carousel-inner" role="listbox">
                <div class="carousel-item active">
                    <img class="d-block w-100" src="images/anthony-rooke--NJO7AF0mUo-unsplash.jpg"
                        alt="First slide">
                </div>
                <div class="carousel-item">
                    <img class="d-block w-100" src="images/loft-style-bedroom.jpg"
                        alt="Second slide">
                </div>
                <div class="carousel-item">
                    <img class="d-block w-100" src="images/scott-webb-1ddol8rgUH8-unsplash.jpg"
                        alt="Third slide">
                </div>
            </div>
            <!--/.Slides-->
            <!--Controls-->
            <a class="carousel-control-prev" href="#carousel-thumb" role="button" data-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="carousel-control-next" href="#carousel-thumb" role="button" data-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
            <!--/.Controls-->
            <ol class="carousel-indicators">
                <li data-target="#carousel-thumb" data-slide-to="0" class="active">
                    <img src="images/anthony-rooke--NJO7AF0mUo-unsplash.jpg" width="100">
                </li>
                <li data-target="#carousel-thumb" data-slide-to="1">
                    <img src="images/loft-style-bedroom.jpg" width="100">
                </li>
                <li data-target="#carousel-thumb" data-slide-to="2">
                    <img src="images/scott-webb-1ddol8rgUH8-unsplash.jpg" width="100">
                </li>
            </ol>
        </div>
        <!--/.Carousel Wrapper-->



        <section>
            <div class="row propertyPageDetailTitle pt-3 pb-3">
                <div class="col-md-10 pl-5">
                    <h2>Kew Gardens</h2>
                </div>
                <div class="col-md-2">
                    <button class="btn favoriteHeartButton"><i class="far fa-heart"></i></button>
                </div>
            </div>

        </section>


        <section>
            <!--FIRST ROW-->

            <div class="row px-5 py-5">
                <div class="col-md-8 ">
                    <div class="col-md-12 card  shadow-sm  px-5 py-5">
                        <div>
                            <h4>About Room</h4>
                        </div>
                    </div>

                    <div class="col-md-12 card  shadow-sm  px-5 py-5">
                        <div>
                            <h4>Amenities</h4>
                        </div>
                    </div>

                    <div class="col-md-12 card  shadow-sm  px-5 py-5">
                        <div>
                            <h4>Local Information</h4>
                        </div>
                    </div>

                </div>


                <div class="col-md-4 ">
                    <div class="px-5 py-5  shadow-sm  card">

                        <button class="btn btn-info">
                            Edit Room
                        </button>
                    </div>
                </div>


            </div>


            <!--END OF FIRST ROW-->
        </section>
    </div>
    <!--End of Property Detail-->
</asp:Content>

