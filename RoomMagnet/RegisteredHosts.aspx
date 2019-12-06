<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.master" AutoEventWireup="true" CodeFile="RegisteredHosts.aspx.cs" Inherits="RegisteredHosts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>RoomMagnet | Registered Hosts</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">       
    <div class="container-fluid mt-5 px-5">
            
        <!--BREADCRUMBS-->
        <section>    
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="AdminDashboard.aspx" class="breadLink">Dashboard</a></li>
                <li class="breadcrumb-item active" aria-current="page">Registered Hosts</li>
                </ol>
            </nav>   
        </section>    
        <!--END OF BREADCRUMBS-->   
          
        <div class="form-row justify-content-center">
            <asp:TextBox ID="txtSearch" runat="server" class="form-control form-control-lg" placeholder="Search" style="width:80%;"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-info" OnClick="btnSearch_Click"/>
        </div>                 
                                                     
        <div class="pt-4">
            <table class="w-100 ">
                <tr class="text-center">
                    <th class="w-50" scope="col">Registered Hosts</th>
                    <th class="text-left w-10" scope="col">Background Status</th>
                    <th class="text-left w-10" scope="col">Account Status</th>
                </tr>

                <asp:Repeater id="regHostRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("accountName") %></td>
                            <td>
                                <asp:Button ID="btnUpdate" runat="server" class="btn btn-info" Text="Update Status" OnClick="btnUpdate_Click"
                                    CustomParameter='<%# Eval("accountID") %>'/>
                                <asp:Label ID="lblCompletedBC" runat="server" 
                                    Text='<%# Eval("backStatus") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="btnDelete" class="btn btn-danger" runat="server" Text="Deactivate Account"
                                    CustomParameter='<%# Eval("accountID") %>'
                                    OnClick="btnDelete_Click"/>
                            </td>
                        </tr>        
                    </ItemTemplate>
                </asp:Repeater>                 
            </table>
        </div>    
    </div>
</asp:Content>

