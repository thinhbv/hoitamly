<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" CodeBehind="ImageList.aspx.cs" Inherits="MyWeb.Modules.Images.ImageList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link type="text/css" href="../../scripts/unitegallery/css/unite-gallery.css" rel="stylesheet" />
<script type="text/javascript" src="../../scripts/unitegallery/js/unitegallery.js"></script>
<script type="text/javascript" src="../../scripts/unitegallery/js/unitegallery.min.js"></script>
<script type="text/javascript" src="../../scripts/unitegallery/themes/tilesgrid/ug-theme-tilesgrid.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="columns" class="container">
<ul>
	<asp:Repeater ID="rptGroupImages" runat="server">
		<ItemTemplate>
			<li><a href="/<%#Eval("Id").ToString() %>/thu-vien-anh"><%#Eval("Name").ToString() %></a></li>
		</ItemTemplate>
	</asp:Repeater>
</ul>
<div id="gallery" style="display: none;">
<asp:Literal ID="ltrImages" runat="server"></asp:Literal>
</div>
<!--gallery-->
</div>
<!--columns-->
<script type="text/javascript">
    jQuery(document).ready(function () {
        jQuery("#gallery").unitegallery();
    });
</script>
</asp:Content>
