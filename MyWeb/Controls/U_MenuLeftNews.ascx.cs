using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Data;
using MyWeb.Common;

namespace MyWeb.Controls
{
    public partial class U_MenuLeftNews : System.Web.UI.UserControl
    {
		protected string VideoName = string.Empty;
		protected string vId = string.Empty;
		private string Lang = "vi";
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
				if (!IsPostBack)
				{
					if (Request.Cookies["CurrentLanguage"] != null)
					{
						Lang = Request.Cookies["CurrentLanguage"].Value;
					}
					DataTable dtVanBan = NewsService.News_GetByTop("", "Active=1 AND GroupNewsId IN (Select Id from GroupNews where Active=1 AND [Index]=1 AND Language='" + Lang + "') AND Language='" + Lang + "'", "Date DESC");
					if (dtVanBan.Rows.Count > 0)
					{
						rptVanBan.DataSource = PageHelper.ModifyData(dtVanBan);
						rptVanBan.DataBind();
						rptVanBan01.DataSource = dtVanBan;
						rptVanBan01.DataBind();
					}
					dtVanBan.Clear();
					dtVanBan.Dispose();
					DataTable dtVideo = VideosService.Videos_GetByTop("10", "Active=1 AND Language='" + Lang + "'", "Ord");
					if (dtVideo.Rows.Count > 0)
					{
						vId = dtVideo.Rows[0]["Link"].ToString();
						VideoName = dtVideo.Rows[0]["Name"].ToString();
						rptVideo.DataSource = dtVideo;
						rptVideo.DataBind();
					}
					DataTable dtNews = NewsService.News_GetByTop("10", "Active=1 AND Language='" + Lang + "'", "Views DESC");
					rptReadMost.DataSource = PageHelper.ModifyData(dtNews);
					rptReadMost.DataBind();
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message);
			}
        }
    }
}