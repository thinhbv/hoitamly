<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="U_Banner.ascx.cs" Inherits="MyWeb.Controls.U_Banner" %>
<%@ Import Namespace="MyWeb.Common" %>
<div class="h-focus">
	<div id="ctl00_Pld_SiteMainPages_g_2ccffad7_5a8c_4b09_83ed_682ebbb8222b" __markuptype="vsattributemarkup" __webpartid="{2ccffad7-5a8c-4b09-83ed-682ebbb8222b}" webpart="true">
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

	</div>
	<div id="ctl00_Pld_SiteMainPages_g_1d7ea719_4d41_41b4_b6c2_a7ed6a9496b1" __markuptype="vsattributemarkup" __webpartid="{1d7ea719-4d41-41b4-b6c2-a7ed6a9496b1}" webpart="true">

		<div class="latest">
			<div class="_category">
				<span>Tin mới nhất</span>
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

	</div>
	<div id="ctl00_Pld_SiteMainPages_g_eeccc94f_2445_4346_aa18_799ea9c26e8a" __markuptype="vsattributemarkup" __webpartid="{eeccc94f-2445-4346-aa18-799ea9c26e8a}" webpart="true">
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
</div>
