<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="basecore-body.ascx.cs" Inherits="Training.BaseCore.Layouts.Site.Body" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<form method="post" runat="server" id="mainform">
    <body>
    <sc:Placeholder runat="server" ID="phMain" Key="Main"/>                      

    <!-- libraries -->	
    <script src="/Scripts/jquery-2.1.0.min.js"></script>
    <script type="text/javascript">
        var $j = jQuery.noConflict();
        $j(document).ready(function () {
        });
    </script>
    <script src="/js/lib/slides.min.jquery.js"></script>
    <script src="/js/lib/jquery.browser.min.js"></script>
    <script src="/Scripts/formalizeme/jquery.formalize.min.js"></script>
    <script src="/Scripts/jquery.validate.min.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.validation.net.webforms.min.js"></script>

    <!-- /libraries -->
     
    <script type="text/javascript" src="/js/basecore-main.js"></script>

    <!--[if lt IE 9]>
	    <script src="http://html5shim.googlecode.com/svn/trunk/html5.js" /></script>
    <![endif]-->
    </body>
</form>
    