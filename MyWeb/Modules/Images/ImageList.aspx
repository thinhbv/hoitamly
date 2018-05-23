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
			<li id="<%#Eval("Id").ToString() %>"><a href="/<%#Eval("Id").ToString() %>/thu-vien-anh"><%#Eval("Name").ToString() %></a></li>
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
    	var id = window.location.pathname.split('/')[1];
    	if (isNaN(id)) {
    		jQuery(jQuery("#columns ul li")[0]).attr("class", "selected");
    	}
    	else {
    		jQuery(".selected").removeAttr("class");
    		jQuery("#" + id).attr("class", "selected");
    	}
    });
</script>
</asp:Content>
