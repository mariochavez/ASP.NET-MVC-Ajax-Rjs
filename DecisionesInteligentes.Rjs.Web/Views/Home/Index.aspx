<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= Html.Encode(ViewData["Message"]) %></h2>
    <p>
        To learn more about ASP.NET MVC visit <a href="http://asp.net/mvc" title="ASP.NET MVC Website">http://asp.net/mvc</a>.
    </p>
    <% using(Html.BeginForm("AddName", "Home", FormMethod.Post, new {id = "AddName"})) {%>
        <%=Html.TextBox("name") %>
        <input type="submit" value="Add" name="AddName" class="remote" />
    <% } %>
    Names:
    <ul id="lista"></ul>
    
    <script type="text/javascript">
        $(document).ready(function() {
            RemoteForm.setup();
            RemoteLink.setup();
        });
</script>
</asp:Content>
