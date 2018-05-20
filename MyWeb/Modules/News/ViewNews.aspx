<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="ViewNews.aspx.cs" Inherits="MyWeb.Modules.News.ViewNews" %>

<%@ Import Namespace="MyWeb.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="news-list0">
		<asp:Repeater ID="rptNews" runat="server">
			<ItemTemplate>
				<div class="article">
					<div class="photo" style='display: yes;'>
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
						<%#StringClass.FormatContentNews(Eval("Content").ToString(), 200) %>
					</div>
				</div>
			</ItemTemplate>
		</asp:Repeater>
		<div class="pagging small">
			<ul class="pageNav" id="pagenav">
				<asp:Literal ID="ltrPaging" runat="server"></asp:Literal>
			</ul>
		</div>
	</div>
</asp:Content>
