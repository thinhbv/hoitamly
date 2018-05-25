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

namespace MyWeb.Admins
{
	public partial class Commission : System.Web.UI.Page
	{
		static string Id = "";
		static bool Insert = false;
		static string Level = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				BindGrid();
			}
		}

		private void BindGrid()
		{
			grdGroupImages.DataSource = GroupImagesService.GroupImages_GetByTop("","Active = 1","");
			grdGroupImages.DataBind();
			if (grdGroupImages.PageCount <= 1)
			{
				grdGroupImages.PagerStyle.Visible = false;
			}
			else
			{
				grdGroupImages.PagerStyle.Visible = true;
			}
			if (drlUser.SelectedValue != string.Empty)
			{
				DataTable dtU = UserService.User_GetById(drlUser.SelectedValue);
				if (dtU.Rows.Count > 0)
				{
					string sCommission = dtU.Rows[0]["Commission"].ToString();
					string[] arrGroup;
					if (string.IsNullOrEmpty(sCommission) == false && sCommission.IndexOf(",") > -1)
					{
						if (sCommission.IndexOf(",") > -1)
						{
							arrGroup = sCommission.Split((char)',');
						}
						else
						{
							arrGroup = new string[]{sCommission};
						}
						DataGridItem item = default(DataGridItem);
						string strId = string.Empty;
						for (int i = 0; i < grdGroupImages.Items.Count; i++)
						{
							item = grdGroupImages.Items[i];
							if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
							{
								strId = item.Cells[1].Text;
								if (arrGroup.Contains(strId))
								{
									((CheckBox)item.FindControl("ChkSelect")).Checked = true;
								}
							}
						}
					}
				}
			}
		}

		protected void grdGroupImages_ItemDataBound(object sender, DataGridItemEventArgs e)
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
					string tableRowId = grdGroupImages.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

		protected void drlUser_SelectedIndexChanged(object sender, EventArgs e)
		{
			grdGroupImages.CurrentPageIndex = 0;
			BindGrid();
		}
		protected void grdGroupImages_PageIndexChanged(object sender, EventArgs e)
		{
			grdGroupImages.CurrentPageIndex = 0;
			BindGrid();
		}
		protected void Update_Click(object sender, EventArgs e)
		{
			DataGridItem item = default(DataGridItem);
			string strId = string.Empty;
			for (int i = 0; i < grdGroupImages.Items.Count; i++)
			{
				item = grdGroupImages.Items[i];
				if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
				{
					if (((CheckBox)item.FindControl("ChkSelect")).Checked)
					{
						strId += item.Cells[1].Text + ",";
						//GroupImagesService.GroupImages_Delete(strId);
						//SqlDataProvider sql = new SqlDataProvider();
						//sql.ExecuteNonQuery("Delete From [Images] where GroupId='" + strId + "'");
					}
				}
			}
			if (string.IsNullOrEmpty(strId) == false)
			{
				strId = strId.Substring(0, strId.Length - 1);
			}
			SqlDataProvider sql = new SqlDataProvider();
			sql.ExecuteNonQuery("UPDATE [User] set Commission='" + strId + "' WHERE Id=" + drlUser.SelectedValue);
			grdGroupImages.CurrentPageIndex = 0;
			BindGrid();
		}

		protected void LoadDropDownListGroupImage()
		{
			drlUser.Items.Clear();
			drlUser.Items.Add(new ListItem("--Chọn người dùng--", ""));
			DataTable dtUser = new DataTable();
			dtUser = UserService.User_GetByTop("", "Active = 1", "");

			for (int i = 0; i < dtUser.Rows.Count; i++)
			{
				drlUser.Items.Add(new ListItem(dtUser.Rows[i]["Name"].ToString(), dtUser.Rows[i]["Id"].ToString()));
			}
			drlUser.DataBind();
		}
	}
}