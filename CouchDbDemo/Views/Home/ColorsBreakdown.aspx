<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<CouchDbDemo.Models.ClothingColor>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Colors Breakdown</title>
</head>
<body>
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
</body>
</html>
