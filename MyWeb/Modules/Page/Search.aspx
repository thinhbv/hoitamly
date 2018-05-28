<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="MyWeb.Modules.Page.Search" %>
<%@ Import Namespace="MyWeb.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="news-list0">
		<div><asp:Label ID="lblResult" runat="server" Text="<%$Resources:Resource.Language, lblResult%>"></asp:Label> [<%=key %>]: <%=totalcount %></div>
		<asp:Repeater ID="rptNews" runat="server">
			<ItemTemplate>
				<div class="article">
					<div class="photo">
						<a href="<%#Eval("Link").ToString() %>">
							<img src="<%#Eval("Image").ToString() %>" title="<%#Eval("Name").ToString() %>" alt="<%#Eval("Name").ToString() %>" />
						</a>
					</div>
					<h4>
						<a href="<%#Eval("Link").ToString() %>"><%#Eval("Name").ToString() %></a></h4>
					<p class="time">
						<%#DateTimeClass.ConvertDate(Eval("Date").ToString(),"dd/MM/yyyy - HH:mm") %>
					</p>
					<div class="sapo">
						<%#StringClass.FormatContentNews(Eval("Content").ToString(), 150) %>
					</div>
				</div>
			</ItemTemplate>
		</asp:Repeater>
	</div>
</asp:Content>
