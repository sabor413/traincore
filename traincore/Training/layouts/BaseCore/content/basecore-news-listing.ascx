<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="basecore-news-listing.ascx.cs" Inherits="Training.BaseCore.Layouts.Content.NewsListing" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<asp:Repeater ID="rpNewsListing" runat="server">
    <HeaderTemplate>
        <div class="newsListing">
    </HeaderTemplate>
    <ItemTemplate>
        <h2><a href="<%# Sitecore.Links.LinkManager.GetItemUrl(Container.DataItem as Sitecore.Data.Items.Item) %>"><sc:Text Field="Page Heading" Item="<%# Container.DataItem as Sitecore.Data.Items.Item %>" runat="server" /></a></h2>
        <sc:Text Field="Page Summary" Item="<%# Container.DataItem as Sitecore.Data.Items.Item %>" runat="server" />
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>