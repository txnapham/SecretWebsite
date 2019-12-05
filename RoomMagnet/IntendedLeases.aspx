<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.master" AutoEventWireup="true" CodeFile="IntendedLeases.aspx.cs" Inherits="IntendedLeases" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid mt-5 px-5">

        <!--BREADCRUMBS-->
        <section>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="AdminDashboard.aspx" class="breadLink">Dashboard</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Intended Leases</li>
                </ol>
            </nav>
        </section>
        <!--END OF BREADCRUMBS-->

        <div class="form-row justify-content-center">
            <asp:TextBox ID="txtSearch" runat="server" class="form-control form-control-lg" placeholder="Search" Style="width: 80%;"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-info" OnClick="btnSearch_Click" />
        </div>

        <div class="pt-4">
            <table class="w-100">
                <tr class="text-center">
                    <th class="w-10" scope="col">Host</th>
                    <th class="text-left w-10" scope="col">Tenant</th>
                </tr>
                <asp:Literal ID="IntLease" runat="server" Mode="Transform"></asp:Literal>
            </table>
        </div>
    </div>
</asp:Content>

