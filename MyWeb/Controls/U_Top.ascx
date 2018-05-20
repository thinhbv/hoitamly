<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="U_Top.ascx.cs" Inherits="MyWeb.Controls.U_Top" %>

<div class="head">
    <h1 id="logo">
        <a href="/" title="Đá Mỹ Nghệ Hoàng Thành">
            <asp:Literal ID="ltrLogo" runat="server"></asp:Literal>
        </a>
    </h1>
    <ul class="menu-user">
        <li>
            <center style="margin-bottom: 4px;">
                <span style="background: url(/Images/icon-1.gif) 0 2px no-repeat; font-size: 15px; font-weight:bold;">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Hotline</span></center>
            <span style="font-size: 15px; font-weight: bold; color: #d58134">
                <asp:Label ID="lblPhone" runat="server"></asp:Label></span></li>
        <li>
            <!-- Go to www.addthis.com/dashboard to customize your tools -->
            <div class="addthis_native_toolbox" style="margin-top: 3px;">
            </div>
            <script type="text/javascript" src="//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-4f87903d1009b87f"></script>
        </li>
    </ul>
</div>
