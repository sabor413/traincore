<%@ Control Language="c#" AutoEventWireup="true" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"  Inherits="Training.BaseCore.Layouts.Columns.TwoColumn" Codebehind="basecore-columns-twocol.ascx.cs" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="sixteen columns" id="columnsWrapper">
    <div class="columnsInner">
        <h1><sc:Text ID="Text1" runat="server" Field="Page Heading"/></h1>
        <sc:Image Field="Page Image" runat="server" CssClass="pageImage" />
    </div>
    <!-- Left -->
    <div class="twelve columns alpha" id="leftColumn">
        <div class="columnsInner">
            <sc:Placeholder Key="BeforeContent" runat="server" />
            <sc:Text ID="Text2" runat="server" Field="Page Content" />
            <sc:Placeholder Key="AfterContent" runat="server" />
        </div>
    </div>
    <!-- Right -->
    <div class="four columns omega sidebar" id="rightColumn">
        <div class="columnsInner">
            <sc:Placeholder runat="server" Key="RightColumn"/>            
        </div>
    </div>
</div>