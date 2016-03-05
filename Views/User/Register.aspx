<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Register</h2>
    <div>
        <script type="text/javascript">
            var xmlhttp;
            function loadXMLDoc(url) {
                xmlhttp = null;
                if (window.XMLHttpRequest) {// code for Firefox, Mozilla, IE7, etc.
                    xmlhttp = new XMLHttpRequest();
                }
                else if (window.ActiveXObject) {// code for IE6, IE5
                    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                }
                if (xmlhttp != null) {
                    xmlhttp.onreadystatechange = state_Change;
                    xmlhttp.open("GET", url, true);
                    xmlhttp.send(null);
                }
                else {
                    alert("Your browser does not support XMLHTTP.");
                }
            }

            function state_Change() {
                if (xmlhttp.readyState == 4) {// 4 = "loaded"
                    if (xmlhttp.status == 200) {// 200 = "OK"
                        if (xmlhttp.responseText == 1) {
                            document.getElementById('p1').innerHTML = "registed";
                        } else {
                            document.getElementById('p1').innerHTML = "goon";
                        }
                    }
                    else {
                        alert("Problem retrieving data:" + xmlhttp.statusText);
                    }
                }
            }
        </script>
        <form method="post" action="/User/Process">
        <label>Username</label>
        <input type="text" name="username" onchange="loadXMLDoc('/User/Ajax/' + this.value)" required />
        <label id="p1"></label>
        <br />
        <label>Password</label>
        <input type="password" name="password" required />
        <br />
        <input type="hidden" name="from" value="register" />
        <input type="submit" value="Register" />
        </form>
    </div>
</asp:Content>
