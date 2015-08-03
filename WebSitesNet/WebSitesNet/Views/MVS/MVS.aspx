<%@Import Namespace ="Data" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IList<Data.Objects.User>>" %>
<%@ Import Namespace="System.Web.Services.Description" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Mission, Vision and Statement
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <!--% using (Html.BeginForm("MVS")){%>
            <fieldset>
                <legend>MVS Fields</legend>
                <!--p style="color: cyan">
                    <!--%= Html.LabelFor(model => model.Goals) %>
                    <!--%= Html.TextBoxFor(model => model.Goals) %>
                </--p>
                <p style="color: red">
                    <!--%= Html.LabelFor(model => model.Vision) %>
                    <!--%= Html.TextBoxFor(model => model.Vision) %>
                </p>
                <p-- style="color: green">
                    <!%= Html.LabelFor(model => model.Mission) %>
                    <!%= Html.TextBoxFor(model => model.Mission) %>
                </p>
            </fieldset>
         -->
         
       
       <% using (Html.BeginForm("MVS")){%>
            <fieldset>
                <legend>MVS Keys</legend>
                <table title="Keys" style="border-width: 2pt;border-style: solid; border-color: black;" >
             <tr>
                 <th style="background: maroon;color: white">UserName</th>
                 <th style="background: maroon ;color: white">Password</th>
                 <th style="background: maroon;color: white">EmailAddresss</th>
                 <th style="background: green; color: black">Version</th> 
                 <th style="background: green; color: black">Id(Key)</th> 
             </tr>
             <% foreach (var iHasId in Model) { %>
                    <tr style="border-width: 1pt;border-style: solid; border-color: black;">
                        <td style="border-width: 1pt;border-style: groove; border-color: red;">
                            <%= iHasId.UserName %>
                        </td>
                        <td style="border-width: 1pt;border-style: groove; border-color: red;">
                            <%= iHasId.Password %>
                        </td>
                        <td style="border-width: 1pt;border-style: groove; border-color: red;">
                            <%= iHasId.EmailAddress %>
                        </td>
                        <td style="border-width: 1pt;border-style: groove; border-color: red;">
                            <%= iHasId.Version %>
                        </td>
                        <td style="border-width: 1pt;border-style: groove; border-color: red;">
                            <%= iHasId.Key.ToString() %>
                        </td>
                    </tr>
              <%  } %>
         </table>
            </fieldset>
       <% } %>

</asp:Content>
