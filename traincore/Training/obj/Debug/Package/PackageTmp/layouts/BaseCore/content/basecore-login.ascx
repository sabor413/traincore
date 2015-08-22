<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="basecore_login.ascx.cs" Inherits="Training.layouts.BaseCore.content.basecore_login" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<%--<asp:Login runat="server" id="LoginControl" OnAuthenticate="LoginControl_OnAuthenticate" />--%>

<div class="searchForm">
    <div class="searchFormRow">
        <asp:Label runat="server" ID="UserNameLabel">User</asp:Label>
        <asp:TextBox runat="server" ID="UserTextBox"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="error" runat="server" ControlToValidate="UserTextBox" ID="UserRequiredFieldValidator" ErrorMessage="Need to input a user name" />
    </div>

    <div class="searchFormRow">
        <asp:Label runat="server" ID="PasswordLabel">Password</asp:Label>
        <asp:TextBox runat="server" ID="PasswordTextBox" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="error" runat="server" ControlToValidate="PasswordTextBox" ID="PasswordRequiredFieldValidator" ErrorMessage="Need to enter your password" />
        <asp:CustomValidator runat="server" ErrorMessage="Wrong user name or password" ID="CustomValidator" CssClass="error"/>
    </div>
  
    <div class="searchFormRow">
        
        <asp:Button ID="SubmitButton" runat="server" Text="Log in" OnClick="SubmitButton_OnClick" />
    </div>
</div>
