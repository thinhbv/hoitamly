<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true"
	CodeBehind="Default.aspx.cs" Inherits="MyWeb.Default" %>

<%@ Import Namespace="MyWeb.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<asp:Repeater ID="rptGroupNews" runat="server" OnItemDataBound="rptNews_ItemDataBound">
		<ItemTemplate>
			<div>
				<div class="article1">
					<div class="cate">
						<h2>
							<a href="<%#Eval("Link").ToString() %>" title="<%#Eval("Name").ToString() %>"><%#Eval("Name").ToString() %></a>
						</h2>
						<ul>
							<asp:Repeater ID="rptGroupNewsSub" runat="server">
								<ItemTemplate>
									<li><span>|</span> <a href="<%#Eval("Link").ToString() %>" title="<%#Eval("Name").ToString() %>"><%#Eval("Name").ToString() %></a></li>
								</ItemTemplate>
							</asp:Repeater>
						</ul>
					</div>
					<div class="top">
						<asp:Repeater ID="rptNewsOne" runat="server">
							<ItemTemplate>
								<div class="photo">
									<a href="<%#Eval("Link").ToString() %>">
										<img src="<%#Eval("Image").ToString() %>" alt="<%#Eval("Name").ToString() %>" title="<%#Eval("Name").ToString() %>"></a>
								</div>
								<h4><a href="<%#Eval("Link").ToString() %>" title="<%#Eval("Name").ToString() %>" class="title"><%#Eval("Name").ToString() %></a></h4>
								<div class="sapo"><%#StringClass.FormatContentNews(Eval("Content").ToString(), 180) %></div>
							</ItemTemplate>
					</asp:Repeater>
					</div>
						<ul class="more">
							<asp:Literal ID="ltrNews" runat="server"></asp:Literal>
							<asp:Repeater ID="rptNews" runat="server">
								<ItemTemplate>
									<li><a href="<%#Eval("Link").ToString() %>"><%#Eval("Name").ToString() %></a></li>
								</ItemTemplate>
							</asp:Repeater>
						</ul>
				</div>
			</div>
		</ItemTemplate>
	</asp:Repeater>
</asp:Content>
