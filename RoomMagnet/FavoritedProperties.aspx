<%@ Page Title="" Language="C#" MasterPageFile="~/TenantPage.master" AutoEventWireup="true" CodeFile="FavoritedProperties.aspx.cs" Inherits="FavoritedProperties" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>RoomMagnet | Favorited Properties</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <script>
        function favoriteBtn(propertyID, city, state, priceLow, priceHigh) {
            PageMethods.MiddleMan(propertyID, city, state, priceLow, priceHigh);
        };
    </script>

    <div class="container-fluid mt-5 px-5">

        <!--BREADCRUMBS-->
        <section>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="TenantDashboard.aspx" class="breadLink">Dashboard</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Favorited Properties</li>
                </ol>
            </nav>
        </section>
        <!--END OF BREADCRUMBS-->

        <div class="pl-3">
            <h3>Favorited Properties</h3>
        </div>

        <section>
            <div class="row px-3 py-3">
                <asp:Literal ID="Card3" runat="server" Mode="Transform"></asp:Literal>
            </div>
        </section>


    </div>
</asp:Content>

