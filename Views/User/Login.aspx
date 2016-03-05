<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Login</h2>
    <div>
        <form method="post" action="/User/Process">
        <label>Username</label>
        <input type="text" name="username" required />
        <br />
        <label>Password</label>
        <input type="password" name="password" required />
        <br />
        <input type="hidden" name="from" value="login" />
        <input type="submit" value="Login" />
        </form>
    </div>

</asp:Content>

