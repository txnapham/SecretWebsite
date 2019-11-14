<%@ Page Title="" Language="C#" MasterPageFile="~/HostPage.master" AutoEventWireup="true" CodeFile="ListedProperties.aspx.cs" Inherits="ListedProperties" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>RoomMagnet | Listed Properties</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--USER DASH-NAV-->
        <div class="container-fluid userDash mb-5 pb-3">
            <div class="navbar navbar-light">
                    <p><img src="images/bettyBrown.png" alt="..." class=" rounded-circle img-fluid" width="30%" height="auto">
                        Welcome USER,</p>
            
        
                <div class="progress" style="height: 30px;">
                    <div class="progress-bar bg-info" role="progressbar" style="width: 66%; color:#fff; font-size: 15px; font-weight:bold;" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"> Profile Completion</div>
                </div>
            </div>  
            
            <div class="row">
                
                <div class="col-md-12">
                        <div class="pl-3">
                            <button class="btn btn-sm personality-outline">English</button>
                            <button class="btn btn-sm personality-outline">Active</button>
                            <button class="btn btn-sm personality-outline">Non-Smoker</button>
                            <button class="btn btn-sm personality-outline">Adventurous</button>
                            <button class="btn btn-sm personality-outline">Early Riser</button>
                        </div>  
                </div>

            </div>
        </div>
        <!--END OF USER DASH-NAV-->
        
       
        <div class="container-fluid px-5">
            
            <!--BREADCRUMBS-->
            <section>    
                 <nav aria-label="breadcrumb">
                      <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="HostDashboard.aspx" class="breadLink">Dashboard</a></li>
                        <li class="breadcrumb-item active" aria-current="page">Listed Properties</li>
                      </ol>
                </nav>   
            </section>    
<!--END OF BREADCRUMBS-->   
            
            <div class="pl-3">
                <h3>Properties</h3>
            </div>
   
            <section >            
                <div class="row px-3 py-3">
                    
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
                            
                               <!-- <div>
                                    <button id="heartbtn" class="btn favoriteHeartButton"> <i id="hearti" class="far fa-heart" ></i></button>    
                                </div>-->
                            
                            
                            <div>
                                <button class="btn"><i class="fas fa-heart"></i></button>
                            </div>
                         <!--END OF FABORITE BUTTON-->
                        </div>
                    </div>                        
                </div>
            </section>
            
            
            <div>
                <a class="btn btn-info ml-3" href="ListPropertyForm.aspx">Add Property</a>
                
            </div>
            
            
        </div>
</asp:Content>

