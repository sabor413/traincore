<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="basecore_debug_information.ascx.cs" Inherits="Training.layouts.BaseCore.content.basecore_debug_information" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<h1>Debugging Information</h1>


<asp:Repeater runat="server" ID="DebugInformationRepeater" SelectMethod="GetData" ItemType="Training.Utilities.DebugInformation.Row">
    <HeaderTemplate>
        <table class="table">
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <th class="col-md-3">

                <asp:Repeater runat="server" DataSource="<%#Item.Header.Lines %>" ItemType="System.String">
                    <ItemTemplate>
                        <%#Item %><br />
                    </ItemTemplate>
                </asp:Repeater>
            </th>
            <td>
                <asp:Repeater runat="server" DataSource="<%#Item.Value.Lines %>" ItemType="System.String">
                    <ItemTemplate>
                        <%#Item %><br />
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
    </ItemTemplate>

    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
