using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using MyWeb.Common;
using MyWeb.Data;
using MyWeb.Business;
using System.Data;

namespace MyWeb
{
    public class Global : System.Web.HttpApplication
    {
        void RegisterRoutes()
        {
            //News routes
            RouteTable.Routes.MapPageRoute("News", "tin-tuc/{GroupId}/{title}", "~/Modules/News/ViewNews.aspx");
            RouteTable.Routes.MapPageRoute("GroupNews", "tin-tuc/{GroupId}/{title}/trang-{page}", "~/Modules/News/ViewNews.aspx");
			RouteTable.Routes.MapPageRoute("NewsDetail", "tin-tuc/{groupName}/{Id}/{title}", "~/Modules/News/NewsDetail.aspx");
			RouteTable.Routes.MapPageRoute("GroupDocument", "van-ban/{GroupId}/{title}", "~/Modules/News/DocumentList.aspx");
			RouteTable.Routes.MapPageRoute("GroupDoc", "van-ban/{GroupId}/{title}/trang-{page}", "~/Modules/News/DocumentList.aspx");
			RouteTable.Routes.MapPageRoute("Doc", "van-ban-hoi", "~/Modules/News/DocumentList.aspx");
			RouteTable.Routes.MapPageRoute("Document", "van-ban/{groupName}/{Id}/{title}", "~/Modules/News/NewsDetail.aspx");
			RouteTable.Routes.MapPageRoute("Images", "thu-vien-anh", "~/Modules/Images/ImageList.aspx");
			RouteTable.Routes.MapPageRoute("GroupImages", "{GroupId}/thu-vien-anh", "~/Modules/Images/ImageList.aspx");
			RouteTable.Routes.MapPageRoute("Videos", "video-hoi", "~/Modules/Videos/VideosList.aspx");
			RouteTable.Routes.MapPageRoute("Search", "tim-kiem", "~/Modules/Page/Search.aspx");
            //Page routes
            RouteTable.Routes.MapPageRoute("PageDetail", "trang-tin/{title}-{pageId}", "~/Modules/Page/PageDetail.aspx");
            RouteTable.Routes.MapPageRoute("Contact", "lien-he", "~/Modules/Page/Contact.aspx");
            RouteTable.Routes.MapPageRoute("Logon", "Logon", "~/Modules/Page/Logon.aspx");
            RouteTable.Routes.MapPageRoute("Admin", "admin", "~/Admins/Default.aspx");

			////News routes
			//RouteTable.Routes.MapPageRoute("NewsEn", "tin-tuc/{lang}/{GroupId}/{title}", "~/Modules/News/ViewNews.aspx");
			//RouteTable.Routes.MapPageRoute("GroupNewsEn", "tin-tuc/{lang}/{GroupId}/{title}/trang-{page}", "~/Modules/News/ViewNews.aspx");
			//RouteTable.Routes.MapPageRoute("NewsDetailEn", "tin-tuc/{lang}/{groupName}/{Id}/{title}", "~/Modules/News/NewsDetail.aspx");
			//RouteTable.Routes.MapPageRoute("ImagesEn", "thu-vien-anh/{lang}/{GroupId}/{title}", "~/Modules/Images/ImageList.aspx");
			////Page routes
			//RouteTable.Routes.MapPageRoute("PageDetailEn", "trang-tin/{lang}/{title}-{pageId}", "~/Modules/Page/PageDetail.aspx");
			//RouteTable.Routes.MapPageRoute("ContactEn", "{lang}/lien-he", "~/Modules/Page/Contact.aspx");
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();
            Application["HomNay"] = 0;
            Application["HomQua"] = 0;
            Application["TuanNay"] = 0;
            Application["TuanTruoc"] = 0;
            Application["ThangNay"] = 0;
            Application["ThangTruoc"] = 0;
            Application["TatCa"] = 0;
            Application["visitors_online"] = 0;
			GlobalClass.GetConfigMail();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 150;
            Application.Lock();
            Application["visitors_online"] = Convert.ToInt32(Application["visitors_online"]) + 1;
            Application.UnLock();
            try
            {
                DataTable dtb = TB_ThongKeService.spThongKe_Edit();
                if (dtb.Rows.Count > 0)
                {
                    Application["HomNay"] = long.Parse("0" + dtb.Rows[0]["HomNay"]).ToString("#,###");
                    Application["HomQua"] = long.Parse("0" + dtb.Rows[0]["HomQua"]).ToString("#,###");
                    Application["TuanNay"] = long.Parse("0" + dtb.Rows[0]["TuanNay"]).ToString("#,###");
                    Application["TuanTruoc"] = long.Parse("0" + dtb.Rows[0]["TuanTruoc"]).ToString("#,###");
                    Application["ThangNay"] = long.Parse("0" + dtb.Rows[0]["ThangNay"]).ToString("#,###");
                    Application["ThangTruoc"] = long.Parse("0" + dtb.Rows[0]["ThangTruoc"]).ToString("#,###");
                    Application["TatCa"] = long.Parse("0" + dtb.Rows[0]["TatCa"]).ToString("#,###");
                }
                dtb.Dispose();
            }
            catch { }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
			Response.Redirect("/InnerError.html", false);
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["visitors_online"] = Convert.ToUInt32(Application["visitors_online"]) - 1;
            Application.UnLock();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}