using System;
using System.Data;
using System.Web;
using System.Web.UI;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb.Modules.News
{
    public partial class NewsDetail : BasePage
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
			} 
            if (!IsPostBack)
            {
                try
                {
					if (Request.Cookies["CurrentLanguage"] != null)
					{
						Lang = Request.Cookies["CurrentLanguage"].Value;
					}
                    DataTable dtNews = NewsService.News_GetById(id);
                    if (dtNews.Rows.Count > 0)
                    {
						sTitleName = dtNews.Rows[0]["Name"].ToString();
						sContent = dtNews.Rows[0]["Content"].ToString();
						sDetail = dtNews.Rows[0]["Detail"].ToString();
						sDateTime = DateTimeClass.ConvertDate(dtNews.Rows[0]["Date"].ToString(),"dd/MM/yyyy - HH:mm");

						DataTable dtG = GroupNewsService.GroupNews_GetById(dtNews.Rows[0]["GroupNewsId"].ToString());
						if (dtG.Rows.Count > 0)
						{
							idU_OtherGroupNews.Level = dtG.Rows[0]["Level"].ToString();
						}

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