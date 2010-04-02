<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ClothingTypeDto>>" %>

<%@ Import Namespace="CouchDbDemo.Models" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Index</title>
</head>
<body>
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
</body>
</html>
