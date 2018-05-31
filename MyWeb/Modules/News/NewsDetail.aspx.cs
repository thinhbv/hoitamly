using System;
using System.Data;
using System.Web;
using System.Web.UI;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace MyWeb.Modules.News
{
    public partial class NewsDetail : BasePage
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
						if (Request.RawUrl.IndexOf(Consts.CON_VAN_BAN) < 0)
						{
							SqlDataProvider sql = new SqlDataProvider();
							string view = dtNews.Rows[0]["Views"].ToString();
							view = (int.Parse(view) + 1).ToString();
							string sSQL = "Update News set Views=" + view + " Where Id=" + id;
							sql.ExecuteNonQuery(sSQL);

							DataTable dtG = GroupNewsService.GroupNews_GetById(dtNews.Rows[0]["GroupNewsId"].ToString());
							if (dtG.Rows.Count > 0)
							{
								idU_OtherGroupNews.Level = dtG.Rows[0]["Level"].ToString();
								groupName = dtG.Rows[0]["Name"].ToString();
								if (lblName != null)
								{
									lblName.Text = groupName;
								}
							}

							DataTable dtNewsReleate = NewsService.News_GetByTop("4", "Id <> " + id + " AND Active = 1 AND GroupNewsId = '" + dtNews.Rows[0]["GroupNewsId"].ToString() + "' AND Language='" + Lang + "'", "Date Desc");
							if (dtNewsReleate.Rows.Count > 0)
							{
								if (Lang == "en")
								{
									titleReleate = "Relative News";
								}
								else
								{
									titleReleate = "Tin liên quan";
								}
								rptReleative.DataSource = PageHelper.ModifyData(dtNewsReleate, Consts.CON_TIN_TUC);
								rptReleative.DataBind();
							}
							dtNewsReleate.Clear();
							dtNewsReleate.Dispose();
						}
						else
						{
							idU_OtherGroupNews.Visible = false;
							rptReleative.Visible = false;
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