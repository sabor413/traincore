<%@ Page language="c#" Codepage="65001" AutoEventWireup="true" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ OutputCache Location="None" VaryByParam="none" %>

<!DOCTYPE html>
<html lang="<%= Sitecore.Context.Language.CultureInfo.TwoLetterISOLanguageName %>">

<!-- Site <head> -->
<sc:Sublayout ID="Sublayout1" Path="/layouts/BaseCore/site/basecore-head.ascx" runat="server" />
<!-- Site <body> -->
<sc:Sublayout ID="Sublayout2" Path="/layouts/BaseCore/site/basecore-body.ascx" runat="server" />