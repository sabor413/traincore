<%@ Control Language="c#" AutoEventWireup="true" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"  Inherits="Training.BaseCore.Layouts.Widgets.GeneralWidget" Codebehind="basecore-widget.ascx.cs" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="<%= WidthClass %>">
    <div class="widget <%= Class %>">
        <%= HeadingPrefix %>
        <sc:Text Field="Widget Heading" ID="WidgetHeading" runat="server" />
        <%= HeadingSuffix %>
        <sc:Image Field="Widget Image" MaxWidth="440" ID="WidgetImage" runat="server" />
        <sc:FieldRenderer EnclosingTag="p" FieldName="Widget Content" ID="WidgetText" runat="server" />
        <sc:FieldRenderer EnclosingTag="p" FieldName="Widget Link" ID="WidgetLink" runat="server" />
    </div>
</div>