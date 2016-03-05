<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="post">
        <% var post = ViewData["post"] as BlogDemo.Models.Posts.Post; %>
        <div class="post-title"><a href="/Post/Show/<%= post.pid %>"><%= post.title %></a></div>
        <div class="post-detail"><%= post.body %></div>
        <div class="post-info">posted @ <%= post.created %> by <a href="/Post/Index/<%= post.uid %>"><%= post.username %></a></div>
    </div>
    <div class="comment">
        <% var commentList = ViewData["commentList"] as List<BlogDemo.Models.Comments.Comment>; %>
        <% foreach (var comment in commentList) { %>
        <div class="comment-item">
            <div class="comment-info">#<%= comment.cid %> <%= post.created %> <a href="/Post/Index/<%= post.uid %>"><%= post.username %></a></div>
            <div class="comment-detail"><%= comment.body %></div>
        </div>
        <% } %>
        <div class="comment-form">
            <form method="post" action="/Post/Process">
                <span>Leave a Comment</span>
                <textarea name="body"></textarea>
                <input type="hidden" name="pid" value="<%= post.pid %>" />
                <input type="hidden" name="created" value="<%= DateTime.Now.ToString() %>" />
                <input type="hidden" name="from" value="comment" />
                <input type="submit" value="Comment" />
            </form>
        </div>
    </div>
</asp:Content>
