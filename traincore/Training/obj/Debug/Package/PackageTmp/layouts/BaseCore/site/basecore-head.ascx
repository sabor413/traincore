<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="basecore-head.ascx.cs" Inherits="Training.BaseCore.Layouts.Site.Head" %>

<!--[if lt IE 7 ]><html class="ie ie6"> <![endif]-->
<!--[if IE 7 ]><html class="ie ie7"> <![endif]-->
<!--[if IE 8 ]><html class="ie ie8"> <![endif]-->
<!--[if (gte IE 9)|!(IE)]><!--><html> <!--<![endif]-->
<head>
    <!-- Basic Page Needs
    ================================================== -->
    <meta charset="utf-8" />
    <title><sc:FieldRenderer FieldName="Page Title" DisableWebEditing="true" runat="server" /></title>
    <meta name="description" content="<%= MetaDescription %>" />
    <meta name="author" content="" />

    <!-- Mobile Specific Metas
    ================================================== -->
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />

    <!-- CSS and Javascript
    ================================================== -->

    <link rel="stylesheet" href="/css/base.css" /> 
    <link rel="stylesheet" href="/css/skeleton.css" />
    <link rel="stylesheet" href="/css/layout.css" />
    <link rel="stylesheet" href="/css/style.css" />
    <link rel="stylesheet" href="/css/lib/formalize.css" />
    <asp:Panel ID="ResponsiveDesign" Visible="false" runat="server">
        <link rel="stylesheet" href="/css/responsive.css" />
    </asp:Panel>
    <!-- Favicons
    ================================================== -->
    <link rel="shortcut icon" href="/img/favicon.ico" />
    <link rel="apple-touch-icon" href="/img/apple-touch-icon.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="/img/apple-touch-icon-72x72.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="/img/apple-touch-icon-114x114.png" />

     <sc:VisitorIdentification ID="VisitorIdentification" runat="server" />
</head>
