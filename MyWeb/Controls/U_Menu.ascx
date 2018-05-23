<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="U_Menu.ascx.cs" Inherits="MyWeb.Controls.U_Menu" %>
<%@ Register Src="~/Controls/U_Language.ascx" TagPrefix="uc1" TagName="U_Language" %>

<div id="navbar">
	<div class="animatedtabs" id="ddtabs">
		<ul>
			<asp:Repeater ID="rptMenu" runat="server" OnItemDataBound="rptMenu_ItemDataBound">
				<ItemTemplate>
					<li id="subCate<%#Eval("Id").ToString() %>"><a href="<%#Eval("Link").ToString() %>" title="<%#Eval("Name").ToString() %>"><span><%#Eval("Name").ToString() %></span></a>
						<div id="menusub" class="subMenuContainer" runat="server" enableviewstate="false">
							<ul>
								<asp:Repeater ID="rptMenuSub" runat="server">
									<ItemTemplate>
										<li><a href="<%#Eval("Link").ToString() %>" title="<%#Eval("Name").ToString() %>"><span><%#Eval("Name").ToString() %> |</span></a></li>
									</ItemTemplate>
								</asp:Repeater>
								<asp:Literal ID="ltrLastItem" runat="server"></asp:Literal>
							</ul>
						</div>
					</li>
				</ItemTemplate>
			</asp:Repeater>
		</ul>
		<div class="tab-lang">
            <uc1:U_Language ID="idU_Language" runat="server" />
        </div>
	</div>
	<input name="txtCateID" type="text" id="txtCateID" style="display: none">
	<div id="subTopMenu">
	</div>
</div>
<script language="javascript" type="text/javascript">
	$(document).ready(function () {
		var path = window.location.pathname;
		var isOK = false;
		$("#ddtabs ul li a").each(function () {
			if (path === $(this).attr("href")) {
				showTab($($(this).parent()));
				$("#txtCateID").val("#" + $($(this).parent()).attr("id"));
				isOK = true;
			}
		})
		if (isOK === false) {
			$("#subTopMenu ul li").each(function () {
				if (path === $($(this).children()).attr("href")) {
					showTab($($(this).parent()));
					$("#txtCateID").val("#" + $($(this).parent()).attr("id"));
					isOK = true;
				}
			})
		}
	});
	var delayhide;
	$(".animatedtabs li").hover(function () {
		showTab('#' + $(this).attr("id"));
	},
	function () {
		return false;
	});

	$("#navbar").hover(function () {
		if (window.delayhide)
			clearTimeout(delayhide);
	},
	function () {
		var _cateid = document.getElementById('txtCateID').value;
		if (_cateid != "")
			delayhide = setTimeout(showTab(_cateid), 10000);
		else
			delayhide = setTimeout(showTab('#subCate0'), 10000);
	});
	function showTab(obj) {
		//alert(obj);
		$('.animatedtabs').find("li").removeClass("selected");
		$(obj).addClass("selected");
		$('#subTopMenu').find("ul").remove();
		$('#subTopMenu').append($(obj).find(".subMenuContainer").html());
		var subUl = $(obj).find("a:first");
		var subUlW = subUl.width();
		var subMenu = $('#subTopMenu ul li');
		var subMenuW = 0;
		$('#subTopMenu ul li').each(function () {
			subMenuW += $(this).width();
		});
		if (subMenuW != 0) {
			var subPos = $(obj).position();
			if (subPos.left > ((subMenuW - subUlW) / 2)) {
				if ((subPos.left + subMenuW / 2 + subUlW / 2) < $('#subTopMenu').innerWidth()) {
					$('#subTopMenu').find("ul").css({ paddingLeft: (subPos.left - (subMenuW / 2) + subUlW / 2) + "px" });
				} else {
					$('#subTopMenu').find("ul").css({ float: "right" });
				}
			}
		}
	}
</script>
