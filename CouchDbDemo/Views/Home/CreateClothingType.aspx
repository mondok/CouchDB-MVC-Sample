<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CouchDbDemo.Models.ClothingTypeDto>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>New Clothing Article</title>
</head>
<body>
    <% using (Html.BeginForm())
       {%>
    <%= Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Fields</legend>
        <%= Html.HiddenFor(model => model.EntityType) %>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.Name) %>
        </div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.Name) %>
            <%= Html.ValidationMessageFor(model => model.Name) %>
        </div>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.Description) %>
        </div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.Description) %>
            <%= Html.ValidationMessageFor(model => model.Description) %>
        </div>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.Color) %>
        </div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.Color) %>
            <%= Html.ValidationMessageFor(model => model.Color) %>
        </div>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.DatePurchased) %>
        </div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.DatePurchased) %>
            <%= Html.ValidationMessageFor(model => model.DatePurchased) %>
        </div>
        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>
</body>
</html>
