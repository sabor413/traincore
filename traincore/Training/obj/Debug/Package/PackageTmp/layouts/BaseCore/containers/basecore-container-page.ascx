<%@ Control Language="c#" AutoEventWireup="true" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"  Inherits="Training.BaseCore.Layouts.Containers.PageContainer" Codebehind="basecore-container-page.ascx.cs" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="wrapper" id="pageWrapper">
    <div class="container" id="pageContainer">
        <sc:Placeholder runat="server" Key="PageContainer" />
        <asp:PlaceHolder ID="phPrint" Visible="false" runat="server">
            <div class="columns sixteen">
                <p class="print">
                    <a href="?<%= Training.Utilities.BaseCore.References.DeviceReferences.Print.QueryString %>">
                        <%= Sitecore.Globalization.Translate.Text("PrintPage") %>
                    </a>
                </p>
            </div>
        </asp:PlaceHolder>
    </div>
</div>