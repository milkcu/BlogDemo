<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Manage My Posts</h2>
    <div class="post-table">
        <table>
            <thead>
                <tr>
                    <th>POST ID</th>
                    <th>POST TITLE</th>
                    <th>CREATED TIME</th>
                    <th>OPERATION</th>
                    <th>OPERATION</th>
                </tr>
            </thead>
            <tbody>
                <% var postList = ViewData["postList"] as List<BlogDemo.Models.Posts.Post>; %>
                <% foreach (var post in postList) { %>
                <tr>
                    <td><%= post.pid %></td>
                    <td style="width: 180px;"><%= post.title %></td>
                    <td style="width: 150px;"><%= post.created %></td>
                    <td><a href="/Post/Modify/<%= post.pid %>">Modify</a></td>
                    <td><a href="/Post/Delete/<%= post.pid %>">Delete</a></td>
                </tr>
                <% } %>
            </tbody>
        </table>
    </div>
    <div>
        <% int page = int.Parse(ViewData["page"].ToString()); %>
        <% int pageNum = int.Parse(ViewData["pageNum"].ToString()); %>
        <% if (page != 1) Response.Write("<a class='previous-link' href='/Post/Manage/" + ViewData["uid"] + "/" + (page - 1) + "'>Previous Page</a>"); %>
        <% if (page != pageNum) Response.Write("<a class='next-link' href='/Post/Manage/" + ViewData["uid"] + "/" + (page + 1) + "'>Next Page</a>"); %>
    </div>

</asp:Content>
