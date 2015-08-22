<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="basecore_login_status.ascx.cs" Inherits="Training.layouts.BaseCore.site.basecore_login_status" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="loginInfo">
    <asp:Literal runat="server" ID="LoginStatusLiteral"></asp:Literal>
    <asp:LinkButton runat="server" ID="LogLink" OnClick="LogLink_Click">Login</asp:LinkButton>
</div>
