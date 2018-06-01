<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="MyWeb.Controls.Footer" %>
<div class="fmenu">
	<asp:Repeater ID="rptMenu" runat="server">
		<ItemTemplate>
			<a href="<%#Eval("Link").ToString() %>" title="<%#Eval("Name").ToString() %>"><%#Eval("Name").ToString() %></a>
			<span>|</span>
		</ItemTemplate>
	</asp:Repeater>
	<%if (Lang == "vi"){ %>
	<a href="/lien-he">Liên hệ</a>
	<%} else{ %>
	<a href="/lien-he">Contact</a>
	<%} %>
</div>
<asp:Literal ID="ltrInfo" runat="server"></asp:Literal>
