using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using System.Data;
using MyWeb.Common;

namespace MyWeb.Modules.Page
{
	public partial class Search : System.Web.UI.Page
	{
		protected string groupName = string.Empty;
		protected int totalcount = 0;
		protected string key = string.Empty;
		protected string Lang = "vi";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Request.QueryString["key"] != null)
			{
				key = Request.QueryString["key"];
			}
			if (!IsPostBack)
			{
				try
				{
					if (Request.Cookies["CurrentLanguage"] != null)
					{
						Lang = Request.Cookies["CurrentLanguage"].Value;
					}
					DataTable dtNews = new DataTable();
					if (string.IsNullOrEmpty(key))
					{
						Page.Title = "Hội Tâm Lý Học Xã Hội Việt Nam";
						dtNews = NewsService.News_GetByTop("", "Active = 1 AND GroupNewsId IN (Select Id From GroupNews Where Active=1 AND [Index]=0 AND Language='" + Lang + "') AND Language='" + Lang + "'", "");
					}
					else
					{
						Page.Title = key + " | Hội Tâm Lý Học Xã Hội Việt Nam";
						string where = "Active = 1 AND GroupNewsId IN (Select Id From GroupNews Where Active=1 AND [Index]=0 AND Language='" + Lang + "') AND Language='" + Lang + "' AND ";
						where = "(Name like '%" + key + "%' OR " + "Name like '%" + key + "%' OR " + "Name like '%" + key + "%')";
						dtNews = NewsService.News_GetByTop("", where, "Date DESC");
					}
					totalcount = dtNews.Rows.Count;
					if (dtNews.Rows.Count > 0)
					{
						rptNews.DataSource = PageHelper.ModifyData(dtNews, Consts.CON_TIN_TUC);
						rptNews.DataBind();
					}
				}
				catch (Exception ex)
				{
					MailSender.SendMail("", "", "Error System", ex.Message);
				}
			}
		}
	}
}