﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HostCreateAccount.aspx.cs" Inherits="HostCreateAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>RoomMagnet | Create Account</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid ">

        <!--BEGINNING OF CREATE ACCOUNT FORM-->

        <div class="row ">
            <div class="col-md-6">

                <div class="col-md-12  creatAccountWelcome">
                    <h2>Welcome to roommagnet!</h2>
                </div>

                    <div class="form-group">

                        <asp:RequiredFieldValidator ID="fnReqFieldValidator" Display ="Dynamic" runat="server" ErrorMessage="Please enter a first name" Text="*Please enter a first name" ControlToValidate="txtFN" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="fnLettersValidator" Display="Dynamic" runat="server" ErrorMessage="Please enter a valid first name" Text="*Please enter a valid first name" ControlToValidate="txtFN" ValidationExpression="^[a-zA-Z-_ ]+$" ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtFN" runat="server" class="form-control form-control-lg" aria-describedby="FirstName" placeholder="First Name" MaxLength="50"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:RegularExpressionValidator ID="mnLetters" Display="Dynamic" runat="server" ErrorMessage="Please enter a valid middle name" Text="*Please enter a valid middle name" ControlToValidate="txtMN" ValidationExpression="^[a-zA-Z-_ ]+$" ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtMN" runat="server" class="form-control form-control-lg" aria-describedby="MiddleName" placeholder="Middle Name" MaxLength="50"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:RequiredFieldValidator ID="lnReqFieldValidator" Display ="Dynamic" runat="server" ErrorMessage="Please enter a last name." ControlToValidate="txtLN" Text="*Please enter a last name"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="lnLetters" Display="Dynamic" runat="server" ErrorMessage="Please enter a valid last name" Text="*Please enter a valid last name" ControlToValidate="txtLN" ValidationExpression="^[a-zA-Z-_ ]+$" ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtLN" runat="server" class="form-control form-control-lg" aria-describedby="LastName" placeholder="Last Name" MaxLength="50"></asp:TextBox>
                    </div>

                    <div class=" form-group">

<%--                            <input type="date" name="bDay" class="from-control form-control-lg">--%>
<%--                        <asp:RequiredFieldValidator ID="bdayReqFieldValidator" Display ="Dynamic" runat="server" ErrorMessage="Please enter a birth date." ControlToValidate="txtBday" Text="*Please enter a birth date"></asp:RequiredFieldValidator>--%>
                        <asp:TextBox type="date" ID="txtBday" runat="server" class="form-control form-control-lg" placeholder="Birthdate (MM/DD/YYYY)" MaxLength="10"></asp:TextBox>
