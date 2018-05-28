<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="admLeft.ascx.cs" Inherits="MyWeb.Controls.admLeft" %>
<table id="table1" runat="server" class="table" cellspacing="0" cellpadding="0">
    <tr>
        <td class="left">
            <img alt="" src="/App_Themes/admin/images/blank.gif" />
        </td>
        <td>
            Quản lý
        </td>
        <td class="image">
            <img alt="" id="imgdiv1" src="/App_Themes/admin/images/closed.gif" onclick="toggleXPMenu('div1');" />
        </td>
        <td class="right">
            <img alt="" src="/App_Themes/admin/images/blank.gif" />
        </td>
    </tr>
</table>
<asp:Panel ID="div1" CssClass="content" ClientIDMode="Static" runat="server">
    <ul>
        <li>
            <img alt="" src="/App_Themes/admin/images/icon_system.jpg" /><asp:LinkButton ID="lbtConfig"
                CausesValidation="false" runat="server" OnClick="LinkButton_Click">Cấu hình</asp:LinkButton></li>
        <li>
            <img alt="" src="/App_Themes/admin/images/icon_user.jpg" /><asp:LinkButton ID="lbtUser"
                CausesValidation="false" runat="server" OnClick="LinkButton_Click">Danh mục quản trị</asp:LinkButton></li>
        <li>
            <img alt="" src="/App_Themes/admin/images/icon_user.jpg" /><asp:LinkButton ID="lbtCommission"
                CausesValidation="false" runat="server" OnClick="LinkButton_Click">Danh mục phân quyền</asp:LinkButton></li>
        <li>
            <img alt="" src="/App_Themes/admin/images/icon_page.jpg" />
            <asp:LinkButton ID="lbtPage" CausesValidation="false" runat="server" OnClick="LinkButton_Click">Danh mục trang</asp:LinkButton></li>
        <li>
            <img alt="" src="/App_Themes/admin/images/icon_adv.jpg" /><asp:LinkButton ID="lbtAdvertise"
                CausesValidation="false" runat="server" OnClick="LinkButton_Click">Liên kết, quảng cáo</asp:LinkButton></li>
    </ul>
</asp:Panel>
<table class="table" cellspacing="0" cellpadding="0">
    <tr>
        <td class="left">
            <img src="/App_Themes/admin/images/blank.gif" />
        </td>
        <td>
            Tin tức
        </td>
        <td class="image">
            <img id="imgdiv10" src="/App_Themes/admin/images/closed.gif" onclick="toggleXPMenu('div10');" />
        </td>
        <td class="right">
            <img src="/App_Themes/admin/images/blank.gif" />
        </td>
    </tr>
</table>
<asp:Panel ID="div10" CssClass="content" ClientIDMode="Static" runat="server">
    <ul>
        <li>
            <img src="/App_Themes/admin/images/icon_gpro.jpg" /><asp:LinkButton ID="lbtGroupNews"
                CausesValidation="false" runat="server" OnClick="LinkButton_Click">Nhóm tin tức</asp:LinkButton></li>
        <li>
            <img src="/App_Themes/admin/images/icon_pro.jpg" /><asp:LinkButton ID="lbtNews" CausesValidation="false"
                runat="server" OnClick="LinkButton_Click">Danh mục tin tức</asp:LinkButton></li>
    </ul>
</asp:Panel>
<table id="table2" runat="server" class="table" cellspacing="0" cellpadding="0">
    <tr>
        <td class="left">
            <img src="/App_Themes/admin/images/blank.gif" />
        </td>
        <td>
            Hình ảnh
        </td>
        <td class="image">
            <img id="imgdiv2" src="/App_Themes/admin/images/closed.gif" onclick="toggleXPMenu('div2');" />
        </td>
        <td class="right">
            <img src="/App_Themes/admin/images/blank.gif" />
        </td>
    </tr>
</table>
<asp:Panel ID="div2" CssClass="content" ClientIDMode="Static" runat="server">
    <ul>
        <li>
            <img src="/App_Themes/admin/images/icon_gpro.jpg" /><asp:LinkButton ID="lbtGroupImages"
                CausesValidation="false" runat="server" OnClick="LinkButton_Click">Nhóm hình ảnh</asp:LinkButton></li>
        <li>
            <img src="/App_Themes/admin/images/icon_pro.jpg" /><asp:LinkButton ID="lbtImages"
                CausesValidation="false" runat="server" OnClick="LinkButton_Click">Danh mục hình ảnh</asp:LinkButton></li>
    </ul>
</asp:Panel>
<table id="table3" runat="server" class="table" cellspacing="0" cellpadding="0">
    <tr>
        <td class="left">
            <img src="/App_Themes/admin/images/blank.gif" />
        </td>
        <td>
            Văn bản
        </td>
        <td class="image">
            <img id="imgdiv3" src="/App_Themes/admin/images/closed.gif" onclick="toggleXPMenu('div3');" />
        </td>
        <td class="right">
            <img src="/App_Themes/admin/images/blank.gif" />
        </td>
    </tr>
