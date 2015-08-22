<%@ Control Language="c#" AutoEventWireup="true" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"  Inherits="Training.BaseCore.Layouts.Containers.GalleryContainer" Codebehind="basecore-container-gallery.ascx.cs" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div id="galleryWrapper" class="wrapper <%= Class %>">
    <div id="galleryContainer" class="container">
        <sc:Placeholder Key="GalleryContainer" runat="server" />
    </div>
</div>