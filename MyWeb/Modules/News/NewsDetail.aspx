<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" CodeBehind="NewsDetail.aspx.cs" Inherits="MyWeb.Modules.News.NewsDetail" %>
<%@ Import Namespace="MyWeb.Common" %>
<%@ Register Src="~/Controls/U_OtherGroupNews.ascx" TagPrefix="uc1" TagName="U_OtherGroupNews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="page-category">
		<h2><a href="<%=PageHelper.GeneralGroupUrl(Consts.CON_TIN_TUC,id,groupName) %>"><%=groupName %></a></h2>
	</div>
	<div class="page-content">
		<div class="news-detail">
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
		<uc1:U_OtherGroupNews runat="server" id="idU_OtherGroupNews" />
	</div>
	<div class="news-dt-relation">
		<div class="cate">
			<span><%=titleReleate %></span>
		</div>
		<ul class="top">
			<asp:Repeater ID="rptReleative" runat="server">
				<ItemTemplate>
					<li><a href="<%#Eval("Link").ToString() %>">
						<img class="photo" src="<%#Eval("Image").ToString() %>" title="<%#Eval("Name").ToString() %>" alt="<%#Eval("Name").ToString() %>" /></a>
						<h5><a href="<%#Eval("Link").ToString() %>" title="<%#Eval("Name").ToString() %>"><%#Eval("Name").ToString() %></a></h5>
					</li>
				</ItemTemplate>
			</asp:Repeater>
		</ul>
		<div class="list">
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