</table>
<asp:Panel ID="div3" CssClass="content" ClientIDMode="Static" runat="server">
    <ul>
        <li>
            <img src="/App_Themes/admin/images/icon_gpro.jpg" /><asp:LinkButton ID="lbtGroupVanBan"
                CausesValidation="false" runat="server" OnClick="LinkButton_Click">Danh sách nhóm văn bản</asp:LinkButton></li>
        <li>
            <img src="/App_Themes/admin/images/icon_gpro.jpg" /><asp:LinkButton ID="lbtVanBan"
                CausesValidation="false" runat="server" OnClick="LinkButton_Click">Danh sách văn bản</asp:LinkButton></li>
    </ul>
</asp:Panel>
<table class="table" cellspacing="0" cellpadding="0">
    <tr>
        <td class="left">
            <img src="/App_Themes/admin/images/blank.gif" />
        </td>
        <td>
            Videos
        </td>
        <td class="image">
            <img id="img1" src="/App_Themes/admin/images/closed.gif" onclick="toggleXPMenu('div11');" />
        </td>
        <td class="right">
            <img src="/App_Themes/admin/images/blank.gif" />
        </td>
    </tr>
</table>
<asp:Panel ID="div11" CssClass="content" ClientIDMode="Static" runat="server">
    <ul>
        <li>
            <img src="/App_Themes/admin/images/icon_gpro.jpg" /><asp:LinkButton ID="lbtVideos"
                CausesValidation="false" runat="server" OnClick="LinkButton_Click">Danh mục videos</asp:LinkButton></li>
    </ul>
</asp:Panel>
<table class="table" cellspacing="0" cellpadding="0">
    <tr>
        <td class="left">
            <img alt="" src="/App_Themes/admin/images/blank.gif" />
        </td>
        <td>
            Liên hệ, Phản hồi
        </td>
        <td class="image">
            <img alt="" id="imgdiv9" src="/App_Themes/admin/images/closed.gif" onclick="toggleXPMenu('div9');" />
        </td>
        <td class="right">
            <img alt="" src="/App_Themes/admin/images/blank.gif" />
        </td>
    </tr>
</table>
<asp:Panel ID="div9" CssClass="content" ClientIDMode="Static" runat="server">
    <ul>
        <li>
            <img alt="" src="/App_Themes/admin/images/icon_contact.jpg" /><asp:LinkButton ID="lbtContact"
                CausesValidation="false" runat="server" OnClick="LinkButton_Click">Liên hệ, phản hồi</asp:LinkButton></li>
    </ul>
</asp:Panel>
<table class="table" cellspacing="0" cellpadding="0">
    <tr>
        <td class="left">
            <img alt="" src="/App_Themes/admin/images/blank.gif" />
        </td>
        <td>
            Hỗ trợ trực tuyến
        </td>
        <td class="image">
            <img alt="" id="imgdiv8" src="/App_Themes/admin/images/closed.gif" onclick="toggleXPMenu('div8');" />
        </td>
        <td class="right">
            <img alt="" src="/App_Themes/admin/images/blank.gif" />
        </td>
    </tr>
</table>
<asp:Panel ID="div8" CssClass="content" ClientIDMode="Static" runat="server">
    <ul>
        <li>
            <img alt="" src="/App_Themes/admin/images/icon_pro.jpg" /><asp:LinkButton ID="lbtSupport"
                CausesValidation="false" runat="server" OnClick="LinkButton_Click">Nhân viên hỗ trợ</asp:LinkButton></li>
    </ul>
</asp:Panel>
<table class="table" cellspacing="0" cellpadding="0">
    <tr>
        <td class="left">
            <img alt="" src="/App_Themes/admin/images/blank.gif" />
        </td>
        <td>
            Chức năng khác
        </td>
        <td class="image">
            <img alt="" id="imgPanel1" src="/App_Themes/admin/images/closed.gif" onclick="toggleXPMenu('Panel1');" />
        </td>
        <td class="right">
            <img alt="" src="/App_Themes/admin/images/blank.gif" />
        </td>
    </tr>
</table>
<asp:Panel ID="Panel1" CssClass="content" ClientIDMode="Static" runat="server">
    <ul>
        <li>
            <img alt="" src="/App_Themes/admin/images/icon_pro.jpg" /><asp:LinkButton ID="lbtLinkWeb"
                CausesValidation="false" runat="server" OnClick="LinkButton_Click">Danh sách liên kết</asp:LinkButton></li>
        <li>
            <img alt="" src="/App_Themes/admin/images/icon_pro.jpg" /><asp:LinkButton ID="lbtUploadImages"
                CausesValidation="false" runat="server" OnClick="LinkButton_Click">Upload ảnh</asp:LinkButton></li>
    </ul>
</asp:Panel>
