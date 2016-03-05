<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Process</h2>
    <%= DateTime.Now.ToString()%>
    <div><%= Request["body"] %></div>
    <div><%= Request["pid"] %></div>

</asp:Content>
