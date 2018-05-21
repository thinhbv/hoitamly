using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using System.Data;
using MyWeb.Common;

namespace MyWeb.Modules.News
{
    public partial class ViewNews : System.Web.UI.Page
    {
        protected string groupName = string.Empty;
        protected int totalcount = 0;
        string id = string.Empty;
		private string pagenum = "1";
		private string perpage = "10";
		protected string Lang = "vi";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["GroupId"] != null)
            {
                id = Page.RouteData.Values["GroupId"] as string;
            }
            if (Page.RouteData.Values["page"] != null)
            {
                pagenum = Page.RouteData.Values["page"] as string;
            }
            if (!IsPostBack)
            {
                try
                {
					if (Request.Cookies["CurrentLanguage"] != null)
					{
						Lang = Request.Cookies["CurrentLanguage"].Value;
					}
                    DataTable dtGrp = GroupNewsService.GroupNews_GetById(id);
                    if (dtGrp.Rows.Count > 0)
                    {
						groupName = dtGrp.Rows[0]["Name"].ToString();
						Label lblName = (Label)Master.FindControl("lblName");
						if (lblName != null)
						{
							lblName.Text = groupName;
						}
                        totalcount = NewsService.News_GetCount(dtGrp.Rows[0]["Level"].ToString());
                        DataTable dtNews = NewsService.News_Pagination(pagenum, perpage, dtGrp.Rows[0]["Level"].ToString(), Lang);
                        if (dtNews.Rows.Count > 0)
                        {
                            rptNews.DataSource = PageHelper.ModifyData(dtNews);
                            rptNews.DataBind();
							ltrPaging.Text = GeneralPaging();
                        }
					}
				}
				catch (Exception ex)
				{
					MailSender.SendMail("", "", "Error System", ex.Message);
				}
            }
        }
		private string GeneralPaging()
		{
			string strPaging = string.Empty;
			int totalPage = totalcount / int.Parse(perpage);
			int currPage;
			string urlOrigin = Request.Path;
			if (urlOrigin.IndexOf("?") > -1)
			{
				urlOrigin = urlOrigin + "&" + Consts.CON_PARAM_URL_PAGE + "=";
			}
			else
			{
				urlOrigin = urlOrigin + "?" + Consts.CON_PARAM_URL_PAGE + "=";
			}

			if (int.TryParse(pagenum, out currPage) == false)
			{
				currPage = 1;
			}
			if (totalcount % int.Parse(perpage) > 0)
			{
				totalPage = totalPage + 1;
			}
			if (currPage == 1)
			{
				strPaging += "<li id='pagination_previous_bottom' class='disabled pagination_previous'>\n";
				strPaging += "<span><i class='fa fa-chevron-left'></i><b>Previous</b></span></li>\n";
			}
			else
			{
				strPaging += "<li id='pagination_previous_bottom' class='pagination_previous'>\n";
				strPaging += "<a href='" + urlOrigin + (currPage - 1).ToString() + "'>";
				strPaging += "<b>Previous</b> <i class='fa fa-chevron-left'></i></a></li>\n";
			}
			if (totalPage < 6)
			{
				for (int i = 1; i < totalPage + 1; i++)
				{
					if (currPage == i)
					{
						strPaging += "<li class='active current'><span><span>" + i.ToString() + "</span></span></li>\n";
					}
					else
					{
						strPaging += "<li><a href='" + urlOrigin + i.ToString() + "'><span>" + i.ToString() + "</span></a></li>\n";
					}
				}
			}
			else
			{
				if (currPage < 6)
				{
					for (int i = 1; i < 6 + 1; i++)
					{
						if (currPage == i)
						{
							strPaging += "<li class='active current'><span><span>" + i.ToString() + "</span></span></li>\n";
						}
						else
						{
							strPaging += "<li><a href='" + urlOrigin + i.ToString() + "'><span>" + i.ToString() + "</span></a></li>\n";
						}
					}
					strPaging += "<li><span>...</span></li>\n";
					strPaging += "<li><a href='" + urlOrigin + totalPage.ToString() + "'><span>" + totalPage.ToString() + "</span></a></li>\n";
				}
				else
				{
					strPaging += "<li><a href='" + urlOrigin + "1'><span>1</span></a></li>\n";
					strPaging += "<li><span>...</span></li>\n";
					if (totalPage - currPage > 6)
					{
						strPaging += "<li><a href='" + urlOrigin + (currPage - 2).ToString() + "'><span>" + (currPage - 2).ToString() + "</span></a></li>\n";
						strPaging += "<li><a href='" + urlOrigin + (currPage - 1).ToString() + "'><span>" + (currPage - 1).ToString() + "</span></a></li>\n";
						strPaging += "<li class='active current'><span><span>" + currPage.ToString() + "</span></span></li>\n";
						strPaging += "<li><a href='" + urlOrigin + (currPage + 1).ToString() + "'><span>" + (currPage + 1).ToString() + "</span></a></li>\n";
						strPaging += "<li><a href='" + urlOrigin + (currPage + 2).ToString() + "'><span>" + (currPage + 2).ToString() + "</span></a></li>\n";
					}
					else
					{
						for (int i = 6; i < totalPage + 1; i++)
						{
							if (i == currPage)
							{
								strPaging += "<li class='active current'><span><span>" + i.ToString() + "</span></span></li>\n";
							}
							else
							{
								strPaging += "<li><a href='" + urlOrigin + i.ToString() + "'><span>" + i.ToString() + "</span></a></li>\n";
							}
						}
					}
				}
			}
			if (currPage == totalPage)
			{
				strPaging += "<li id='pagination_next_bottom' class='disabled pagination_next'>\n";
				strPaging += "<span><i class='fa fa-chevron-right'></i><b>Next</b></span></li>\n";
			}
			else
			{
				strPaging += "<li id='pagination_next_bottom' class='pagination_next'>\n";
				strPaging += "<a href='" + urlOrigin + (currPage + 1).ToString() + "'>";
				strPaging += "<b>Next</b> <i class='fa fa-chevron-right'></i></a></li>\n";
			}

			return strPaging;
		}
    }
}