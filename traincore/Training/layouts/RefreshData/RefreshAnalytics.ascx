<%@ Control Language="C#" AutoEventWireup="true" 
    CodeBehind="RefreshAnalytics.ascx.cs" 
    Inherits="Training.layouts.RefreshData.RefreshAnalytics" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div>
    <asp:Button ID="btnRefresh" CssClass="RefreshData" Text="Refresh" OnClick="btnRefresh_Click" runat="server" />
    <span class="spMessage <%=Training.layouts.RefreshData.RefreshAnalytics.ClassName %>"><%= Sitecore.Globalization.Translate.Text("WordRefresh") %> <%= Sitecore.Globalization.Translate.Text("WordComplete") %>!</span>
</div>