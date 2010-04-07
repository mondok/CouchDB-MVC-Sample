<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CouchDbDemo.Models.ClothingTypeDto>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Clothing Article Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Clothing Article Details</h2>
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
</asp:Content>

