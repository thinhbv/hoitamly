<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="U_OtherGroupNews.ascx.cs" Inherits="MyWeb.Controls.U_OtherGroupNews" %>
<div class="other-view">
	<asp:Repeater ID="rptGroup" runat="server"  OnItemDataBound="rptGroup_ItemDataBound">
		<ItemTemplate>
			<div class="_article">
				<div class="cate"><a href="<%#Eval("Link").ToString() %>" title="<%#Eval("Name").ToString() %>"><%#Eval("Name").ToString() %></a></div>
				<div class="cont">
					<div class="top">
						<asp:Literal ID="ltrNews" runat="server"></asp:Literal>
					</div>
					<ul>
						<asp:Repeater ID="rptNews" runat="server">
							<ItemTemplate>
								<li><a href="<%#Eval("Link").ToString() %>" title="<%#Eval("Name").ToString() %>"><%#Eval("Name").ToString() %></a></li>
							</ItemTemplate>
						</asp:Repeater>
					</ul>
				</div>
			</div>
		</ItemTemplate>
	</asp:Repeater>
</div>
