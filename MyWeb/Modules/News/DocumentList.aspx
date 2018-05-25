<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" CodeBehind="DocumentList.aspx.cs" Inherits="MyWeb.Modules.News.DocumentList" %>
<%@ Import Namespace="MyWeb.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="tbl-vbh">
		<table cellspacing="0" cellpadding="0">
			<tr>
				<td class="w1 bg alc"><asp:Label ID="lblTitle" runat="server" Text="<%$Resources:Resource.Language,lblTitle %>"></asp:Label>
				</td>
				<td class="w2 bg alc"><asp:Label ID="lblNumber" runat="server" Text="<%$Resources:Resource.Language,lblNumber %>"></asp:Label>          
				</td>
				<td class="w4 bg alc"><asp:Label ID="lblFile" runat="server" Text="<%$Resources:Resource.Language,lblFile %>"></asp:Label>  
				</td>
				<td class="w3 bg alc"><asp:Label ID="lblPublic" runat="server" Text="<%$Resources:Resource.Language,lblPublic %>"></asp:Label>  
				</td>
				<td class="w5 bg alc"><asp:Label ID="lblDate" runat="server" Text="<%$Resources:Resource.Language,lblDate %>"></asp:Label> 
				</td>
			</tr>

			<asp:Repeater ID="rptDocument" runat="server">
				<ItemTemplate>
					<tr>
						<td class="w1"><a href="<%#Eval("Link").ToString() %>"><%#Eval("Name").ToString() %></a>
						</td>
						<td class="w2"><%#Eval("Content").ToString() %>
						</td>
						<td class="w3 alc"><a href="<%#Eval("File").ToString() %>">Tải về</a></td>
						<td class="w4 alc"><%#DateTimeClass.ConvertDate(Eval("LinkDemo").ToString(),"dd/MM/yyyy") %>
						</td>
						<td class="w5 alc"><%#DateTimeClass.ConvertDate(Eval("Date").ToString(),"dd/MM/yyyy") %>
						</td>
					</tr>
				</ItemTemplate>
			</asp:Repeater>			

		</table>
		<div class="pagging small">
			<ul class="pageNav" id="pagenav">
				<asp:Literal ID="ltrPaging" runat="server"></asp:Literal>
			</ul>
		</div>
	</div>
	<div class="pagging vbh">
		<div class="pageNav" id="pagenav">
		</div>
	</div>
</asp:Content>
