<%@ Control Language="c#" AutoEventWireup="true" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" Inherits="Training.BaseCore.Layouts.Containers.HeaderContainer" CodeBehind="basecore-container-header.ascx.cs" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="wrapper" id="headerWrapper">
    <div class="container" id="headerContainer">
        <a href="/">
            <sc:Image ID="Logo" Field="Site Logo" CssClass="logo" runat="server" />
        </a>
    
        <sc:Sublayout runat="server" Path="/layouts/basecore/site/basecore-navigation-main.ascx" />
        <sc:Sublayout runat="server" Path="/layouts/basecore/site/basecore-login-status.ascx" />
    </div>

</div>
