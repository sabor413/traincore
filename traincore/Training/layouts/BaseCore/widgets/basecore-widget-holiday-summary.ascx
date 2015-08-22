<%@ Control Language="c#" AutoEventWireup="True" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"  Inherits="Training.BaseCore.Layouts.Widgets.WidgetHolidaySummary" Codebehind="basecore-widget-holiday-summary.ascx.cs" %>
<%@ register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="columns eight">
    <div class="widget holidaySummary <%= Class %>">
        <%= HeadingPrefix %>
        <sc:Text Field="Holiday Summary" ID="SummaryHeading" runat="server" />
        <%= HeadingSuffix %>
        <sc:EditFrame Buttons="/sitecore/content/Applications/WebEdit/Edit Frame Buttons/Terrain" runat="server" Title="Terrain" >
        <dl>
            <dt><%= Sitecore.Globalization.Translate.Text("Difficulty") %>:</dt>
            <dd><sc:Text ID="txtDifficulty" DisableWebEditing="true" Field="Text" runat="server" /></dd>

            <dt><%= Sitecore.Globalization.Translate.Text("Type") %>:</dt>
            <dd><sc:Text ID="txtType" DisableWebEditing="true" Field="Text" runat="server" /></dd>
        
            <dt><%= Sitecore.Globalization.Translate.Text("Terrain") %>:</dt>
            <dd><asp:Literal ID="litTerrain" runat="server" /></dd>
        </dl>
        </sc:EditFrame>
    </div>
    </div>