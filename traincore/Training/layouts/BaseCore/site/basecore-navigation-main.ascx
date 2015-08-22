<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="basecore_navigation_main.ascx.cs" Inherits="Training.layouts.BaseCore.site.basecore_navigation_main" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<ul class="navigation">
    <asp:Repeater ID="NavigationRepeater" runat="server" SelectMethod="GetData_NavigationRepeater">
        <ItemTemplate>
            <li><a href="<%#Eval("Link") %>" class="<%#Eval("Class") %>"><%#Eval("Text")%></a></li>
        </ItemTemplate>
        
    </asp:Repeater>

    <li>
        <asp:TextBox runat="server" ID="SearchBox" />
        <asp:Button Placeholder="Search for a holiday" runat="server" ID="SearchButton" OnClick="SearchButton_Click" Text="search"/>
    </li>
</ul>
