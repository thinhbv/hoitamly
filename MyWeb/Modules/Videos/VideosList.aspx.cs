using System;
using System.Collections.Generic;

using System.Web;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;
using System.Data;

namespace MyWeb.Modules.Videos
{
	public partial class VideosList : System.Web.UI.Page
	{
		protected string GroupId = string.Empty;
		private string GroupName = string.Empty;
		private string Lang = string.Empty;
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
					DataTable dtVideo = VideosService.Videos_GetByTop("", "Active = 1 AND Language = '" + Lang + "'", "Ord");
					for (int i = 0; i < dtVideo.Rows.Count; i++)
					{
						rptVideos.DataSource = dtVideo;
						rptVideos.DataBind();
					}
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message);
			}
		}
	}
}