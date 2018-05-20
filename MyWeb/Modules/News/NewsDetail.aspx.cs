using System;
using System.Data;
using System.Web;
using System.Web.UI;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb.Modules.News
{
    public partial class NewsDetail : System.Web.UI.Page
    {
		protected string sTitleName = string.Empty;
		protected string sContent = string.Empty;
		protected string titleReleate = string.Empty;
		protected string sDetail = string.Empty;
		protected string sDateTime = string.Empty;
        string groupName = string.Empty;
        string id = string.Empty;
		protected string Lang = "vi";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["Id"] != null)
            {
                id = Page.RouteData.Values["Id"] as string;
			} if (Page.RouteData.Values["lang"] != null)
			{
				Lang = Page.RouteData.Values["lang"] as string;
			}
            if (!IsPostBack)
            {
                try
                {
                    DataTable dtNews = NewsService.News_GetById(id);
                    if (dtNews.Rows.Count > 0)
                    {
						sTitleName = dtNews.Rows[0]["Name"].ToString();
						sContent = dtNews.Rows[0]["Content"].ToString();
						sDetail = dtNews.Rows[0]["Detail"].ToString();
						sDateTime = DateTimeClass.ConvertDate(dtNews.Rows[0]["Date"].ToString(),"dd/MM/yyyy - HH:mm");
						//DataTable dtGroup = GroupNewsService.GroupNews_GetById(dtNews.Rows[0]["GroupNewsId"].ToString());
						//if (dtGroup.Rows.Count > 0)
						//{
						//	groupName = dtGroup.Rows[0]["Name"].ToString();

						//	DataTable dtGroupSub = GroupNewsService.GroupNews_GetByTop("", "Active = 1 AND len([Level]) < len('" + dtGroup.Rows[0]["Level"].ToString() + "') AND left([Level], 5) = left('" + dtGroup.Rows[0]["Level"].ToString() + "', 5)", "[Level]");
						//	if (dtGroupSub.Rows.Count > 0)
						//	{
						//		for (int i = 0; i < dtGroupSub.Rows.Count; i++)
						//		{
						//			ltrCrumb.Text += "<li class='crumb-" + (i + 1).ToString() + "'>\n";
						//			ltrCrumb.Text += "<a href='" + PageHelper.GeneralGroupUrl(Consts.CON_SAN_PHAM, dtGroupSub.Rows[i]["Id"].ToString(), dtGroupSub.Rows[i]["Name"].ToString()) + "' title='" + dtGroupSub.Rows[i]["Name"].ToString() + "'>" + dtGroupSub.Rows[i]["Name"].ToString() + "</a>\n";
						//			ltrCrumb.Text += "</li>\n";
						//		}
						//	}
						//}
						DataTable dtNewsReleate = NewsService.News_GetByTop("4", "Id <> " + id + " AND Active = 1 AND GroupNewsId = '" + dtNews.Rows[0]["GroupNewsId"].ToString() + "' AND Language='" + Lang + "'", "Date Desc");
                        if (dtNewsReleate.Rows.Count > 0)
                        {
                            titleReleate = "Tin liên quan";
							rptReleative.DataSource = PageHelper.ModifyData(dtNewsReleate);
							rptReleative.DataBind();
                        }
						dtNewsReleate.Clear();
						dtNewsReleate.Dispose();
						DataTable dtLastNews = NewsService.News_GetByTop("10", "Id <> " + id + " AND Active = 1 AND Language='" + Lang + "'", "Date Desc");
						dtLastNews = PageHelper.ModifyData(dtLastNews);
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