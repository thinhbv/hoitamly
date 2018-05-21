<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="U_Banner.ascx.cs" Inherits="MyWeb.Controls.U_Banner" %>
<%@ Import Namespace="MyWeb.Common" %>
<div class="h-focus">
	<div class="top">
		<div class=" jcarousel-skin-ptop">
			<div class="jcarousel-container jcarousel-container-horizontal" style="position: relative; display: block;">
				<div class="jcarousel-clip jcarousel-clip-horizontal" style="position: relative;">
					<ul id="mycarouselPtop" class="jcarousel-list jcarousel-list-horizontal" style="overflow: hidden; position: relative; top: 0px; margin: 0px; padding: 0px; left: -960px; width: 2500px;">
						<asp:Repeater ID="rptBanner" runat="server">
							<ItemTemplate>
								<li class="jcarousel-item jcarousel-item-horizontal jcarousel-item-<%#Eval("No").ToString() %> jcarousel-item-<%#Eval("No").ToString() %>-horizontal" jcarouselindex="<%#Eval("No").ToString() %>" style="float: left; list-style: none;">
									<div class="photo">
										<a href="<%#Eval("Link").ToString() %>">
											<img class="photo" src="<%#Eval("Image").ToString() %>" title="<%#Eval("Name").ToString() %>" alt="<%#Eval("Name").ToString() %>"></a>
									</div>
									<h3>
										<a href="<%#Eval("Link").ToString() %>" title="<%#Eval("Name").ToString() %>"><%#Eval("Name").ToString() %></a>
									</h3>
									<div class="sapo">
										<%#StringClass.FormatContentNews(Eval("Content").ToString(), 220) %>
									</div>
								</li>
							</ItemTemplate>
						</asp:Repeater>
					</ul>
				</div>
				<div class="jcarousel-prev jcarousel-prev-horizontal" style="display: block;"></div>
				<div class="jcarousel-next jcarousel-next-horizontal" style="display: block;"></div>
			</div>
		</div>
		<script type="text/javascript">
			$(document).ready(function () {
				$('#mycarouselPtop').jcarousel({
					start: 1,
					scroll: 1,
					auto: '7',//auto
					wrap: 'circular',
					animation: 'slow'
				});
			});
        </script>
	</div>
	<div class="latest">
		<div class="_category">
			<span>
				<asp:Label ID="lblLastestNews" runat="server" meta:resourcekey="lblLastestNews"></asp:Label></span>
		</div>
		<ul>
			<asp:Repeater ID="rptNews" runat="server">
				<ItemTemplate>
					<li>
						<a href="<%#Eval("Link").ToString() %>" title="<%#Eval("Name").ToString() %>"><%#Eval("Name").ToString() %></a>
					</li>
				</ItemTemplate>
			</asp:Repeater>
		</ul>
	</div>
	<ul class="more">
		<asp:Repeater ID="rptNews01" runat="server">
			<ItemTemplate>
				<li>
					<a href="<%#Eval("Link").ToString() %>">
						<img class="photo" src="<%#Eval("Image").ToString() %>" title="<%#Eval("Name").ToString() %>" alt="<%#Eval("Name").ToString() %>">
					</a>
					<h5>
						<a href="<%#Eval("Link").ToString() %>" title="<%#Eval("Name").ToString() %>"><%#Eval("Name").ToString() %></a>
					</h5>
				</li>
			</ItemTemplate>
		</asp:Repeater>
	</ul>
</div>
