using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;
using System.Data.SqlClient;
using System.Data;

namespace MyWeb.Modules.News
{
	public partial class DocumentDetail : System.Web.UI.Page
	{
		protected string sTitleName = string.Empty;
		protected string sContent = string.Empty;
		protected string titleReleate = string.Empty;
		protected string sDetail = string.Empty;
		protected string sDateTime = string.Empty;
		protected string groupName = string.Empty;
		protected string id = string.Empty;
		protected string Lang = "vi";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Page.RouteData.Values["Id"] != null)
			{
				id = Page.RouteData.Values["Id"] as string;
			}
			if (Microsoft.VisualBasic.Information.IsNumeric(id) == false)
			{
				return;
			}
			if (Request.Cookies["CurrentLanguage"] != null)
			{
				Lang = Request.Cookies["CurrentLanguage"].Value;
			}
			if (!IsPostBack)
			{
				try
				{
					DataTable dtNews = NewsService.News_GetById(id);
					if (dtNews.Rows.Count > 0)
					{
						Label lblName = (Label)Master.FindControl("lblName"); 
						sTitleName = dtNews.Rows[0]["Name"].ToString();
						Page.Title = sTitleName;
						sContent = dtNews.Rows[0]["Content"].ToString();
						sDetail = dtNews.Rows[0]["Detail"].ToString();
						sDateTime = DateTimeClass.ConvertDate(dtNews.Rows[0]["Date"].ToString(), "dd/MM/yyyy - HH:mm");

						DataTable dtG = GroupNewsService.GroupNews_GetById(dtNews.Rows[0]["GroupNewsId"].ToString());
						if (dtG.Rows.Count > 0)
						{
							groupName = dtG.Rows[0]["Name"].ToString();
							if (lblName != null)
							{
								lblName.Text = groupName;
							}
						}
						DataTable dtLastNews = NewsService.News_GetByTop("10", "Id <> " + id + "  AND GroupNewsId IN (Select Id from GroupNews where Active=1 AND [Index]=0) AND Active = 1 AND Language='" + Lang + "'", "Date Desc");
						dtLastNews = PageHelper.ModifyData(dtLastNews, Consts.CON_TIN_TUC);
						DataTable dtLeft = dtLastNews.Clone();
						for (int i = 0; i < dtLastNews.Rows.Count; i++)
						{
							DataRow dr = dtLastNews.Rows[i];
							if (i < 5)
							{
								dtLeft.Rows.Add(dr.ItemArray);
								dr.Delete();
								dtLastNews.AcceptChanges();
							}
							else
							{
								break;
							}
						}
						rptLeft.DataSource = dtLeft;
						rptLeft.DataBind();
						rptRight.DataSource = dtLastNews;
						rptRight.DataBind();
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