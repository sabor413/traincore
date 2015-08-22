<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="basecore-search-form.ascx.cs" Inherits=" Training.BaseCore.Layouts.Search.SearchForm" %>

<div class="searchForm">
    <div class="searchFormRow">
    <asp:Label ID="lblSearchText" AssociatedControlID="txtSearchText" runat="server" />
        <asp:TextBox ID="txtSearchText" runat="server" />
        </div>
    <div class="searchFormRow">
        <div class="searchFormColumn">
            <asp:Label ID="lblTerrain" runat="server" AssociatedControlID="ddlTerrain"/>
                <asp:DropDownList ID="ddlTerrain" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
        </div>
        <div class="searchFormColumn">
            <asp:Label ID="lblHoliday" runat="server" AssociatedControlID="ddlHolidayType" />
                <asp:DropDownList ID="ddlHolidayType" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
        </div>
    </div>
    <div class="searchFormRow">
        <asp:Button runat="server" ID="Search" OnClick="Search_Click" Text="Find my holiday" />
    </div>
</div>