<%--                    <asp:RegularExpressionValidator ID="realBday" Display="Dynamic" runat="server" ValidationExpression="^(?:(?:(?:0?[13578]|1[02])(\/|-|\.)31)\1|(?:(?:0?[1,3-9]|1[0-2])(\/|-|\.)(?:29|30)\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:0?2(\/|-|\.)29\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:(?:0?[1-9])|(?:1[0-2]))(\/|-|\.)(?:0?[1-9]|1\d|2[0-8])\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$" ControlToValidate="txtBday" ErrorMessage="*Invalid Date<br/>"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="bdayDateValidator" Display="Dynamic" runat="server" ValidationExpression="^\d{1,2}\-\d{1,2}\-\d{4}$" ControlToValidate="txtBday" ErrorMessage="*Invalid Date Input (MM-DD-YYYY)<br/>"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="bdayCharValidator" Display="Dynamic" runat="server" ErrorMessage="Please enter a valid birth date (MM-DD-YYYY)<br/>" Text="*Please enter a valid birth date" ControlToValidate="txtBday" ValidationExpression="^[0-9-]+$"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="bdayReqFieldValidator" Display ="Dynamic" runat="server" ErrorMessage="Please enter a birth date." ControlToValidate="txtBday" Text="*Please enter a birth date"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtBday" runat="server" class="form-control form-control-lg" placeholder="Birthdate (MM-DD-YYYY)" MaxLength="10"></asp:TextBox> --%>
                        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>

                    </div>
                    <div class="form-group">
                        <asp:RegularExpressionValidator ID="houseNumValidatorNumbers" Display="Dynamic" runat="server" ErrorMessage="Please enter a valid house number" Text="*Please enter a valid house number" ControlToValidate="txtHouseNum" ValidationExpression="^[0-9]+$" ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="houseNumReqField" Display ="Dynamic" runat="server" ErrorMessage="Please enter a house number." ControlToValidate="txtHouseNum" Text="*Please enter a house number" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtHouseNum" runat="server" class="form-control form-control-lg" placeholder="House Number" MaxLength="10"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:RequiredFieldValidator ID="streetReqFieldValidator" Display ="Dynamic" runat="server" ErrorMessage="Please enter a street." ControlToValidate="txtStreet" Text="*Please enter a street" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="streetLetters" Display="Dynamic" runat="server" ErrorMessage="Please enter a valid street name" Text="*Please enter a valid street name" ControlToValidate="txtStreet" ValidationExpression="^[0-9a-zA-Z_ -]+$" ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtStreet" runat="server" class="form-control form-control-lg" placeholder="Street" MaxLength="30"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:RequiredFieldValidator ID="cityReqFieldValidator" Display ="Dynamic" runat="server" ErrorMessage="Please enter a city." ControlToValidate="txtCity" Text="*Please enter a city" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="cityLetters" Display="Dynamic" runat="server" ErrorMessage="Please enter a valid city name" Text="*Please enter a valid city name" ControlToValidate="txtCity" ValidationExpression="^[a-zA-Z_ ]+$" ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtCity" runat="server" class="form-control form-control-lg" placeholder="City" MaxLength="30"></asp:TextBox>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-4">
                            <asp:RequiredFieldValidator ID="stateReqFieldValidator" Display ="Dynamic" runat="server" ErrorMessage="Please select a state." ControlToValidate="ddState" Text="*Please select a state" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddState" runat="server" class="form-control  form-control-lg">
                                <asp:ListItem Value="">State</asp:ListItem>
                                <asp:ListItem>AL</asp:ListItem>
                                <asp:ListItem>AK</asp:ListItem>
                                <asp:ListItem>AZ</asp:ListItem>
                                <asp:ListItem>AR</asp:ListItem>
                                <asp:ListItem>CA</asp:ListItem>
                                <asp:ListItem>CO</asp:ListItem>
                                <asp:ListItem>CT</asp:ListItem>
                                <asp:ListItem>DC</asp:ListItem>
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

                        <div class="form-group col-md-6">
                            <asp:RequiredFieldValidator ID="zipReqFieldValidator" Display ="Dynamic" runat="server" ErrorMessage="Please enter a zip code." ControlToValidate="txtZip" Text="*Please enter a zip code" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="zipNumValidator" Display="Dynamic" runat="server" ErrorMessage="Please enter a valid zip code" Text="*Please enter a valid zip code" ControlToValidate="txtZip" ValidationExpression="^[0-9]+$" ForeColor="Red"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="txtZip" runat="server" class="form-control form-control-lg" placeholder="Zip" MaxLength="9"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-2">
                            <asp:RequiredFieldValidator ID="ddCountryValidator" Display ="Dynamic" runat="server" ErrorMessage="Please enter a country." ControlToValidate="ddCountry" Text="*Please enter a country" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddCountry" runat="server" class="form-control  form-control-lg">
                                <asp:ListItem Value="US">US</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <small id="addressDisclosure" class="form-text text-muted">*We will never share your address until you begin the lease process.</small>
                    </div>

                    <div class="form-group">
                        <asp:RequiredFieldValidator ID="phoneReqField" Display ="Dynamic" runat="server" ErrorMessage="Please enter a phone number." ControlToValidate="txtPhone" Text="*Please enter a phone number" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="phoneNumberValidation" Display="Dynamic" runat="server" ErrorMessage="Please enter a valid phone number" Text="*Please enter a valid phone number" ControlToValidate="txtPhone" ValidationExpression="^[0-9-]+$" ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtPhone" runat="server" class="form-control form-control-lg" placeholder="Phone Number (XXX-XXX-XXXX)" MaxLength="20"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:RegularExpressionValidator ID="regexEmailValid" Display="Dynamic" runat="server" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="emailReqFieldValidator" Display ="Dynamic" runat="server" ErrorMessage="Please enter an email." ControlToValidate="txtEmail" Text="*Please enter an email" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtEmail" runat="server" class="form-control form-control-lg" aria-describedby="emailHelp" placeholder="Email" MaxLength="50"></asp:TextBox>
                        <small id="emailHelp" class="form-text text-muted">*We will never share your email with anyone else.</small>
                    </div>

                    <div class="form-group">
                        <asp:RegularExpressionValidator ID="passwordValidator" Display="Dynamic" runat="server" ErrorMessage="Please enter a valid password" Text="*Please enter a password (8-15 characters) with at least 1 uppercase, 1 lowercase, 1 number, and 1 special character (example: !#&%) " ControlToValidate="txtPassword" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$" ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="passwordReqField" Display ="Dynamic" runat="server" ErrorMessage="Please enter a password." ControlToValidate="txtPassword" Text="*Please enter a password" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtPassword" runat="server" class="form-control form-control-lg" placeholder="Password" TextMode="Password" MaxLength="256"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ErrorMessage="Re-Enter password" ControlToValidate="txtConPass" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" Display="Dynamic" runat="server" ErrorMessage="Passwords do no match" ControlToValidate="txtConPass" ControlToCompare="txtPassword" ForeColor="Red"></asp:CompareValidator>
                        <asp:TextBox ID="txtConPass" runat="server" class="form-control form-control-lg" placeholder="Re-Enter Password" TextMode="Password" MaxLength="256"></asp:TextBox>
                    </div>

                   <%-- <div class="form-group form-check">
                        <asp:CheckBox ID="cbBackCheck" runat="server" class="form-check-input" />
                        <label class="form-check-label" for="exampleCheck1">Perform background check now</label>
                    </div>--%>

                    <div class="form-group form-check">
                        <asp:CustomValidator ID="cbAgreementValidator" runat="server" Display="Dynamic" ErrorMessage="*Please accept the terms and conditions</br>" ClientValidationFunction="validateTerms" ForeColor="Red"></asp:CustomValidator>
                        <asp:CheckBox ID="cbAgreement" runat="server" class="form-check-input" />
                        <label class="form-check-label" for="exampleCheck1">Agreement to Terms &amp; Conditions</label>
                    </div>
                    <%--<a class="btn btn-info" id="createAccountButton" href="create-account-categories.html">Create Account</a>--%>
                    <asp:Button ID="btnCreateAccount" runat="server" Text="Create Account" class="btn btn-info" OnClick="btnCreateAccount_Click" />
            </div>

            <div class="col-md-6 createAccountSIDEImage"></div>

        </div>

    </div>
    <script>
        function validateTerms(source, arguments) {
            var $c = $('#<%= cbAgreement.ClientID %>');
            if($c.prop("checked")){
                arguments.IsValid = true;
            } else {
                arguments.IsValid = false;
            }
        }
    </script>
</asp:Content>

