<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <% var postList = ViewData["postList"] as List<BlogDemo.Models.Posts.Post>; %>
    <% foreach (var post in postList) { %>
    <div class="post-item">
        <h2><a href="/Post/Show/<%= post.pid %>"><%= post.title %></a></h2>
        <p><%= post.body %></p>
        <span>posted @ <%= post.created %> by <a href="/Post/Index/<%= post.uid %>"><%= post.username %></a></span>
    </div>
    <% } %>
    <div>
        <% int page = int.Parse(ViewData["page"].ToString()); %>
        <% int pageNum = int.Parse(ViewData["pageNum"].ToString()); %>
        <% if (page != 1) Response.Write("<a class='previous-link' href='/Post/Index/" + ViewData["uid"] + "/" + (page - 1) + "'>Previous Page</a>"); %>
        <% if (page != pageNum) Response.Write("<a class='next-link' href='/Post/Index/" + ViewData["uid"] + "/" + (page + 1) + "'>Next Page</a>"); %>
    </div>

</asp:Content>
