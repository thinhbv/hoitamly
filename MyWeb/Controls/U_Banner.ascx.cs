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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
				try
				{
					//Lấy thông tin banner
					DataTable dtBanner = new DataTable();
					dtBanner = NewsService.News_GetByTop("", "Active=1 AND Position=4", "Date DESC");
					if (dtBanner.Rows.Count > 0)
					{
						rptBanner.DataSource = PageHelper.ModifyData(dtBanner);
						rptBanner.DataBind();
					}
					dtBanner.Clear();
					dtBanner.Dispose();
					//Lấy tin tức mới nhất
					DataTable dtNews = NewsService.News_GetByTop("5", "Active=1", "Date DESC");
					if (dtNews.Rows.Count > 0)
					{
						rptNews.DataSource = PageHelper.ModifyData(dtNews);
						rptNews.DataBind();
					}
					dtNews.Clear();
					//Lấy tin tức hiển thị dưới banner
					dtNews = NewsService.News_GetByTop("8", "Active=1 AND Position=2", "Date DESC");
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