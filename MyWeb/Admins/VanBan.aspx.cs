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

namespace MyWeb.Admins
{
    public partial class VanBan : System.Web.UI.Page
    {
        static string Id = "";
        static bool Insert = false;
        static string where = "";
        private string listGroupId = string.Empty;
        SqlDataProvider sql = new SqlDataProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                NumberClass.OnlyInputNumber(txtOrd);
                LoadGroupNewsDropDownList();
                BindGrid(where);
            }
        }

        private void BindGrid(string where)
        {
            if (drlnhom.SelectedValue == "0")
			{
				if (string.IsNullOrEmpty(listGroupId))
				{
					for (int i = 1; i < ddlGroupNews.Items.Count; i++)
					{
						listGroupId += ddlGroupNews.Items[i].Value + ",";
					}
					listGroupId = listGroupId.Substring(0, listGroupId.Length - 1);
					if (string.IsNullOrEmpty(listGroupId))
					{
						return;
					}
				}
                grdNews.DataSource = NewsService.News_GetByTop("", "GroupNewsId IN (" + listGroupId + ")", "Date desc");
                grdNews.DataBind();
                if (grdNews.PageCount <= 1)
                {
                    grdNews.PagerStyle.Visible = false;
                }
                else
                {
                    grdNews.PagerStyle.Visible = true;
                }
            }
            else
            {
                String level = String.Empty;
                DataTable dtG = GroupNewsService.GroupNews_GetById(drlnhom.SelectedValue);
                if (dtG.Rows.Count > 0)
                {
                    level = dtG.Rows[0]["Level"].ToString();
                }
                where = "GroupNewsId in (Select Id From GroupNews Where [Index] = 1 AND left(Level,len('" + level + "'))='" + level + "')";
                DataTable dt = new DataTable();
                dt = NewsService.News_GetByTop("", where, "Date Desc");
                grdNews.DataSource = dt;
                grdNews.DataBind();
                if (grdNews.PageCount <= 1)
                {
                    grdNews.PagerStyle.Visible = false;
                }
                else
                {
                    grdNews.PagerStyle.Visible = true;
                }
            }
        }

        private void LoadGroupNewsDropDownList()
        {
            ddlGroupNews.Items.Clear();
            ddlGroupNews.Items.Add(new ListItem("--Chọn nhóm Văn bản--", ""));
            drlnhom.Items.Clear();
			drlnhom.Items.Add(new ListItem("--Chọn nhóm Văn bản--", "0"));
            DataTable dt = new DataTable();
            dt = GroupNewsService.GroupNews_GetByTop("", "Active = 1 AND [Index] = 1", "Level, Ord");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlGroupNews.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(dt.Rows[i]["Name"].ToString(), dt.Rows[i]["Level"].ToString()), dt.Rows[i]["Id"].ToString()));
                drlnhom.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(dt.Rows[i]["Name"].ToString(), dt.Rows[i]["Level"].ToString()), dt.Rows[i]["Id"].ToString()));
                listGroupId += dt.Rows[i]["Id"].ToString() + ",";
            }
            if (string.IsNullOrEmpty(listGroupId) == false)
            {
                listGroupId = listGroupId.Substring(0, listGroupId.Length - 1);
            }
            ddlGroupNews.DataBind();
            drlnhom.DataBind();
        }

        protected void grdNews_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            ListItemType itemType = e.Item.ItemType;
            if ((itemType != ListItemType.Footer) && (itemType != ListItemType.Separator))
            {
                if (itemType == ListItemType.Header)
                {
                    object checkBox = e.Item.FindControl("chkSelectAll");
                    if ((checkBox != null))
                    {
                        ((CheckBox)checkBox).Attributes.Add("onClick", "Javascript:chkSelectAll_OnClick(this)");
                    }
                }
                else
                {
                    string tableRowId = grdNews.ClientID + "_row" + e.Item.ItemIndex.ToString();
                    e.Item.Attributes.Add("id", tableRowId);
                    object checkBox = e.Item.FindControl("chkSelect");
                    if ((checkBox != null))
                    {
                        e.Item.Attributes.Add("onMouseMove", "Javascript:chkSelect_OnMouseMove(this)");
                        e.Item.Attributes.Add("onMouseOut", "Javascript:chkSelect_OnMouseOut(this," + e.Item.ItemIndex.ToString() + ")");
                        ((CheckBox)checkBox).Attributes.Add("onClick", "Javascript:chkSelect_OnClick(this," + e.Item.ItemIndex.ToString() + ")");
                    }
                }
            }
        }

        protected void grdNews_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdNews.CurrentPageIndex = e.NewPageIndex;
            BindGrid(where);
        }

        protected void grdNews_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            DataTable dt = new DataTable();
            dt = NewsService.News_GetById(strCA);
            switch (e.CommandName)
            {
                case "Edit":
                    Insert = false;
                    Id = strCA;
                    txtName.Text = dt.Rows[0]["Name"].ToString();
                    txtFile.Text = dt.Rows[0]["File"].ToString();
                    txtSoHieu.Text = dt.Rows[0]["Content"].ToString();
                    fckDetail.Value = dt.Rows[0]["Detail"].ToString();
                    txtDate.Text = DateTimeClass.ConvertDateTime(dt.Rows[0]["Date"].ToString());
                    txtPublic.Text = DateTimeClass.ConvertDateTime(dt.Rows[0]["LinkDemo"].ToString());
                    txtOrd.Text = dt.Rows[0]["Ord"].ToString();
                    chkActive.Checked = dt.Rows[0]["Active"].ToString() == "1" || dt.Rows[0]["Active"].ToString() == "True";
                    LoadGroupNewsDropDownList();
                    PageHelper.LoadDropDownListLanguage(ddlLanguage);
                    ddlLanguage.SelectedValue = dt.Rows[0]["Language"].ToString();
                    ddlGroupNews.Text = dt.Rows[0]["GroupNewsId"].ToString();
                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Active":
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    sql.ExecuteNonQuery("Update [News] set Active=" + strA + "  Where Id='" + strCA + "'");
                    BindGrid(where);
                    break;
                case "Delete":
                    sql.ExecuteNonQuery("Delete CommentNews where NewsID='" + strCA + "'");
                    NewsService.News_Delete(strCA);
                    BindGrid(where);
                    break;
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(this);
            LoadGroupNewsDropDownList();
            PageHelper.LoadDropDownListLanguage(ddlLanguage);
            txtDate.Text = DateTimeClass.ConvertDateTime(DateTime.Now, "dd/MM/yyyy hh:mm:ss tt");
            pnView.Visible = false;
            Insert = true;
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdNews.Items.Count; i++)
            {
                item = grdNews.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        sql.ExecuteNonQuery("Delete CommentNews where NewsID='" + strId + "'");
                        NewsService.News_Delete(strId);
                    }
                }
            }
            grdNews.CurrentPageIndex = 0;
            BindGrid(where);
        }

        protected void RefreshButton_Click(object sender, EventArgs e)
        {
            BindGrid(where);
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Data.News obj = new Data.News();
                obj.Id = Id;
                obj.Name = txtName.Text;
                obj.Image = "";
                obj.File = txtFile.Text;
                obj.Content = txtSoHieu.Text;
                obj.Detail = fckDetail.Value;
                obj.Date = DateTimeClass.ConvertDateTime(txtDate.Text, "MM/dd/yyyy HH:mm:ss");
                obj.Index = "1";
                obj.Ord = txtOrd.Text != "" ? txtOrd.Text : "1";
                obj.Active = chkActive.Checked ? "1" : "0";
                obj.Position = "0";
                obj.GroupNewsId = ddlGroupNews.SelectedValue;
                obj.GroupTagNews = StringClass.NameToTag(ddlGroupNews.SelectedItem.Text);
                obj.Description = "";
                obj.Keyword = "";
                obj.Views = "0";
				obj.LinkDemo = DateTimeClass.ConvertDateTime(txtPublic.Text, "MM/dd/yyyy HH:mm:ss");
                obj.Language = ddlLanguage.SelectedValue;
                if (Insert == true)
                {
                    NewsService.News_Insert(obj);
                }
                else
                {
                    NewsService.News_Update(obj);
                }
                BindGrid(where);
                pnView.Visible = true;
                pnUpdate.Visible = false;
                Insert = false;
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            pnView.Visible = true;
            pnUpdate.Visible = false;
            BindGrid(where);
            Insert = false;
        }
        protected void imgUpdateOrd_Click(object sender, ImageClickEventArgs e)
        {
            TextBox txt;
            try
            {
                foreach (DataGridItem item in this.grdNews.Items)
                {
                    txt = (TextBox)item.FindControl("txtOrd");
                    string strId = item.Cells[1].Text;
                    sql.ExecuteNonQuery("Update News set Ord='" + txt.Text + "' where Id='" + strId + "'");
                }
                lblThongbao.Text = "";
                BindGrid(where);
            }
            catch { lblThongbao.Text = "Bạn phải nhập số!"; }
        }

        protected void drlChuyenmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdNews.CurrentPageIndex = 0;
            BindGrid(where);
        }
    }
}