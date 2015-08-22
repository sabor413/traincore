<%@ Control Language="c#" AutoEventWireup="True" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"  Inherits="Training.BaseCore.Layouts.Print.HolidayPrint" Codebehind="basecore-print-holiday.ascx.cs" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ import Namespace="Training.Utilities.BaseCore.Extensions" %>

<sc:FieldRenderer FieldName="Page Heading" ID="PageHeading" EnclosingTag="h2" runat="server" />
<asp:Repeater ID="rpDays" runat="server">
    <HeaderTemplate>
    </HeaderTemplate>
    <ItemTemplate>
        <h3><a href="<%# Sitecore.Links.LinkManager.GetItemUrl(Container.DataItem as Sitecore.Data.Items.Item) %>"><%# Training.Utilities.BaseCore.Holidays.HolidayUtils.GetHolidayDateRange(Container.DataItem as Sitecore.Data.Items.Item).StartDate.FormattedDate() %> &mdash; <%# Training.Utilities.BaseCore.Holidays.HolidayUtils.GetHolidayDateRange(Container.DataItem as Sitecore.Data.Items.Item).EndDate.FormattedDate() %></a></h3>
        <ul>
            <li>
                <%# Sitecore.Globalization.Translate.Text("TotalSpaces") %>:
                <%# FieldRenderer.Render(Container.DataItem as Sitecore.Data.Items.Item, "Maximum Participants") %>
            </li>
            <li>
                <%# Sitecore.Globalization.Translate.Text("SpacesRemaining") %>:
                <%# Training.Utilities.BaseCore.Holidays.HolidayUtils.GetHolidayDateSpaces(Container.DataItem as Sitecore.Data.Items.Item) %>
            </li>
        </ul>
    </ItemTemplate>
    <FooterTemplate>
    </FooterTemplate>
</asp:Repeater>

<sc:FieldRenderer FieldName="Holiday Summary" ID="SummaryHeading" EnclosingTag="h2" runat="server" />

<ul>
    <li><%= Sitecore.Globalization.Translate.Text("Difficulty") %>: <sc:Text ID="txtDifficulty" Field="Text" runat="server" /></li>
    <li><%= Sitecore.Globalization.Translate.Text("Type") %>: <sc:Text ID="txtType" Field="Text" runat="server" /></li>
    <li><%= Sitecore.Globalization.Translate.Text("Terrain") %>: <asp:Literal ID="litTerrain" runat="server" /></li>
</ul>