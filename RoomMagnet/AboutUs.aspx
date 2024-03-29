﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>RoomMagnet | About Us</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container-fluid aboutPage">
        <!--BREADCRUMBS-->
        <section>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="Home.aspx" class="breadLink">Home</a></li>
                    <li class="breadcrumb-item active" aria-current="page">About Us</li>
                </ol>
            </nav>
        </section>
        <!--END OF BREADCRUMBS-->

        <!--Header Image-->

        <!--End of Header Image-->

        <section class="px-5 py-3 " id="whoAreWe">
            <div class="row">
                <div class="col-md-6">
                    <img src="images/anthony-rooke--NJO7AF0mUo-unsplash.jpg" class="img-fluid">
                </div>
                <div class="col-md-6">
                    <h3>Who are we?</h3>

                    <p>
                        roommagnet brings together a solution to two social problems that are of major concern to society and continue to escalate internationally.
                       
                    </p>

                    <p>The first is the cost of affordable housing. Costs for college students, interns and young professionals continues to escalate at an alarming pace, making it more difficult to get a start on their careers.</p>


                    <p>Secondly, older adults and empty-nesters, as they get older, wish to age in place, and often need additional income and at times assistance with light domestic duties such as shopping, household duties, daily maintenance or just companionship.</p>

                    <p>roommagnet connects tenants that have limited financial capital with hosts who wish to monetize their extra living space by having someone live in and assist either financially or in exchange for some light domestic duties.</p>

                    <p>How does roommagnet brings together two vastly different groups of people? We accomplish this by providing a beautifully designed, fully functional digital platform that matches tenants with hosts, enabling them to form a mutually beneficial relationship.</p>
                </div>

            </div>
        </section>



        <section class="px-5 py-3" id="ourGoals">
            <div class="row">
                <div class="col-md-6">
                    <h3>Our Goals</h3>

                    <p>Our goal is to bring professional and semi-professionals such as, graduate students, international students, doctoral and nursing interns as well as college students seeking affordable housing together with hosts who have extra room to share. Students can do light housekeeping and chores in exchange for reduced rent, while hosts enjoy having help available and earning income from their extra living space.</p>
                </div>
                <div class="col-md-6">
                    <img src="images/man-wearing-eyeglasses-making-a-toast-3184184.jpg" class="img-fluid ">
                </div>
            </div>
        </section>


        <section class="px-5 py-3" id="faQs">
            <h2>Frequently Asked Questions</h2>

            <div id="acordion">
                <div class="card">
                    <div class="card-header">
                        <a class="card-link faq-headers" data-toggle="collapse" href="#collapseOne">
                            <h5>What makes roommagnet different?</h5>
                        </a>
                    </div>
                    <div id="collapseOne" class="collapse show" data-parent="#accordion">
                        <div class="card-body">
                            roommagnet provides an easy to use platform where pre-screened Tenants and Hosts come together, and in exchange for a modest cost and/or in exchange for light domestic duties, enjoy reduced rent. It’s a win-win! Hosts monetize their extra living space and if they wish to get a little help around the house. Tenants enjoy affordable housing.
                       
                        </div>
                    </div>
                </div>

                <div class="card">
                    <div class="card-header">
                        <a class="collapsed card-link faq-headers" data-toggle="collapse" href="#collapseTwo">
                            <h5>Who can use roommagnet?</h5>
                        </a>
                    </div>
                    <div id="collapseTwo" class="collapse" data-parent="#accordion">
                        <div class="card-body">
                            roommagnet users must be at least 18 years of age and are seeking a minimum of 30 days stay in Host lodging. While Roommagnet is open to all who meet their minimum requirements we specialize in connecting Hosts with professional and semi-professionals such as graduate students, international students, doctoral and nursing interns as well as college students seeking affordable off campus housing.
                       
                        </div>
                    </div>
                </div>

                <div class="card">
                    <div class="card-header">
                        <a class="collapsed card-link faq-headers" data-toggle="collapse" href="#collapseThree">
                            <h5>Who are host families?</h5>
                        </a>
                    </div>
                    <div id="collapseThree" class="collapse" data-parent="#accordion">
                        <div class="card-body">
                            Host families are those who have room in their home, empty-nesters and people of advanced age who wish to age in place, and wish to monetize their empty space. In cases where hosts are interested in getting a little help around the house and tenants are willing to provide assistance with things such as light domestic or outdoor work, running errands, as well as companionship a further rent discount will be offered by the host and negotiated between host and tenant.

                       
                        </div>
                    </div>
                </div>

                <div class="card">
                    <div class="card-header">
                        <a class="collapsed card-link faq-headers" data-toggle="collapse" href="#collapsefour">
                            <h5>What is the advantage to a host family?</h5>
                        </a>
                    </div>
                    <div id="collapsefour" class="collapse" data-parent="#accordion">
                        <div class="card-body">
                            <p>roommagnet connects host families who wish to share empty space in their home with responsible inter-generational adults who seek affordable housing in order to continue their careers. These may be advanced college students, doctoral and nursing interns, international students or professionals. Host families have the assurance that Tenants are carefully screened.</p>

                            <p>Hosts who need assistance with light domestic duties (i.e. shopping, household odd jobs, daily maintenance or just companionship) will offer further discount for assistance.</p>
                        </div>
                    </div>
                </div>

                <div class="card">
                    <div class="card-header">
                        <a class="collapsed card-link faq-headers" data-toggle="collapse" href="#collapsefive">
                            <h5>Why is there a need for roommagnet?</h5>
                        </a>
                    </div>
                    <div id="collapsefive" class="collapse" data-parent="#accordion">
                        <div class="card-body">
                            As the cost of housing increases and become more scare in highly populated areas, it becomes harder for responsible students, as well as professional and semi-professionals (ie: doctoral interns, and interning nurses) to find suitable and affordable housing. Likewise, International students not only have the added expense of international living, but also must adjust to the cultural landscape of the U.S., which living with a host family can greatly reduce.

                       
                        </div>
                    </div>
                </div>

                <div class="card">
                    <div class="card-header">
                        <a class="collapsed card-link faq-headers" data-toggle="collapse" href="#collapsesix">
                            <h5>What is roommagnet’s HomeshareSmarter® Living option?</h5>
                        </a>
                    </div>
                    <div id="collapsesix" class="collapse" data-parent="#accordion">
                        <div class="card-body">
                            Tenants who are open to assisting host families with some basic chores like running errands, doing yard work or just providing companionship or personal assistance will receive a discount on their housing. We call this HomeShareSmarter® Living.
                       
                        </div>
                    </div>
                </div>

                <div class="card">
                    <div class="card-header">
                        <a class="collapsed card-link faq-headers" data-toggle="collapse" href="#collapseseven">
                            <h5>Who are roommagnet’s Advisors?</h5>
                        </a>
                    </div>
                    <div id="collapseseven" class="collapse" data-parent="#accordion">
                        <div class="card-body">
                            Our advisors are available to assist hosts who would rather sit back and experience the benefits of the roommagnet program but not the hassle of getting set up. Email us today and let us set up a personal meeting with one of our advisors to walk you through the process. It’s that easy!


                       
                        </div>
                    </div>
                </div>

                <div class="card">
                    <div class="card-header">
                        <a class="collapsed card-link faq-headers" data-toggle="collapse" href="#collapseeight">
                            <h5>What is roommagnet’s background screening procedure?</h5>
                        </a>
                    </div>
                    <div id="collapseeight" class="collapse" data-parent="#accordion">
                        <div class="card-body">
                            We require all roommagnet users ( Tenants and Hosts) who wish to connect on our platform  to initiate a background check. We ask this so that our users feel secure in taking advantage of the benefits of roommagnet. Hosts or Tenants may request, and rely upon one or more consumer reports or investigative consumer reports to determine a compatible living arrangement. Should either Host or Tenants not choose to initiate a background screen, either party may continue to search the site to find a compatible match, however before a match is consummated a background screen must be initiated.

                       
                        </div>
                    </div>
                </div>

                <div class="card">
                    <div class="card-header">
                        <a class="collapsed card-link faq-headers" data-toggle="collapse" href="#collapsenine">
                            <h5>What is the cost of my criminal background check?</h5>
                        </a>
                    </div>
                    <div id="collapsenine" class="collapse" data-parent="#accordion">
                        <div class="card-body">
                            <p>roommagnet has selected a criminal background company that follows the Federal Credit Reporting Act (FCRA) regulations. The background information is obtained from the consumer reporting agency, IntelliCorp Records, Inc. which can be contacted by mail at 3000 Auburn Dr, Suite 410;Beachwood, OH 44122; or phone: 1-888-946-8355; or website: www.intellicorp.net</p>
                            <p>
                                The cost of securing your criminal background check with Intellicorp is $24.95. (Use this link to
                            begin your criminal background check. Be sure to enter the password located below link:
                           
                            </p>
                            <p>
                                Intellicorp Records will provide a link to request a copy of your background report once it is completed .
                           
                            </p>
                        </div>
                    </div>
                </div>

                <div class="card">
                    <div class="card-header">
                        <a class="collapsed card-link faq-headers" data-toggle="collapse" href="#collapseten">
                            <h5>What is the cost of becoming part of the roommagnet community?</h5>
                        </a>
                    </div>
                    <div id="collapseten" class="collapse" data-parent="#accordion">
                        <div class="card-body">
                            <p>
                                roommagnet does not charge either Tenants or Hosts a fee to register, develop a profile, list a property or search. Upon a confirmed letter of intent, tenants will be required to pay the first and last month’s rent.
                           
                            </p>
                            <p>
                                roommagnet earns a match fee of one month’s rent once Host and Tenants connect and initiate the company’s letter of intent indicating a desirable match and a start date for occupancy. 
                           
                            </p>
                            <p>
                                Such commission will be deducted from the first month’s base rental rate with the balance then forwarded to the host. On Lease agreements that are sixty (60) days or less Roommagnet will only require a 30% commission of the total lease term rental.
                           
                            </p>
                        </div>
                    </div>
                </div>

                <div class="card">
                    <div class="card-header">
                        <a class="collapsed card-link faq-headers" data-toggle="collapse" href="#collapseEleven">
                            <h5>Why do we use Stripe to disperse payments?</h5>
                        </a>
                    </div>
                    <div id="collapseEleven" class="collapse" data-parent="#accordion">
                        <div class="card-body">
                            Stripe is a recognized secure payment platform that works similar to Paypal in that it collects payments from roommagnet Renters (Tenants) and automatically disperses funds to Landlords (Hosts). In order for roommagnet to disperse funds, landlords (hosts) will need to set up a simple stripe account. This will enable RoomMagnet to distribute funds directly and quickly to the account provided. Stripe is a network with redundant security encryption, and all information is kept strictly confidential. For more information on stripe visit www.stripe.com.
                       
                        </div>
                    </div>
                </div>

                <div class="card">
                    <div class="card-header">
                        <a class="collapsed card-link faq-headers" data-toggle="collapse" href="#collapseTwelve">
                            <h5>How can I get involved with roommagnet?</h5>
                        </a>
                    </div>
                    <div id="collapseTwelve" class="collapse" data-parent="#accordion">
                        <div class="card-body">
                            <p>
                                We are currently looking for people with strong writing skills to use their talents to write articles to be featured on www.roommagnet.com. Put your journalistic talents to the test by writing about topics that would appeal to our community. If you have a burning desire to vent on social news, sports, college life, then let’s talk.
                           
                            </p>
                            <p>
                                Send us an e mail, tell us a little about yourself ,send us an example of your writing and we’ll get back to you. And if you’re unsure about your writing, we have great people here at RoomMagnet that will help turn your pieces into first rate work. Come on! We’re waiting for you.
                           
                            </p>

                        </div>
                    </div>
                </div>

            </div>

        </section>


        <section class="px-5 py-3" id="ourPolicy">
            <div class="row">
                <div class="col-md-12">
                    <h3>Our Policy</h3>
                    <h5>roommagnet’s Fair Housing Policy</h5>
                    <p>The Fair HousingAct (Title VIII of the Civil Rights Act of 1968), prohibits discrimination in the rental of housing based on race, color, national origin, religion,handicap (disability),sex, familial status (including children under the age of 18 living with parents of legal custodians, pregnant women, and people securing custody of children under the age of 18).We encourage all RoomMagnet users to comply, in all respects, with all laws, rules, and regulations regarding landlord and tenant, including the requirements imposed by the Fair Housing Act.</p>
                </div>
            </div>
        </section>


    </div>
</asp:Content>

