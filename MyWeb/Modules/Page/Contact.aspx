<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" EnableEventValidation="false"
	CodeBehind="Contact.aspx.cs" Inherits="MyWeb.Modules.Page.Contact" %>

<%@ Register Src="../../Controls/U_MenuLeft.ascx" TagName="U_MenuLeft" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script type="text/javascript">
		jQuery(document).ready(function () {
			jQuery('#tm_submit_search').click(function () {
				jQuery('#<%= txtTitle.ClientID %>').val("");
				jQuery('#<%= txtHoTen.ClientID %>').val("");
				jQuery('#<%= txtEmail.ClientID %>').val("");
				jQuery('#<%= txtPhone.ClientID %>').val("");
				jQuery('#<%= txtAddress.ClientID %>').val("");
				jQuery('#<%= txtDetail.ClientID %>').val("");
				return false;
			});
			jQuery('#tm_submit').click(function () {
				if (jQuery('#<%= txtTitle.ClientID %>').val().trim() == "") {
					alert("Vui lòng nhập tiêu đề của bạn!");
					jQuery('#<%= txtTitle.ClientID %>').focus()
					return false
				}

				if (jQuery('#<%= txtHoTen.ClientID %>').val().trim() == "") {
					alert("Vui lòng nhập họ tên của bạn!");
					jQuery('#<%= txtHoTen.ClientID %>').focus()
					return false
				}
				if (jQuery('#<%= txtEmail.ClientID %>').val().trim() == "") {
					alert("Vui lòng nhập email của bạn!");
					jQuery('#<%= txtEmail.ClientID %>').focus()
					return false
				}
				if (jQuery('#<%= txtDetail.ClientID %>').val().trim() == "") {
					alert("Vui lòng nhập nội dung!");
					jQuery('#<%= txtDetail.ClientID %>').focus()
					return false
				}
				return true;
			});
		});
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div id="columns" class="container">
		<!-- Breadcrumb -->
		<div class="page-category">
			<h2>
				<asp:Label ID="lblContact" runat="server" Text="<%$Resources:Resource.Language, lblContact%>"></asp:Label></h2>
		</div>
		<!-- /Breadcrumb -->
		<div class="row">
			<div style="margin-bottom: 10px">
				<asp:Literal ID="ltrContact" runat="server"></asp:Literal>
			</div>
			<br />
			<table class="form-contact" cellpadding="0" cellspacing="0">
				<tr>
					<th><asp:Label ID="lblContactTitle" runat="server" Text="<%$Resources:Resource.Language, lblContactTitle %>"></asp:Label>
					</th>
					<td>
						<asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td style="height: 10px" colspan="2"></td>
				</tr>
				<tr>
					<th><asp:Label ID="lblContactName" runat="server" Text="<%$Resources:Resource.Language, lblContactName %>"></asp:Label>
					</th>
					<td>
						<asp:TextBox ID="txtHoTen" runat="server"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td style="height: 10px" colspan="2"></td>
				</tr>
				<tr>
					<th>Email (*):
					</th>
					<td>
						<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td style="height: 10px" colspan="2"></td>
				</tr>
				<tr>
					<th><asp:Label ID="lblPhone" runat="server" Text="<%$Resources:Resource.Language, lblPhone %>"></asp:Label>
					</th>
					<td>
						<asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td style="height: 10px" colspan="2"></td>
				</tr>
				<tr>
					<th>Địa chỉ:<asp:Label ID="lblAdress" runat="server" Text="<%$Resources:Resource.Language, lblAdress %>"></asp:Label>
					</th>
					<td>
						<asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td style="height: 10px" colspan="2"></td>
				</tr>
				<tr>
					<th><asp:Label ID="lblDetail" runat="server" Text="<%$Resources:Resource.Language, lblDetail %>"></asp:Label>
					</th>
					<td>
						<asp:TextBox ID="txtDetail" runat="server" TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<th></th>
					<td>
						<i><asp:Label ID="lblNote" runat="server" Text="<%$Resources:Resource.Language, lblNote %>"></asp:Label></i>
					</td>
				</tr>
			</table>
			<div class="button-contact">
				<asp:Button ID="btnSend" runat="server" Text="SEND" OnClick="btnSend_Click" CssClass="button" />
				<input type="button" id="tm_submit_search" class="button" value="Clear" />
			</div>
		</div>
		<!--.row-->
	</div>
	<!-- #columns -->
</asp:Content>
