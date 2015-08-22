<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="basecore-search-results.ascx.cs" Inherits=" Training.BaseCore.Layouts.Search.SearchResults" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Register TagPrefix="tc" Namespace=" Training.Controls.BaseCore" Assembly="Training.Controls" %>

<asp:Repeater ID="rpHolidays" ItemType="Training.Utilities.BaseCore.Search.SitecoreItem" runat="server">
    <ItemTemplate>
        <div class="sectionItem searchResult">
            <sc:EditFrame Buttons="/sitecore/content/Applications/WebEdit/Edit Frame Buttons/BaseCore-HolidayEdit" DataSource="<%# Item.ItemId.ToString() %>" runat="server">
            <a href="<%#: Item.Url %>">
                <h2><%#: Item.PageHeading %></h2>
                <%# String.IsNullOrEmpty(Item.SummaryImage) ? FallbackHolidayImage  : Item.SummaryImage %>
            </a>
            <div class="searchResultInner">
                <%# Item.SummaryComputed %>

                    <a href="<%#: Item.Url %>?json=true" data-target="detailsText-<%#: Container.ItemIndex + 1 %>" class="details closed"><%# Sitecore.Globalization.Translate.Text("MoreDetails") %></a>
                    <a href="<%#: Item.Url %>" class="button bookButton ">
                        <%# Sitecore.Globalization.Translate.Text("BookPlace") %>
                    </a>

                <div class="detailsText-<%#: Container.ItemIndex + 1 %> detailsText">
                </div>
            </div>
        </div>
        </sc:EditFrame>
    </ItemTemplate>
</asp:Repeater>

<tc:Paginator ID="pgPagination" runat="server" />

<asp:Panel runat="server" ID="NoResultsPanel" Visible ="false">
    <asp:Literal runat="server" Text="There were no results but you can try one of our popular searches:" ID="litNoResultsMessage" /><br />
    <asp:Repeater runat="server" ItemType="System.String" ID="rpNoResults" OnItemCommand="rpNoResults_ItemCommand">
        <ItemTemplate>
            <asp:LinkButton runat="server" CommandArgument="<%#:Item %>" Text="<%#:Item %>" />
        </ItemTemplate>
    </asp:Repeater>
</asp:Panel>
