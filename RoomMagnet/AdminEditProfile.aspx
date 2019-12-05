<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.master" AutoEventWireup="true" CodeFile="AdminEditProfile.aspx.cs" Inherits="AdminEditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>RoomMagnet | Edit Profile</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container-fluid px-5 mt-4">
        <!--BREADCRUMBS-->
        <section>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="AdminDashboard.aspx" class="breadLink">Dashboard</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Edit Profile</li>
                </ol>
            </nav>
        </section>
        <!--END OF BREADCRUMBS-->

        <div class="row ">
            <div class="form-group">
                        <asp:TextBox ID="txtFN" runat="server" class="form-control form-control-lg" placeholder="First Name" MaxLength="10"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtMN" runat="server" class="form-control form-control-lg" placeholder="Middle Name" MaxLength="10"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtLN" runat="server" class="form-control form-control-lg" placeholder="Last Name" MaxLength="10"></asp:TextBox>
                    </div>
        </div>

    </div>

</asp:Content>

