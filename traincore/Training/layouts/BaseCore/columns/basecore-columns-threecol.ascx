<%@ Control Language="c#" AutoEventWireup="true" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"  Inherits="Training.BaseCore.Layouts.Columns.ThreeColumn" Codebehind="basecore-columns-threecol.ascx.cs" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="sixteen columns" id="columnsWrapper">
    <div class="columnsInner">
        <h1><sc:Text ID="Text1" runat="server" Field="Page Heading"/></h1>
        <sc:Image Field="Page Image" runat="server"  CssClass="pageImage" />
    </div>
    <!-- Left -->
    <div class="four columns alpha  sidebar">
        <div class="columnsInner">
            <sc:Placeholder runat="server" ID="phLeftColumn" Key="LeftColumn"/>
        </div>
    </div>
    <!-- Middle -->
    <div class="eight columns"> 
        <div class="columnsInner">
            <sc:Placeholder Key="BeforeContent" runat="server" />
            <sc:Text ID="Text2" runat="server" Field="Page Content" />
            <sc:Placeholder Key="AfterContent" runat="server" />
        </div>
    </div>
    <!-- Right -->
    <div class="four columns omega sidebar">
        <div class="columnsInner">
            <sc:Placeholder runat="server" ID="phRightColumn" Key="RightColumn"/>       
        </div>
    </div>

</div>