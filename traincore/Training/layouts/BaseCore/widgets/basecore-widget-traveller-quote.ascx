<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="basecore-widget-traveller-quote.ascx.cs" Inherits="Training.layouts.BaseCore.widgets.basecore_widget_traveller_quote" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="TQuote">
<p class="QText"><sc:Text Field ="Quote" ID="TravellerQuote" runat="server" /></p>
<p class="QAuthor"> — <sc:Text  Field ="Quote Author" ID="QuoteAuthor" runat="server" /></p>
</div>