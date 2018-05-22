using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;

namespace MyWeb.Modules.Page
{
    public partial class PageDetail : BasePage
    {
        protected string pageId = string.Empty;
		protected string sTitleName = string.Empty;
		protected string sContent = string.Empty;
		protected string sDateTime = string.Empty;
		protected string sDetail = string.Empty;
		private string Lang = "vi";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["pageId"] != null)
            {
                pageId = Page.RouteData.Values["pageId"] as string;
            }
            if (!IsPostBack)
            {
                try
                {
					if (Request.Cookies["CurrentLanguage"] != null)
					{
						Lang = Request.Cookies["CurrentLanguage"].Value;
					}
					if (Microsoft.VisualBasic.Information.IsNumeric(pageId) == false)
					{
						return;
					}
                    DataTable dtPage = PageService.Page_GetById(pageId);
                    if (dtPage.Rows.Count > 0)
                    {
						sTitleName = dtPage.Rows[0]["Name"].ToString();
						sDateTime = DateTimeClass.ConvertDate(dtPage.Rows[0]["Image"].ToString(), "dd/MM/yyy - HH:mm");
						sContent = dtPage.Rows[0]["Description"].ToString();
						sDetail = dtPage.Rows[0]["Detail"].ToString();
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