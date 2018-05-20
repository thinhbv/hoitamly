<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="U_MenuLeftNews.ascx.cs" Inherits="MyWeb.Controls.U_MenuLeftNews" %>

<div class="pager">
	<div class="fl mrgb15 wfull">
		<div class="p-search">
			<input type="text" onkeypress="return clickButton(event,&#39;btnSearchhome&#39;)" onfocus="if (this.value==&#39;Nhập từ khóa tìm kiếm ...&#39;) { this.value=&#39;&#39;; }" name="txtSearchHomeEnd" onblur="if (this.value==&#39;&#39;) { this.value=&#39;Nhập từ khóa tìm kiếm ...&#39;; }" value="Nhập từ khóa tìm kiếm ..." class="stext" id="txtSearchHomeEnd">
			<input id="btnSearchhome" type="button" value="" class="btnsearch" onclick="search(txtSearchHomeEnd.value);">
		</div>
		<a href="http://www.hoitamlyhoc.com.vn/sitepages/rsshome" class="p-rss"></a>
	</div>
	<div class="mod-message">
		<div class="cate">
			<h2>
				<a href="/van-ban-hoi">Văn bản Hội</a>
			</h2>
		</div>
		<div class="vert simply-scroll-container">
			<div class="simply-scroll-clip">
				<div class="simply-scroll-list" style="height: 958px;">
					<ul id="scrollerMessage" class="simply-scroll-list" style="height: 479px;">
						<asp:Repeater ID="rptVanBan" runat="server">
							<ItemTemplate>
								<li>
									<a href="<%#Eval("Link").ToString() %>"><%#Eval("Name").ToString() %></a>
								</li>
							</ItemTemplate>
						</asp:Repeater>

						<div style="height: 80px">
						</div>
					</ul>
					<ul id="scrollerMessage" class="simply-scroll-list" style="height: 479px;">
						<asp:Repeater ID="rptVanBan01" runat="server">
							<ItemTemplate>
								<li>
									<a href="<%#Eval("Link").ToString() %>"><%#Eval("Name").ToString() %></a>
								</li>
							</ItemTemplate>
						</asp:Repeater>
						<div style="height: 80px">
						</div>
					</ul>
				</div>
			</div>
		</div>
	</div>
	<script type="text/javascript">
		(function ($) {
			$(function () { //on DOM ready
				$("#scrollerMessage").simplyScroll({
					customClass: 'vert',
					orientation: 'vertical',
					auto: true,
					autoMode: 'loop',
					speed: 1,
					frameRate: 25
				});
			});
		})(jQuery);</script>

	<div class="article-video">
		<div class="cate">
			<h2>
				<a href="/video-hoi">Video hội</a>
			</h2>
		</div>
		<div class="active" id="HomeLoadTopvideo">
			<div class="play">
				<iframe id="ifrVideo" width="285" height="200" src="https://www.youtube.com/embed/<%=vId %>" frameborder="0" gesture="media" allow="encrypted-media" allowfullscreen=""></iframe>
			</div>
			<div class="title"><%=VideoName %></div>
		</div>
		<div class="more">
			<div id="mcs_containerVideo">
				<div class="customScrollBox">
					<div class="container">
						<div class="content">
							<ul id="HomeLoadMorevideo">
								<asp:Repeater ID="rptVideo" runat="server">
									<ItemTemplate>
										<li>
											<a href="javascript:void(0);" onclick="playvideohome(this,'<%#Eval("Link").ToString() %>');"><%#Eval("Name").ToString() %>
											</a>
										</li>
									</ItemTemplate>
								</asp:Repeater>
							</ul>
						</div>
					</div>
					<div class="dragger_container" style="display: block;">
						<div class="dragger ui-draggable" style="display: block; height: 60px; line-height: 60px;">
						</div>
					</div>
				</div>
			</div>
			<script type="text/javascript">
				$(window).load(function () { Scrollbarsvd(); $($("#HomeLoadMorevideo li a")[0]).css("color", "red"); }); function Scrollbarsvd() { $("#mcs_containerVideo").mCustomScrollbar("vertical", 300, "easeOutCirc", 1.05, "auto", "yes", "yes", 15); } $.fx.prototype.cur = function () { if (this.elem[this.prop] != null && (!this.elem.style || this.elem.style[this.prop] == null)) { return this.elem[this.prop]; } var r = parseFloat(jQuery.css(this.elem, this.prop)); return typeof r == 'undefined' ? 0 : r; }
				function playvideohome(taga,vdid) {
					var _linkloadTopvideo = 'https://www.youtube.com/embed/' + vdid;
					$('#ifrVideo').attr("src", _linkloadTopvideo);
					$("#HomeLoadMorevideo li").each(function () {
						$(this).children().css("color", "#000");
					})
					$(taga).css("color", "red");
				}
			</script>
		</div>
	</div>
	<div class="p-news-readmore">
		<div class="cate">
			<h2>
				<span>Bài đọc nhiều nhất</span></h2>
		</div>
		<ul class="cont">
			<asp:Repeater ID="rptReadMost" runat="server">
				<ItemTemplate>
					<li><a href="<%#Eval("Link").ToString() %>" title="<%#Eval("Name").ToString() %>"><%#Eval("Name").ToString() %></a></li>
				</ItemTemplate>
			</asp:Repeater>

		</ul>
	</div>
	<div class="info-whether">
		<iframe src="http://www.reviewcompany.vn/free-service/?woeid=1252608" height="300px" width="100%" scrolling="yes" frameborder="0"></iframe>
	</div>
</div>
