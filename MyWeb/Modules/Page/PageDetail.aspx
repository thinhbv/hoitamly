<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageDetail.aspx.cs" Inherits="MyWeb.Modules.Page.PageDetail" %>

<%@ Register Src="~/Controls/U_MenuLeft.ascx" TagPrefix="uc1" TagName="U_MenuLeft" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {
			$("#ul_layered_id_attribute_group_1 input[type=checkbox]").each(function (index) {
				$(this).click(function () {
					event.preventDefault();
				})
				var groupId = '<%= pageId%>';
				if ($(this).val() == groupId) {
					$(this).prop("checked", true);
					$(this).parent().children().children().addClass("red");
				}
				else {
					$(this).prop("checked", false);
				}
			})
		})
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="page-category">
		<asp:Literal ID="ltrCategory" runat="server"></asp:Literal>
		<h2><a href="http://www.hoinongdan.org.vn/sitepages/chuyenmuc/51/tu-van-phap-luat">TƯ VẤN PHÁP LUẬT</a></h2>
		<h2><a class="sub" href="http://www.hoinongdan.org.vn/sitepages/chuyenmuc/53/chinh-sach">CHÍNH SÁCH</a></h2>
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
	</div>
</asp:Content>
