<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RelatedArticles.ascx.cs" Inherits="Training.layouts.BaseCore.content.RelatedArticles" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="four columns">
    <div class="chunk widget <%= CssClass %>">
        <h3>
        Related articles
        </h3>
              
              <asp:Repeater ID="rpArticles" ItemType="Sitecore.Data.Items.Item" runat="server">
                     <HeaderTemplate>
                           <ul class="relatedArticles">
                     </HeaderTemplate>
                     <ItemTemplate>
                           <li><a href="<%#: Sitecore.Links.LinkManager.GetItemUrl(Item) %>">
                    <sc:Text ID="Text1" Field="Page Heading" DataSource="<%#: Item.ID %>" runat="server" /></a></li>
                     </ItemTemplate>
                     <FooterTemplate>
                           </ul>
                     </FooterTemplate>
              </asp:Repeater>
       </div>
</div>