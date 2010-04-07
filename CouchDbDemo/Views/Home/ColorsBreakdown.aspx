<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<CouchDbDemo.Shared.Clothes.ClothingColor>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Colors Breakdown
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Colors Breakdown</h2>
    <table>
        <tr>
            <th>
                Color
            </th>
            <th>
                Count
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%= Html.Encode(item.Color) %>
            </td>
            <td>
                <%= Html.Encode(item.Count) %>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%= Html.ActionLink("Back to Index","Index") %>
    </p>
</asp:Content>
