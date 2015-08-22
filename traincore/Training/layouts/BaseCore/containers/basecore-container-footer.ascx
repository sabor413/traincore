<%@ Control Language="c#" AutoEventWireup="true" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"  Inherits="Training.BaseCore.Layouts.Containers.FooterContainer" Codebehind="basecore-container-footer.ascx.cs" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ register TagPrefix="tc" Namespace=" Training.Controls.BaseCore" Assembly="Training.Controls" %>

<div class="wrapper" id="footerWrapper">
    <div class="container" id="footerContainer">
        <sc:Placeholder runat="server" Key="FooterContainer" />        
    </div>
</div>
<div class="wrapper" id="bottomWrapper">
    <div class="container" id="bottomContainer">
        <div class="eight columns">
            <sc:XslFile Path="/xsl/BaseCore/basecore-navigation-footer.xslt" Cacheable="true" runat="server" />
        </div>
        <div class="eight columns">
            <p class="copyright">Copyright &copy; Sitecore Ltd 1999 - 2012 (<asp:Literal ID="litDateTime" runat="server" />)</p>
            
            <tc:LanguageSwitcher runat="server" />
        </div>
    </div>
</div>