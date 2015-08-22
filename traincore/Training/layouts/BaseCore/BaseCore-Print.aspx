<%@ Page language="c#" Codepage="65001" AutoEventWireup="true" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ OutputCache Location="None" VaryByParam="none" %>

<!DOCTYPE html>
<!--[if lt IE 7 ]><html class="ie ie6" lang="en"> <![endif]-->
<!--[if IE 7 ]><html class="ie ie7" lang="en"> <![endif]-->
<!--[if IE 8 ]><html class="ie ie8" lang="en"> <![endif]-->
<!--[if (gte IE 9)|!(IE)]><!--><html lang="en"> <!--<![endif]-->
<head>

    <!-- Basic Page Needs
    ================================================== -->
    <meta charset="utf-8" />
    <title><sc:FieldRenderer FieldName="Page Title" DisableWebEditing="true" runat="server" /></title>
    <meta name="description" content="<sc:FieldRenderer FieldName="Meta Description" DisableWebEditing="true" runat="server" />" />

    <!-- Mobile Specific Metas
    ================================================== -->
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />

</head>
<body>
    <form method="post" runat="server" id="mainform">                 
        <sc:FieldRenderer FieldName="Page Heading" EnclosingTag="h1" runat="server" />
        <sc:FieldRenderer FieldName="Page Content" runat="server" />

        <sc:Placeholder runat="server" ID="phMain" Key="Main"/>
    </form>
</body>
</html>