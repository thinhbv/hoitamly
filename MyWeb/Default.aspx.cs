﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;
using System.Data;

namespace MyWeb
{
	public partial class Default : BasePage
    {
		DataTable dtNews = new DataTable();
		DataTable dtGrp = new DataTable();
		protected string Lang = "vi";
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
				if (!IsPostBack)
				{
					if (Request.Cookies["CurrentLanguage"] != null)
					{
						Lang = Request.Cookies["CurrentLanguage"].Value;
					}
					if (Lang == "vi")
					{
						Page.Title = "Hội Tâm Lý Học Xã Hội Việt Nam";
					}
					else
					{
						Page.Title = "VietNam Association Of Social Psychology";
					}
					dtGrp = GroupNewsService.GroupNews_GetByTop("", "Active=1 AND [Index]=0 AND Language='" + Lang + "'", "[Level], Ord");
					dtNews = NewsService.News_GetByTop("", "Active=1 AND GroupNewsId IN (Select Id from GroupNews where Active=1 AND [Index]=0) AND Position=3 AND Language='" + Lang + "'", "Date DESC");
					if (dtGrp.Rows.Count > 0)
					{
						dtGrp = PageHelper.ModifyDataGroup(dtGrp);
						rptGroupNews.DataSource = dtGrp.Select("Len(Level)=5").CopyToDataTable();
						rptGroupNews.DataBind();
					}
				}
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "","Error System", ex.Message);
			}
        }
		protected void rptNews_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			RepeaterItem item = e.Item;
			if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
			{
				Repeater rptGroupNewsSub = (Repeater)item.FindControl("rptGroupNewsSub");
				Repeater rptNews = (Repeater)item.FindControl("rptNews");
				Repeater rptNewsOne = (Repeater)item.FindControl("rptNewsOne");
				Literal ltrNews = (Literal)item.FindControl("ltrNews");
				
				if (rptGroupNewsSub != null)
				{
					string level = DataBinder.Eval(item.DataItem, "Level").ToString();
					string sGroupId = DataBinder.Eval(item.DataItem, "Id").ToString();
					DataRow[] drSub = dtGrp.Select("LEN(level)=10 AND substring(level,1,5)='" + level.Substring(0, 5) + "'");
					if (drSub != null && drSub.Length > 0)
					{
						rptGroupNewsSub.DataSource = drSub.CopyToDataTable();
						rptGroupNewsSub.DataBind();
					}
					string strGroup = "(" + sGroupId;
					for (int i = 0; i < drSub.Length; i++)
					{
						strGroup += "," + drSub[i]["Id"].ToString();
					}
					strGroup += ")";
					DataRow[] drNews = dtNews.Select("GroupNewsId IN " + strGroup, "Date DESC");
					if (drNews != null && drNews.Length > 0)
					{
						DataTable dtTemp = PageHelper.ModifyData(drNews.CopyToDataTable(), Consts.CON_TIN_TUC);
						DataTable dtNewsOne = dtTemp.AsEnumerable().Take(1).CopyToDataTable();
						rptNewsOne.DataSource = dtNewsOne;
						rptNewsOne.DataBind();
						dtTemp.Rows[0].Delete();
						dtTemp.AcceptChanges();
						if (dtTemp.Rows.Count == 0)
						{
							return;
						}
						string sLink = dtTemp.Rows[0]["Link"].ToString();
						string sName = dtTemp.Rows[0]["Name"].ToString();
						string sImage = StringClass.ThumbImage(dtTemp.Rows[0]["Image"].ToString());
						ltrNews.Text += "<li class='top1'><a href='" + sLink + "'>\n";
						ltrNews.Text += "<img src='" + sImage + "' title='" + sName + "' alt='" + sName + "'><span>" + StringClass.FormatContentNews(sName, 100) + "</span></a></li>\n";

						dtTemp.Rows[0].Delete();
						dtTemp.AcceptChanges();
						rptNews.DataSource = dtTemp.AsEnumerable().Take(4).CopyToDataTable();
						rptNews.DataBind();
					}
				}
			}
		}
    }
}