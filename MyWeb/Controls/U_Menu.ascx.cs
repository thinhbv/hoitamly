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
using System.Web.UI.HtmlControls;

namespace MyWeb.Controls
{
    public partial class U_Menu : System.Web.UI.UserControl
    {
		protected string keyword = string.Empty;
		DataTable dtPage = new DataTable();
		private string Lang = "vi";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
				try
				{
					if (Request.Cookies["CurrentLanguage"] != null)
					{
						Lang = Request.Cookies["CurrentLanguage"].Value;
					}
					
					if (Request.QueryString["key"] != null)
					{
						keyword = Request.QueryString["key"];
					}
					ShowMenu();
				}
				catch (Exception ex)
				{
					MailSender.SendMail("", "", "Error System", ex.Message);
				}
            }
        }

        #region Hiển thị menu chính
        /// <summary>
        /// Hiển thị menu chính
        /// </summary>
        private void ShowMenu()
        {
			dtPage = PageService.Page_GetByTop("", "Active=1 and Position IN (1,2) AND Language='" + Lang + "'", "Level, Ord");
            if (dtPage.Rows.Count > 0)
            {
				rptMenu.DataSource = dtPage.Select("LEN(Level) = 5").CopyToDataTable();
				rptMenu.DataBind();
            }
            dtPage = null;
        }
		protected void rptMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			RepeaterItem item = e.Item;
			if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
			{
				Repeater rptSub = (Repeater)item.FindControl("rptMenuSub");
				HtmlGenericControl menusub = (HtmlGenericControl)item.FindControl("menusub");
				Literal ltrLastItem = (Literal)item.FindControl("ltrLastItem");

				if (rptSub != null)
				{
					string level = DataBinder.Eval(item.DataItem, "Level").ToString();
					DataRow[] drSub = dtPage.Select("LEN(level)=10 AND substring(level,1,5)='" + level.Substring(0, 5) + "'");
					if (drSub != null && drSub.Length > 0)
					{
						menusub.Visible = true;
						DataTable dtTmp = drSub.CopyToDataTable();
						for (int i = 0; i < drSub.Length; i++)
						{
							if (i == drSub.Length - 1)
							{
								ltrLastItem.Text = "<li><a href='" + drSub[i]["Link"].ToString() + "' title='" + drSub[i]["Name"].ToString() + "'><span>" + drSub[i]["Name"].ToString() + "</span></a></li>";
								dtTmp.Rows[i].Delete();
								dtTmp.AcceptChanges();
							}
						}
						rptSub.DataSource = dtTmp;
						rptSub.DataBind();
					}
					else
					{
						menusub.Visible = false;
					}
				}
			}
		}
        #endregion

    }
}