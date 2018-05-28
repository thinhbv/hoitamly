using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Business;
using MyWeb.Common;
using MyWeb.Data;
using System.Data;

namespace MyWeb.Controls
{
    public partial class U_Banner : System.Web.UI.UserControl
    {
		protected string Lang = "vi";
		string id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
		{
			if (Page.RouteData.Values["GroupId"] != null)
			{
				id = Page.RouteData.Values["GroupId"] as string;
			}
            if (!IsPostBack)
            {
				try
				{
					if (Request.Cookies["CurrentLanguage"] != null)
					{
						Lang = Request.Cookies["CurrentLanguage"].Value;
					}
					//Lấy thông tin banner
					DataTable dtBanner = new DataTable();
					if (string.IsNullOrEmpty(id))
					{
						dtBanner = NewsService.News_GetByTop("", "Active=1 AND Position=4 AND GroupNewsId IN (Select Id from GroupNews where Active=1 AND [Index]=0 AND Language='" + Lang + "') AND Language='" + Lang + "'", "Date DESC");
					}
					else
					{
						DataTable dtG = GroupNewsService.GroupNews_GetById(id);
						if (dtG.Rows.Count > 0)
						{
							dtBanner = NewsService.News_GetByTop("", "Active=1 AND Position=4 AND GroupNewsId IN (Select Id From GroupNews Where Active=1 AND [Index]=0 AND Left(Level," + dtG.Rows[0]["Level"].ToString().Length + ")='" + dtG.Rows[0]["Level"].ToString() + "')" + " AND Language='" + Lang + "'", "Date DESC");
						}			
					}
					
					if (dtBanner.Rows.Count > 0)
					{
						rptBanner.DataSource = PageHelper.ModifyData(dtBanner);
						rptBanner.DataBind();
					}
					dtBanner.Clear();
					dtBanner.Dispose();
					//Lấy tin tức mới nhất
					DataTable dtNews = NewsService.News_GetByTop("5", "Active=1 AND GroupNewsId IN (Select Id from GroupNews where Active=1 AND [Index]=0) AND Language='" + Lang + "'", "Date DESC");
					if (dtNews.Rows.Count > 0)
					{
						rptNews.DataSource = PageHelper.ModifyData(dtNews);
						rptNews.DataBind();
					}
					dtNews.Clear();
					//Lấy tin tức hiển thị dưới banner
					dtNews = NewsService.News_GetByTop("4", "Active=1 AND GroupNewsId IN (Select Id from GroupNews where Active=1 AND [Index]=0) AND Position=2 AND Language='" + Lang + "'", "Date DESC");
					if (dtNews.Rows.Count > 0)
					{
						rptNews01.DataSource = PageHelper.ModifyData(dtNews);
						rptNews01.DataBind();
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