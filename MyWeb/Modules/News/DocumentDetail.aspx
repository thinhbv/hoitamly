<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" CodeBehind="DocumentDetail.aspx.cs" Inherits="MyWeb.Modules.News.DocumentDetail" %>
<%@ Import Namespace="MyWeb.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<div class="page-content">
		<div class="news-detail detail-doc">
			<div class="title" id="newstitle">
				<%=sTitleName %>
			</div>
			<div class="time" id="time"><%=sDateTime %></div>
			<div class="sapo" id="newssapo">
				<%=sContent %>
			</div>
			<div class="content" id="newscontent">
				<%=sDetail %>
			</div>
		</div>
	</div>
	<div class="news-dt-relation">
		<div class="list list-doc">
			<div class="cate">
				<span><asp:Label ID="lblLatestNews" runat="server" Text="<%$Resources:Resource.Language, lblLatestNews %>"></asp:Label></span>
			</div>
			<ul class="lef">
				<asp:Repeater ID="rptLeft" runat="server">
					<ItemTemplate>
						<li><a href="<%#Eval("Link").ToString() %>" title="<%#Eval("Name").ToString() %>"><%#Eval("Name").ToString() %></a></li>
					</ItemTemplate>
				</asp:Repeater>
			</ul>
			<ul class="rig">
				<asp:Repeater ID="rptRight" runat="server">
					<ItemTemplate>
						<li><a href="<%#Eval("Link").ToString() %>" title="<%#Eval("Name").ToString() %>"><%#Eval("Name").ToString() %></a></li>
					</ItemTemplate>
				</asp:Repeater>
			</ul>
		</div>
	</div>
</asp:Content>
