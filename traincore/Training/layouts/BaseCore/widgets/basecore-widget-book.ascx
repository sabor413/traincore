<%@ Control Language="c#" AutoEventWireup="True" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"  Inherits="Training.BaseCore.Layouts.Widgets.WidgetBook" Codebehind="basecore-widget-book.ascx.cs" %>
<%@ register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ import Namespace="Training.Utilities.BaseCore.Extensions" %>

<div class="widget book <%= Class %>">
    <%= HeadingPrefix %>
    <sc:Text Field="Page Heading" ID="PageHeading" runat="server" />
    <%= HeadingSuffix %>

    <asp:Panel Visible="false" ID="NoHolidays" runat="server">
        <p><%= Sitecore.Globalization.Translate.Text("NoHolidayDates") %></p>
    </asp:Panel>
    <asp:Repeater ID="rpDays" runat="server" OnItemDataBound="HolidayDates_ItemDataBound">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <h3><a href="<%# Sitecore.Links.LinkManager.GetItemUrl(Container.DataItem as Sitecore.Data.Items.Item) %>"><%# Training.Utilities.BaseCore.Holidays.HolidayUtils.GetHolidayDateRange(Container.DataItem as Sitecore.Data.Items.Item).StartDate.FormattedDate() %> &mdash; <%# Training.Utilities.BaseCore.Holidays.HolidayUtils.GetHolidayDateRange(Container.DataItem as Sitecore.Data.Items.Item).EndDate.FormattedDate() %></a></h3>
            <dl>
                <dt><%# Sitecore.Globalization.Translate.Text("TotalSpaces") %>:</dt> 
                <dd><%# FieldRenderer.Render(Container.DataItem as Sitecore.Data.Items.Item, "Maximum Participants") %></dd>
                <dt><%# Sitecore.Globalization.Translate.Text("SpacesRemaining") %>:</dt>
                <dd><%# Training.Utilities.BaseCore.Holidays.HolidayUtils.GetHolidayDateSpaces(Container.DataItem as Sitecore.Data.Items.Item) %></dd>
            </dl>
            <asp:HyperLink ID="hlBook" runat="server" Text='<%# Sitecore.Globalization.Translate.Text("ButtonBookHoliday") %>' CssClass="button" />
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
</div>