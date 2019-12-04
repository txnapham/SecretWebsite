<%@ Page Title="" Language="C#" MasterPageFile="~/TenantPage.master" AutoEventWireup="true" CodeFile="ViewLease.aspx.cs" Inherits="ViewLease" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
    <br />
    <br />
<p>Intent to lease</p>
<p>
    <asp:Label id="dateLabel" runat="server" Text="Date: "></asp:Label>
    <asp:TextBox ID="dateTxt" runat="server" readOnly="true"></asp:TextBox>
</p>
<p>&nbsp;</p>
<p>This letter of intent (letter of intent) sets forth the general terms of the proposal. The provisions of this <br />
    of intent shall serve as the basis for a lease agreement to be negotiated and entered into between the tenant and landlord (the lease).</p>
<p>&nbsp;</p>
<p>
    <asp:Label id="tenantName" runat="server" Text="Tenant Name: "></asp:Label>
    <asp:TextBox ID="tenantNametxt" runat="server" readOnly="true"></asp:TextBox>
</p>
<p>
    <asp:Label id="hostName" runat="server" Text="Landlord Name: "></asp:Label>
    <asp:TextBox ID="hostNametxt" runat="server" readOnly="true"></asp:TextBox>
</p>
<p>
    <asp:Label id="adressLabel" runat="server" Text="Property Adress: "></asp:Label>
    <asp:TextBox ID="adressTxt" runat="server" readOnly="true"></asp:TextBox>
    <asp:Label id="cityLabel" runat="server" Text="City: "></asp:Label>
    <asp:TextBox ID="cityTxt" runat="server" readOnly="true"></asp:TextBox>
    <asp:Label id="stateLabel" runat="server" Text="State: "></asp:Label>
    <asp:TextBox ID="stateTxt" runat="server" readOnly="true"></asp:TextBox>
</p>
<p><br /></p>
<p>A security deposit is required upon check in.</p>
<p><br /></p>
<p>By typing your name below you agree to the terms set forth above.</p>
<p></p>
<p>
    <asp:TextBox ID="sigTxt" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="sigValidator1" runat="server" ControlToValidate="sigTxt" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*</asp:RequiredFieldValidator>
</p>
<p>Tenant Sign Here</p>
<p>Send an executed copy of this intent to lease to the following link.</p>
<p><strong>Tenant</strong> shall be sent a stripe payment link to pay the first month&rsquo;s lease payment to the landlord.</p>
<p><strong>Landlord&rsquo;s</strong> will need to set up a stripe account using the following link</p>
<asp:Button id="submitBtn" text="Submit" runat="server" CssClass ="btn btn-info" OnClick="submitBtn_Click" CausesValidation="true"/>
    <p>*By hitting submit you intend to lease with the Landlord and associated property listed on this page*</p>
</asp:Content>

