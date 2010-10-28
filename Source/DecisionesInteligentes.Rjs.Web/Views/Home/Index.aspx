<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= Html.Encode(ViewData["Message"]) %></h2>
    <p>
        To learn more about ASP.NET MVC visit <a href="http://asp.net/mvc" title="ASP.NET MVC Website">http://asp.net/mvc</a>.
    </p>
    <p>
    	<% using(Html.BeginForm("AddName", "Home", FormMethod.Post, new {id = "AddName"})) {%>
    		<!-- 
    		<Html.AntiForgeryToken("saltToken") %>
    		-->
        	<%=Html.TextBox("name") %>
        	<input type="submit" value="Add" name="AddName" class="remote" />
    	<% } %>
    	Names:
    	<ul id="lista"></ul>
    </p>
    <p>
    	<%=Html.DropDownList("State", ViewData["States"] as SelectList, new {id = "State", @class = "cascade", rel = "Home"}) %>
    	<br/>
    	<%=Html.DropDownList("City", ViewData["Cities"] as SelectList, new {id = "City"}) %>
    </p>
    <script type="text/javascript">
        $(document).ready(function() {
            RemoteForm.setup();
            RemoteLink.setup();
            CascadeCombo.setup();
        });
</script>
</asp:Content>
