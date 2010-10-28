<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="System.Collections.Generic"%>
<%@ Import Namespace="DecisionesInteligentes.Rjs.Web.Models"%>

$('#City').html('');
<% foreach(var city in (Model as IList<DataValue>)) { %>
	$('<option value="<%= city.Id %>"><%= city.Value %></option>').appendTo('#City');
<% } %>