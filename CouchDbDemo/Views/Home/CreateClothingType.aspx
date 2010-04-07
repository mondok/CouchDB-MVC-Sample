<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CouchDbDemo.Models.ClothingTypeDto>"
    MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    New Article of Clothing
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>New Article of Clothing</h2>
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
</asp:Content>
