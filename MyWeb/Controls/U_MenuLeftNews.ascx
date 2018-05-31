<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="U_MenuLeftNews.ascx.cs" Inherits="MyWeb.Controls.U_MenuLeftNews" %>
<%@ Import Namespace="MyWeb.Common" %>
<div class="pager">
	<div class="fl mrgb15 wfull">
		<div class="p-search">
			<%if (Lang == "vi"){%>
			<input type="text" onkeypress="return clickButton(event,&#39;btnSearchhome&#39;)" onfocus="if (this.value==&#39;Nhập từ khóa tìm kiếm ...&#39;) { this.value=&#39;&#39;; }" name="txtSearchHomeEnd" onblur="if (this.value==&#39;&#39;) { this.value=&#39;Nhập từ khóa tìm kiếm ...&#39;; }" value="Nhập từ khóa tìm kiếm ..." class="stext" id="txtSearchHomeEnd">
			<%} else{ %>
			<input type="text" onkeypress="return clickButton(event,&#39;btnSearchhome&#39;)" onfocus="if (this.value==&#39;Enter keyword search ...&#39;) { this.value=&#39;&#39;; }" name="txtSearchHomeEnd" onblur="if (this.value==&#39;&#39;) { this.value=&#39;Enter keyword search ...&#39;; }" value="Enter keyword search ..." class="stext" id="txtSearchHomeEnd">
			<%} %>
			<input id="btnSearchhome" type="button" value="" class="btnsearch" onclick="search(txtSearchHomeEnd.value);">
		</div>
	</div>
	<div class="mod-message">
		<div class="cate">
			<h2>
				<a href="/van-ban-hoi">
					<asp:Label ID="lblVanBan" runat="server" Text="<%$Resources:Resource.Language, lblVanBan %>"></asp:Label></a>
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
				<a href="/video-hoi">
					<asp:Label ID="lblVideos" runat="server" Text="<%$Resources:Resource.Language, lblVideos %>"></asp:Label></a>
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
				$(window).load(function () { Scrollbarsvd(); $($("#HomeLoadMorevideo li a")[0]).css("color", "#173696"); $($("#HomeLoadMorevideo li a")[0]).css("font-weight", "bold"); }); function Scrollbarsvd() { $("#mcs_containerVideo").mCustomScrollbar("vertical", 300, "easeOutCirc", 1.05, "auto", "yes", "yes", 15); } $.fx.prototype.cur = function () { if (this.elem[this.prop] != null && (!this.elem.style || this.elem.style[this.prop] == null)) { return this.elem[this.prop]; } var r = parseFloat(jQuery.css(this.elem, this.prop)); return typeof r == 'undefined' ? 0 : r; }
				function playvideohome(taga, vdid) {
					var _linkloadTopvideo = 'https://www.youtube.com/embed/' + vdid;
					$('#ifrVideo').attr("src", _linkloadTopvideo);
					$("#HomeLoadMorevideo li").each(function () {
						$(this).children().css("color", "#000");
						$(this).children().css("font-weight", "normal");
					})
					$(taga).css("color", "#173696");
					$(taga).css("font-weight", "bold");
					$('.title').text($(taga).text());
				}
			</script>
		</div>
	</div>
	<div class="p-news-readmore">
		<div class="cate">
			<h2>
				<asp:Label ID="lblMostRead" runat="server" Text="<%$Resources:Resource.Language, lblMostRead %>"></asp:Label></h2>
		</div>
		<ul class="cont">
			<asp:Repeater ID="rptReadMost" runat="server">
				<ItemTemplate>
					<li><a href="<%#Eval("Link").ToString() %>" title="<%#Eval("Name").ToString() %>"><%#Eval("Name").ToString() %></a></li>
				</ItemTemplate>
			</asp:Repeater>

		</ul>
	</div>
	<div class="link-web">
		<div class="cate">
			<h2>
				<span><asp:Label ID="lblLinkWeb" runat="server" Text="<%$Resources:Resource.Language, lblLinkWeb %>"></asp:Label></span></h2>
		</div>
		<div class="list">
			<div class="ddl">
				<% if (Lang == "vi"){ %>
				<input id="txtlinks" type="text" class="txtboxCategory" value="-- Hội Tâm lý học Việt Nam --" />
				<%} else { %>
				<input id="txtlinks" type="text" class="txtboxCategory" value="-- VietNam Association Of Social Psychology --" />
				<%} %>
				<span class="btnddl" id="btnddl"></span>
				<div class="textoption" id="textoption">
					<ul>
						<asp:Repeater ID="rptLinkWeb" runat="server">
							<ItemTemplate>
								<li><a target="_blank" href="<%#Eval("Link").ToString() %>"><%#Eval("Name").ToString() %></a> </li>
							</ItemTemplate>
						</asp:Repeater>
					</ul>
				</div>
			</div>
			<script type="text/javascript">
				$("#txtlinks").click(function (e) { $('#textoption').show(); e.stopPropagation(); });
				$("#btnddl").click(function (e) { $('#textoption').show(); e.stopPropagation(); });
				$(document).click(function (event) { $('#textoption').css('display', 'none'); });
				$("#textoption li").click(function () {
					$('#textoption').css('display', 'none');
					$('#textoption').hide(); $('#txtlinks').val($(this).text());
				});
			</script>
		</div>
	</div>
	<%--<div class="info-whether">
		<!-- weather widget start -->
		<div id="m-booked-custom-widget-31754">
		</div>
		<script type="text/javascript"> var css_file = document.createElement("link"); css_file.setAttribute("rel", "stylesheet"); css_file.setAttribute("type", "text/css"); css_file.setAttribute("href", '/css/weather.css?v=0.0.1'); document.getElementsByTagName("head")[0].appendChild(css_file); function setWidgetData(data) { if (typeof (data) != 'undefined' && data.results.length > 0) { for (var i = 0; i < data.results.length; ++i) { var objMainBlock = document.getElementById('m-booked-custom-widget-31754'); if (objMainBlock !== null) { var copyBlock = document.getElementById('m-bookew-weather-copy-' + data.results[i].widget_type); objMainBlock.innerHTML = data.results[i].html_code; if (copyBlock !== null) objMainBlock.appendChild(copyBlock); } } } else { alert('data=undefined||data.results is empty'); } }</script>
		<script type="text/javascript" charset="UTF-8" src="https://widgets.booked.net/weather/info?action=get_weather_info&ver=6&cityID=19487,18408,33811,33807,33810&type=2&scode=124&ltid=3458&domid=w209&anc_id=64391&cmetric=1&wlangID=1&color=009f5d&wwidth=285&header_color=ffffff&text_color=333333&link_color=08488D&border_form=1&footer_color=ffffff&footer_text_color=333333&transparent=0"></script>
		<!-- weather widget end -->
	</div>--%>
</div>
