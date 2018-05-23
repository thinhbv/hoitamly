<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" CodeBehind="VideosList.aspx.cs" Inherits="MyWeb.Modules.Videos.VideosList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<link type="text/css" href="../../scripts/unitegallery/css/unite-gallery.css" rel="stylesheet" />
	<script type="text/javascript" src="../../scripts/unitegallery/js/unitegallery.js"></script>
	<script type="text/javascript" src="../../scripts/unitegallery/js/unitegallery.min.js"></script>
	<script type="text/javascript" src="../../scripts/unitegallery/themes/tilesgrid/ug-theme-tilesgrid.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div id="columns" class="container">
		<h4>DANH SÁCH VIDEOS CỦA HỘI</h4>
		<div id="gallery" style="display: none;">
			<asp:Repeater ID="rptVideos" runat="server">
				<ItemTemplate>
					<img alt="<%#Eval("Name").ToString() %>"
						data-type="youtube" src="<%#string.Format("https://img.youtube.com/vi/{0}/default.jpg", Eval("Link").ToString()) %>"
						data-description="<%#Eval("Name").ToString() %>"
						data-videoid="<%#Eval("Link").ToString() %>" style="display: none">
				</ItemTemplate>
			</asp:Repeater>
		</div>
		<!--gallery-->
	</div>
	<!--columns-->
	<script type="text/javascript">
		jQuery(document).ready(function () {
			jQuery("#gallery").unitegallery({
				gallery_width: 960,
				grid_num_rows: 9999
			});

		});
</script>
</asp:Content>
