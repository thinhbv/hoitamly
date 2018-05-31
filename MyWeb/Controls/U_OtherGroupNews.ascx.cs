using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;
using System.Data;

namespace MyWeb.Controls
{
	public partial class U_OtherGroupNews : System.Web.UI.UserControl
	{
		protected string Lang = "vi";
		string id = string.Empty;
		string groupid = string.Empty;
		private string _Level;
		DataTable dtNews = new DataTable();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Page.RouteData.Values["Id"] != null)
			{
				id = Page.RouteData.Values["Id"] as string;
			}
			if (Page.RouteData.Values["GroupId"] != null)
			{
				groupid = Page.RouteData.Values["GroupId"] as string;
			}
			if (!IsPostBack)
			{
				if (Request.Cookies["CurrentLanguage"] != null)
				{
					Lang = Request.Cookies["CurrentLanguage"].Value;
				}
				if (string.IsNullOrEmpty(Level))
				{
					return;
				}
				DataTable dtG = new DataTable();
				if (string.IsNullOrEmpty(groupid))
				{
					dtG = GroupNewsService.GroupNews_GetByTop("", "Active=1 AND Left([Level],5)='" + Level.Substring(0, 5) + "' AND Len([Level]) =10 AND Language='" + Lang + "'", "Level, Ord");
				}
				else
				{
					dtG = GroupNewsService.GroupNews_GetByTop("", "Id <> " + groupid + " AND Active=1 AND Left([Level],5)='" + Level.Substring(0, 5) + "' AND Len([Level]) =10 AND Language='" + Lang + "'", "Level, Ord");
				}
				if (dtG.Rows.Count > 0)
				{
					string strGroup = "IN (" + dtG.Rows[0]["Id"].ToString();
					for (int i = 1; i < dtG.Rows.Count; i++)
					{
						strGroup += "," + dtG.Rows[i]["Id"].ToString();
					}
					strGroup += ")";
					dtNews = NewsService.News_GetByTop("5", "Active=1 AND GroupNewsId " + strGroup + " AND Language='" + Lang + "'", "Date DESC");
					rptGroup.DataSource = PageHelper.ModifyDataGroup(dtG);
					rptGroup.DataBind();
				}
			}
		}
		protected void rptGroup_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			RepeaterItem item = e.Item;
			if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
			{
				Repeater rptNews = (Repeater)item.FindControl("rptNews");
				Literal ltrNews = (Literal)item.FindControl("ltrNews");
				string sGroupId = DataBinder.Eval(item.DataItem, "Id").ToString();
				if (dtNews.Rows.Count == 0)
				{
					return;
				}
				DataRow[] drRows = dtNews.Select("GroupNewsId=" + sGroupId);
				if (drRows != null && drRows.Length > 0)
				{
					DataTable dtTmp = PageHelper.ModifyData(drRows.CopyToDataTable(), Consts.CON_TIN_TUC);
					DataRow dr = dtTmp.Rows[0];
					ltrNews.Text += "<a href='" + dr["Link"].ToString() + "'>";
					ltrNews.Text += "<img src='" + StringClass.ThumbImage(dr["Image"].ToString()) + "' title='" + dr["Name"].ToString() + "' alt='" + dr["Name"].ToString() + "' /></a>";
					ltrNews.Text += "<h4><a href='" + dr["Link"].ToString() + "' title='" + dr["Name"].ToString() + "'>" + dr["Name"].ToString() + "</a></h4>";
					dr.Delete();
					dtTmp.AcceptChanges();
					rptNews.DataSource = dtTmp;
					rptNews.DataBind();
				}
				
			}
		}
		public string Level { get { return _Level; } set { _Level = value; } }	
	}
}