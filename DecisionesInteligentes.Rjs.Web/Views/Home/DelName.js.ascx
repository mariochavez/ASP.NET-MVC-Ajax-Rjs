<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Person>" %>
<%@ Import Namespace="DecisionesInteligentes.Rjs.Web.Models"%>

$('input#name').val('');
$('#<%=Html.Encode(Model.Id)%>').removeLoading();
$('#<%=Html.Encode(Model.Id)%>').slideUp(function() {
    $('#<%=Html.Encode(Model.Id)%>').remove();
} );
