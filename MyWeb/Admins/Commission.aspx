<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Commission.aspx.cs" Inherits="MyWeb.Admins.Commission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="PageName">
		QUẢN LÝ PHÂN QUYỀN
	</div>
	<asp:Panel ID="pnView" runat="server">
		<div style="margin-bottom: 5px">
			<asp:DropDownList ID="drlUser" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drlUser_SelectedIndexChanged">
			</asp:DropDownList>
		</div>
		<div class="Control">
			<ul>
				<li>
					<asp:LinkButton CssClass="vadd" ID="lbtAddT" runat="server" OnClick="Update_Click">Cập nhật</asp:LinkButton></li>
			</ul>
		</div>
		<asp:DataGrid ID="grdGroupNews" runat="server" Width="100%" CssClass="TableView"
			AutoGenerateColumns="False" AllowPaging="True" PageSize="40" PagerStyle-Mode="NumericPages"
			PagerStyle-HorizontalAlign="Center" OnItemDataBound="grdGroupNews_ItemDataBound"
			OnPageIndexChanged="grdGroupNews_PageIndexChanged">
			<HeaderStyle CssClass="trHeader"></HeaderStyle>
			<ItemStyle CssClass="trOdd"></ItemStyle>
			<AlternatingItemStyle CssClass="trEven"></AlternatingItemStyle>
			<Columns>
				<asp:TemplateColumn ItemStyle-CssClass="tdCenter">
					<HeaderTemplate>
						<asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="False"></asp:CheckBox>
					</HeaderTemplate>
					<ItemTemplate>
						<asp:CheckBox ID="chkSelect" runat="server"></asp:CheckBox>
					</ItemTemplate>
					<ItemStyle CssClass="tdCenter"></ItemStyle>
				</asp:TemplateColumn>
				<asp:BoundColumn DataField="Id" HeaderText="Id" Visible="False" />
				<asp:BoundColumn DataField="Level" HeaderText="Level" Visible="False" />
				<asp:TemplateColumn ItemStyle-CssClass="Text">
					<HeaderTemplate>
						Các chuyên mục tin tức
					</HeaderTemplate>
					<ItemTemplate>
						<asp:Label runat="server" Text='<%# MyWeb.Common.StringClass.ShowNameLevel(Eval("Name").ToString(), Eval("Level").ToString()) %>'></asp:Label>
					</ItemTemplate>
				</asp:TemplateColumn>
			</Columns>
			<PagerStyle HorizontalAlign="Center" CssClass="Paging" Position="Bottom" NextPageText="Previous"
				PrevPageText="Next" Mode="NumericPages"></PagerStyle>
		</asp:DataGrid>
		<div class="Control">
			<ul>
				<li>
					<asp:LinkButton CssClass="vadd" ID="lbtAddB" runat="server" OnClick="Update_Click">Cập nhật</asp:LinkButton></li>
			</ul>
		</div>
	</asp:Panel>
</asp:Content>
