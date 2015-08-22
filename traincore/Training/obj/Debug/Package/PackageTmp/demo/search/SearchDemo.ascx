<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchDemo.ascx.cs" Inherits="Training.demo.search.SearchDemo" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<asp:Label ID="lblTotalSrch" runat="server" Text=""></asp:Label>
<br /><br />
<asp:Label ID="lblFacet" runat="server" Text=""></asp:Label>
<br /><br />
<div class="four columns">
    <div class="chunk widget">
        <h3>
        Search Demo Results
        </h3> 
              <asp:Repeater ID="rpSearchDemo" ItemType="Sitecore.ContentSearch.SearchTypes.SearchResultItem" runat="server">
                     <HeaderTemplate>
                           <table>
                               <tr>
                                   <th>Item Name</th>
                                   <th>Item ID</th>
                               </tr> 
                     </HeaderTemplate>
                     <ItemTemplate>
                              <tr>
                                   <td><%#: Item.Name %></td>
                                   <td><%#: Item.ItemId.ToString() %></td>
                              </tr>
                     </ItemTemplate>
                     <FooterTemplate>
                           </table>
                     </FooterTemplate>
              </asp:Repeater>
       </div>
</div>
<br />
<div>
    <table border="1">
        <tr>
            <th>Description</th>
            <th>Button</th>
        </tr>
        <tr>
            <td>Search Demo A (All web index)</td>
            <td><asp:Button Text="Demo A" runat="server" OnClick="DemoA_Click" /></td>
        </tr>
        <tr>
            <td>Search Demo B (Page Method)</td>
            <td><asp:Button Text="Demo B" runat="server" OnClick="DemoB_Click" /></td>
        </tr>
        <tr>
            <td>Search Demo C (Path Method)</td>
            <td><asp:Button Text="Demo C" runat="server" OnClick="DemoC_Click" /></td>
        </tr>
        <tr>
            <td>Search Demo D (Name "Bike" Search)</td>
            <td><asp:Button Text="Demo D" runat="server" OnClick="DemoD_Click" /></td>
        </tr>
        <tr>
            <td>Search Demo E (Page Heading Search)</td>
            <td><asp:Button Text="Demo E" runat="server" OnClick="DemoE_Click" /></td>
        </tr>
        <tr>
            <td>Search Demo F (Custom Search Class)</td>
            <td><asp:Button Text="Demo F" runat="server" OnClick="DemoF_Click" /></td>
        </tr>
        <tr>
            <td>Search Demo G (GetResults method)</td>
            <td><asp:Button Text="Demo G" runat="server" OnClick="DemoG_Click" /></td>
        </tr>
        <tr>
            <td>Search Demo H (Faceting)</td>
            <td><asp:Button Text="Demo H" runat="server" OnClick="DemoH_Click" /></td>
        </tr> 
    </table>
</div>