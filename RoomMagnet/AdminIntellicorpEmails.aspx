<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminIntellicorpEmails.aspx.cs" Inherits="AdminIntellicorpEmails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid mt-5 px-5">
    <!--BREADCRUMBS-->
        <section>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="AdminDashboard.aspx" class="breadLink">Dashboard</a></li>
                    <li class="breadcrumb-item active" aria-current="page">User Emails for Intellicorp</li>
                </ol>
            </nav>
        </section>
        <!--END OF BREADCRUMBS-->

        <button class="nav-item btn btn-block createAppointment" type="button" data-toggle="modal" data-target="#confirm">
            <a class="btn btn-md btn-info " href="#">Change Background Check Status to Pending</a>
        </button>
        
        <div class="modal" id="confirm">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-body">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>

                        <center>
                            <font size="4">Confirm that e-mails are copied</font>
                        </center>

                        <asp:Button ID="btnChange" runat="server" Text="Yes" class="btn btn-md btn-info btn-block" OnClick="btnChange_Click" />
                        <button type ="button" class="btn btn-md btn-info btn-block" data-dismiss="modal">No</button>
                    </div>
                </div>
            </div>
        </div>

        <div class="pt-4">
            <table class="w-100">
                <tr class="text-center">
                    <th class="w-10" scope="col">Name</th>
                    <th class="text-left w-10" scope="col">Emails</th>
                </tr>
                <asp:Literal ID="intellicorpEmail" runat="server" Mode="Transform"></asp:Literal>
            </table>
        </div>
    </div>
</asp:Content>

