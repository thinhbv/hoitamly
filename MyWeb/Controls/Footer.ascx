<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="MyWeb.Controls.Footer" %>
<div class="fmenu">
	<asp:Repeater ID="rptMenu" runat="server">
		<ItemTemplate>
			<a href="<%#Eval("Link").ToString() %>" title="<%#Eval("Name").ToString() %>"><%#Eval("Name").ToString() %></a>
			<span>|</span>
		</ItemTemplate>
	</asp:Repeater>
	<a href="/sitepages/rsshome">RSS</a>
</div>
<asp:Literal ID="ltrInfo" runat="server"></asp:Literal>
