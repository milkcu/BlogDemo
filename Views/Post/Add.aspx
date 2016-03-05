<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Add a Post</h2>
    <div class="post-form">
        <!--link rel="stylesheet" href="/Scripts/kindeditor/themes/default/default.css" />
	    <link rel="stylesheet" href="/Scripts/kindeditor/plugins/code/prettify.css" />
	    <script charset="utf-8" src="/Scripts/kindeditor/kindeditor.js"></script>
	    <script charset="utf-8" src="/Scripts/kindeditor/lang/zh_CN.js"></script>
	    <script charset="utf-8" src="/Scripts/kindeditor/plugins/code/prettify.js"></script>
	    <script>
	        KindEditor.ready(function (K) {
	            var editor1 = K.create('textarea[name="body"]', {
	                cssPath: '../plugins/code/prettify.css',
	                uploadJson: '../php/upload_json.php',
	                fileManagerJson: '../php/file_manager_json.php',
	                allowFileManager: true,
	                afterCreate: function () {
	                    var self = this;
	                    K.ctrl(document, 13, function () {
	                        self.sync();
	                        K('form[name=example]')[0].submit();
	                    });
	                    K.ctrl(self.edit.doc, 13, function () {
	                        self.sync();
	                        K('form[name=example]')[0].submit();
	                    });
	                }
	            });
	            prettyPrint();
	        });
	    </script-->
        <form method="post" action="/Post/Process">
            <label>Title</label>
            <input type="text" name="title" required />
            <br />
            <label>Created</label>
            <input type="text" name="created" value="<%= DateTime.Now.ToString() %>" required />
            <br />
            <label>Body</label>
            <textarea name="body"></textarea>
            <!--textarea name="body" style="width:665px;height:400px;visibility:hidden;"></textarea-->
            <br />
            <input type="hidden" name="from" value="add" />
            <input type="submit" value="Add Post" />
        </form>
    </div>

</asp:Content>
