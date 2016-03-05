<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Process</h2>
    <div>
        <%= ViewData["username"] %>
        <br />
        <%= ViewData["password"] %>
        <br />
        <%= ViewData["uid"] %>
        <br />
        <%= ViewData["test"] %>
        <br />
        <%= ViewData["session"] %>
    </div>
    <%= DateTime.Now.ToString()%>


</asp:Content>
