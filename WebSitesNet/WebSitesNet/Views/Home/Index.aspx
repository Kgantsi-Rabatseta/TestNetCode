<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewData["Message"] %></h2>
    <p>
        The Beginning of a great website : Reference <a href="http://asp.net/mvc" title="TakeUThereASP.NET MVC Website">http://asp.net/mvc</a>.
    </p>
</asp:Content>
