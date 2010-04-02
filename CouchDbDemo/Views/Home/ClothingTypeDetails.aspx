<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CouchDbDemo.Models.ClothingTypeDto>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Clothing Article Details</title>
</head>
<body>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Name</div>
        <div class="display-field"><%= Html.Encode(Model.Name) %></div>
        
        <div class="display-label">Description</div>
        <div class="display-field"><%= Html.Encode(Model.Description) %></div>
        
        <div class="display-label">Color</div>
        <div class="display-field"><%= Html.Encode(Model.Color) %></div>
        
        <div class="display-label">Date Purchased</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:g}", Model.DatePurchased)) %></div>
        
    </fieldset>
    <p>
        <%= Html.ActionLink("Edit", "EditClothingType", new { id = Model.Id })%> |
        <%= Html.ActionLink("Back to List", "Index") %>
    </p>

</body>
</html>

