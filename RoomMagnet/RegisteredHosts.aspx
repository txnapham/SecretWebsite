<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.master" AutoEventWireup="true" CodeFile="RegisteredHosts.aspx.cs" Inherits="RegisteredHosts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>RoomMagnet | Registered Hosts</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid userDash mb-2">
                <!--USER DASH-NAV-->
        <div class="container-fluid userDash pt-2">
            <div class="navbar navbar-light">
                    <h4><img src="images/robert.png" alt="..." class="rounded-circle img-fluid" width="30%" height="auto">
                        Welcome Admin,</h4>
            </div>

        </div>
        <!--END OF USER DASH-NAV-->
        </div>
        
       
        <div class="container-fluid px-5">
            
            <!--BREADCRUMBS-->
            <section>    
                 <nav aria-label="breadcrumb">
                      <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="AdminDashboard.aspx" class="breadLink">Dashboard</a></li>
                        <li class="breadcrumb-item active" aria-current="page">Registered Tenants</li>
                      </ol>
                </nav>   
            </section>    
<!--END OF BREADCRUMBS-->   
        
            
            <div class="form-row justify-content-center">
                <asp:TextBox ID="txtSearch" runat="server" class="form-control form-control-lg" placeholder="Search" style="width:80%;"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-info"/>
            </div>                 
                          
                
                
                <div class="pt-4">
                <table class="w-100 ">
                    <tr class="text-center">
                        <th class="w-50" scope="col">Registered Tenants</th>
                        <th class="text-right w-10" scope="col">Background Status</th>
                        <th class="text-right w-10" scope="col">Account Status</th>
                    </tr>
                    
                    <tr>
                        <td>First Name Last Name</td>
                        <td><button class="btn btn-no-go">Background Status</button></td>
                        <td><button class="btn btn-info">Delete Account</button></td>
                    </tr>
                     <tr>
                        <td>First Name Last Name</td>
                        <td><button class="btn btn-yes-go">Background Status</button></td>
                        <td><button class="btn btn-info">Delete Account</button></td>
                    </tr>
                     
                
                </table>
            </div>
            
            
            
            
        </div>
</asp:Content>

