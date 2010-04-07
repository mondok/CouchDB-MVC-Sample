<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ClothingTypeDto>>" MasterPageFile="~/Views/Shared/Site.Master" %>

<%@ Import Namespace="CouchDbDemo.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Clothes
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Clothes</h2>
    <table>
        <tr>
            <th>
            </th>
            <th>
                Name
            </th>
            <th>
                Description
            </th>
            <th>
                Color
            </th>
            <th>
                DatePurchased
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "EditClothingType", new { id = item.Id })%>
                |
                <%= Html.ActionLink("Details", "ClothingTypeDetails", new { id = item.Id })%>
                |
                <%= Html.ActionLink("Delete", "DeleteClothingType", new { id = item.Id })%>
            </td>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= Html.Encode(item.Description)%>
            </td>
            <td>
                <%= Html.Encode(item.Color)%>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.DatePurchased))%>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%= Html.ActionLink("Create New", "CreateClothingType")%>
    </p>
    <p>
        <%= Html.ActionLink("Colors Breakdown", "ColorsBreakdown")%>
    </p>
</asp:Content>
