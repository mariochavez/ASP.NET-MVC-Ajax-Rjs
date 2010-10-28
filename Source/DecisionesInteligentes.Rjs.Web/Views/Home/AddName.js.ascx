<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Person>" %>
<%@ Import Namespace="DecisionesInteligentes.Rjs.Web.Models"%>

var html = '<li id="<%=Html.Encode(Model.Id) %>"><%=Html.Encode(Model.Name) %> <%=Html.ActionLink("Remove", "DelName", "Home", new { id = Html.Encode(Model.Id) }, new { @class = "remote delete" })%> </li>';

$('input#name').val('');
$('#lista').prepend(html);
$('#<%=Html.Encode(Model.Id)%>').hide();
$('#<%=Html.Encode(Model.Id)%>').slideDown();
$('#<%=Html.Encode(Model.Id)%>').highlight();
