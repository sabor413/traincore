<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="basecore-poll-widget.ascx.cs" Inherits="Training.layouts.BaseCore.widgets.basecore_poll_widget" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="widget poll">
    <h3><sc:Text runat="server" Field="Question" /></h3>

    <asp:RadioButtonList runat="server" ID="AnswersList" DataValueField="Value" DataTextField="Text"/>

    <asp:Button runat="server" ID="Submit" OnClick="Submit_Click" Text="Submit"/>

    <asp:Literal runat="server" ID="ThankYouLiteral" Visible="false">Thank you for answering the poll</asp:Literal>
</div>