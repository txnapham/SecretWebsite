<%@ Page Title="" Language="C#" MasterPageFile="~/HostPage.master" AutoEventWireup="true" CodeFile="HostCreateLease.aspx.cs" Inherits="HostCreateLease" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>RoomMagnet | Dashboard | Create Lease</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid userDash mb-2">
        <!--USER DASH-NAV-->
        <div class="container-fluid userDash mb-2 pb-3">
            <div class="navbar navbar-light">
                <p>
                    <img src="images/bettyBrown.png" alt="..." class=" rounded-circle img-fluid" width="30%" height="auto">
                    Welcome USER,
                </p>


                <div class="progress" style="height: 30px;">
                    <div class="progress-bar bg-info" role="progressbar" style="width: 66%; color: #fff; font-size: 15px; font-weight: bold;" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100">Profile Completion</div>
                </div>
            </div>

        </div>
        <!--END OF USER DASH-NAV-->
    </div>


    <div class="container-fluid px-5">

        <!--BREADCRUMBS-->
        <section>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="HostDashboard.aspx" class="breadLink">Dashboard</a></li>
                    <li class="breadcrumb-item"><a href="HostMessageCenter.aspx" class="breadLink">Messages</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Lease Room</li>
                </ol>
            </nav>
        </section>
        <!--END OF BREADCRUMBS-->

        <section class="shadow-sm px-3 py-3">

            <div class="row mb-3">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <h2>roommagnet Rental Aggrement</h2>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <h5>Fair Housing for all is the cornstone of roommagnet's philosophy. Please refer to the Fair Housing Act link at the end of this agreement</h5>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <p>This is a good faith agreement between Tenant and Host(owner). It is intended to promote household harmony by clarifying the expectations and responsibilities of the Host(s) and Tenant. The Host and Tenant should review this document. Please be aware there are landlord-tenant laws that govern each state. Please refer to the link at the end of this agreement.</p>
                </div>
            </div>

            <!--address of the home-->
            <h3>1. Home Address</h3>
            <div class="form-row">
                <div class="form-group col-sm-7 col-md-7 col-lg-7">
                    <asp:TextBox ID="txtCity" runat="server" class="form-control form-control-lg" placeholder="City" MaxLength="30"></asp:TextBox>
                </div>


                <div class="form-group col-sm-3 col-md-3 col-lg-3">
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

                <div class="form-group col-sm-2 col-md-2 col-lg-2">
                    <asp:TextBox ID="txtZip" runat="server" class="form-control form-control-lg" placeholder="Zip" MaxLength="9"></asp:TextBox>
                </div>
            </div>

            <!--2. parties-->
            <h3>2. Parties</h3>

            <h5>Owner(s)</h5>
            <div class="form-row">
                <div class="form-group  col-sm-5 col-md-5 col-lg-5">
                    <asp:TextBox ID="txtHFN" runat="server" class="form-control form-control-lg" aria-describedby="FirstName" placeholder="First Name" MaxLength="50"></asp:TextBox>
                </div>

                <div class="form-group col-sm-2 col-md-2 col-lg-2">
                    <asp:TextBox ID="txtHMN" runat="server" class="form-control form-control-lg" aria-describedby="MiddleName" placeholder="Middle Name" MaxLength="50"></asp:TextBox>
                </div>


                <div class="form-group col-sm-5 col-md-5 col-lg-5">
                    <asp:TextBox ID="txtHLN" runat="server" class="form-control form-control-lg" aria-describedby="LastName" placeholder="Last Name" MaxLength="50"></asp:TextBox>
                </div>


                <div class="form-group  col-sm-5 col-md-5 col-lg-5">
                    <asp:TextBox ID="txtHFN2" runat="server" class="form-control form-control-lg" aria-describedby="FirstName" placeholder="First Name" MaxLength="50"></asp:TextBox>
                </div>

                <div class="form-group col-sm-2 col-md-2 col-lg-2">
                    <asp:TextBox ID="txtHMN2" runat="server" class="form-control form-control-lg" aria-describedby="MiddleName" placeholder="Middle Name" MaxLength="50"></asp:TextBox>
                </div>


                <div class="form-group col-sm-5 col-md-5 col-lg-5">
                    <asp:TextBox ID="txtHLN2" runat="server" class="form-control form-control-lg" aria-describedby="LastName" placeholder="Last Name" MaxLength="50"></asp:TextBox>
                </div>
            </div>

            <h5>Tenant</h5>
            <div class="form-row">
                <div class="form-group  col-sm-5 col-md-5 col-lg-5">
                    <asp:TextBox ID="txtTFN" runat="server" class="form-control form-control-lg" aria-describedby="FirstName" placeholder="First Name" MaxLength="50"></asp:TextBox>
                </div>

                <div class="form-group col-sm-2 col-md-2 col-lg-2">
                    <asp:TextBox ID="txtTMN" runat="server" class="form-control form-control-lg" aria-describedby="MiddleName" placeholder="Middle Name" MaxLength="50"></asp:TextBox>
                </div>


                <div class="form-group col-sm-5 col-md-5 col-lg-5">
                    <asp:TextBox ID="txtTLN" runat="server" class="form-control form-control-lg" aria-describedby="LastName" placeholder="Last Name" MaxLength="50"></asp:TextBox>
                </div>
            </div>

            <!--3. Start Date-->
            <div class="form-row ">
                <div class="form-group col-sm-4 col-md-4 col-lg-4">
                    <h3>3. Start Date</h3>
                    <label>The start Date of this lease is:</label>
                    <asp:TextBox ID="txtDate" runat="server" class="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>



            <!--4. Length of Agreement-->
            <div class="form-row ">
                <div class="form-group col-sm-12 col-md-12 col-lg-12">
                    <h3>4. Length of Agreement</h3>
                    <p>
                        <asp:TextBox ID="txtLength" runat="server" placeholder="Length of Agreement"></asp:TextBox>
                        The Tenant must provide at least 30 days written notice, signed by both parties, to cancel or change the Agreement.
                    </p>
                </div>
            </div>

            <!--5. Rental Rate-->

            <div class="form-row ">
                <div class="form-group">
                    <h3>5. Rental Rate</h3>
                </div>
                <p>
                    The Base rental rate for the room is
                    <asp:TextBox ID="txtMoney" runat="server"></asp:TextBox>
                    per month. The tentat will pay
                    <input type="text">
                    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                    to the host on a monthly basis and this relfects the base rental rate. If the household tasks are part of this agreement the Tenant will pay the base rental rate and will work out any discount directly with the host.
                </p>
            </div>

            <!--6. conflict resolution-->
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <h3>6. Conflict Resolution</h3>
                    <p>Tenant will strive to develop mutual cooperation with the Owner. Should disafreements arise, each shall try to resolve the dispute in good faith using clear communication.</p>
                </div>
            </div>

            <!--7. utilities and amenitits-->
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <h3>7. Utilities and Amenities</h3>
                    <p>Rent includes access to/use of heat, air conditioning, hot and cold water, elctricity, recycling and wast services.</p>
                    <p>Standard wired and wireless shared internet access is provided at no additional cost with access granted on Start Date.</p>
                </div>
            </div>


            <!--8. Room Alterations-->
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <h3>8. Room Alterations</h3>
                    <p>Tenants agree to not alter, modify, or otherwise change Tenant Spaces or Common Areas. This includes, but is not limited to painting, remodeling, and "fixing" unless otherwise granted permission by Manager or Owner.</p>
                    <p>Tenant must leave the property in the same condition as when they moved in, barring normal wear and tear.</p>
                </div>
            </div>

            <!--9. Animal and Pet Policy-->
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <h3>9. Animal and Pet Policy</h3>
                    <p>Tenant agrees to not keep or allow anywhere on or about the premises any animals or pet of any kind, including, but not limited to cats, dogs, rodents, birds, adn reptiles unless otherwise granted permission below by Owner upon execution of this agreement.</p>

                    <p>
                        Owner agrees to pets
                        <input type="checkbox">
                    </p>
                    <p>
                        Owner does not agree to pets
                        <input type="checkbox">
                    </p>
                </div>
            </div>


            <!--10. Drugs-->
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <h3>10. Drugs</h3>
                    <p>No illegal drugs are allowed on the property.</p>
                </div>
            </div>

            <!--11. smoking-->
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <h3>11. Smoking</h3>
                    <p>No smoking within the property or within 25 feet of the property unless otherwise granted permission by Owner(s). Tenant must properly dispose of cigarette butts so as to not cause a fire hazard.</p>
                </div>
            </div>


            <!--12. Catastrophic Damage-->
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <h3>12. Catastrophic Damages</h3>
                    <p>If the Home is damged or destroyed, making it unihabitable, then Owner(s) and Tenant shall have the right to terminiate this Agreement immediately if both parties agree.</p>
                </div>
            </div>


            <!--13. Insurance Disclaimer-->
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <h3>13. Insurance Disclaimer</h3>
                    <p>Tenants assume full responsibility for all personal property placed, stored or located on or about the premises. Tenants' personal property is not insured by Owner. Owner recommends that Tenants obtain renters insurance to protect against risk of loss from harm to Tenants' personal property. The owner shall not be responsible for any harm to Tenants' property resulting from fire, theft, burglary, strikes, riots, orders or acts of public authorities, acts of nature or any other circumstance or event beyond Owner’s control.</p>
                </div>
            </div>

            <!--14. Hold Harmless-->
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <h3>14. Hold Harmless</h3>
                    <p>Tenants expressly release Owner from any and all liability for any damages or injury to Tenant, or any other person, or to any property, occurring on the premises unless such damage is the direct result of the negligence or unlawful act of Owner or Owner’s agents.</p>
                </div>
            </div>


            <!--15. Smoke detectors-->
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <h3>15. Smoke Detectors</h3>
                    <p>The premises are equipped with a smoke detection device(s), and Tenants shall be responsible for reporting any problems, maintenance or repairs to Owner. Replace batteries of smoke detectors in the primary bedroom of the Tenant is the responsibility of the Tenant.</p>
                </div>
            </div>


            <!--16. Lead Based Paint Disclosure-->
            <div class="row mb-3">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <h3>16. Lead Based Paint Dislosure</h3>
                    <p>Tenant acknowledge receipt of "Disclosure of Information on Lead-Based Paint Hazards" from Owner/Agent. (Required for homes built before 1978) Available online at:</p>
                    <a href="http://www.epa.gov/region07/citizens/pdf/lead_disclosure_form_rentals.pdf">http://www.epa.gov/region07/citizens/pdf/lead_disclosure_form_rentals.pdf</a>


                    <p>Tenant acknowledges receipt of the pamphlet Protect Your Family from Lead in Your Home (Required for homes built before 1978). Available online at:</p>

                    <a href="http://www2.epa.gov/lead/protect-your-family-lead-your-home">http://www2.epa.gov/lead/protect-your-family-lead-your-home</a>

                </div>
            </div>


            <!--17. Subletting-->
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <h3>17. Subletting</h3>
                    <p>No portion of the premises shall be sublet nor this Agreement assigned without the prior written consent of the Owner. Any attempted subletting or assignment by Tenants shall, at the election of Owner, be a breach of this Agreement and cause for immediate termination as provided here and by law.</p>
                </div>
            </div>

            <!--18. Individual Liability-->
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <h3>18. Individual Liability</h3>
                    <p>Each tenant who signs this Agreement, whether or not said person is or remains in the Home, shall be jointly and severally liable for the full performance of each and every obligation of this Agreement.</p>
                </div>
            </div>

            <!--19. Modifications to this agreement-->
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <h3>19. Modification to this Agreement</h3>
                    <p>This agreement is the Whole Enchilada. This Agreement cannot be modified except in writing and must be signed by all parties. Neither Owner nor Tenants have made any promises or representations other than those set forth in this Agreement and those implied by law. By signing this agreement, the Tenant acknowledges having read and agreed to all of its provisions. Any additional agreements or amendments to this agreement between Tenant and Owner will not be considered binding unless it is in writing and signed by all parties.</p>
                </div>
            </div>



            <!--Sign and Date-->
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <h3>Sign and Date</h3>
                    <div class="col-sm-6 col-md-6 col-lg-6 float-left">
                        Tenant Signature:
                    <asp:TextBox ID="txtTenantSig" runat="server"></asp:TextBox>
                        <div class="col-sm-6 col-md-6 col-lg-6 float-right">
                            Date:
                       <asp:TextBox ID="txtTDate" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="col-sm-12 col-md-12 col-lg-12 mt-3">
                    <div class="col-sm-6 col-md-6 col-lg-6 float-left">
                        Host Signature:
                        <asp:TextBox ID="txtHostSig" runat="server"></asp:TextBox>
                        <div class="col-sm-6 col-md-6 col-lg-6 float-right">
                            Date:
                        <asp:TextBox ID="txtHDate" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>



                <div class="row mt-3">
                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <p><em>This agreement adheres to the Federal Fair Housing Act. Please read your rights as a tenant and landlord.</em></p>

                        <a href="https://portal.hud.gov/hudportal/HUD?src=/program_offices/fair_housing_equal_opp/FHLaws/your%20rights">https://portal.hud.gov/hudportal/HUD?src=/program_offices/fair_housing_equal_opp/FHLaws/your%20rights</a>

                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <p>The following are additional items that Tenants and Host may want to discuss as part of this agreement.</p>

                        <ul>
                            <li>Domestic task (if any)</li>
                            <li>Guest (staying or visiting)</li>
                            <li>Tenant's belongings left behind</li>
                            <li>Owners Entry and Inspection</li>
                            <li>Care and Cleaning of rental space</li>
                        </ul>
                    </div>
                </div>

                <asp:Button ID="btnCreateLease" runat="server" Text="Create Lease" class="btn btn-info btn-lg btn-block" />
            </div>
</asp:Content>

