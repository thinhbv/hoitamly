using System;
using System.Web;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;
using System.Data;

namespace MyWeb.Common
{
	public class PageHelper : System.Web.UI.UserControl
	{
		private string[] Separator = new string[] { "," };
		public static Control FindControl(Control Root, string Id)
		{
			if (Root.ID == Id)
				return Root;
			foreach (Control Ctl in Root.Controls)
			{
				Control FoundCtl = FindControl(Ctl, Id);
				if (FoundCtl != null)
					return FoundCtl;
			}
			return null;
		}

		public static string ShowActiveImage(string ActiveCode)
		{
			string strReturn = ActiveCode == "1" || ActiveCode == "True" ? "stop.png" : "start.png";
			return GlobalClass.GetUrlAdminImage() + strReturn;
		}

		public static string ShowCheckImage(object ActiveCode)
		{
			string strReturn;
			if (ActiveCode == null)
			{
				strReturn = "uncheck.gif";
			}
			else
			{
				strReturn = ActiveCode.ToString() == "1" || ActiveCode.ToString() == "True" ? "check.gif" : "uncheck.gif";
			}
			return GlobalClass.GetUrlAdminImage() + strReturn;
		}

		public static string ShowActiveToolTip(string ActiveCode)
		{
			return ActiveCode == "1" || ActiveCode == "True" ? "Ẩn" : "Hiển thị";
		}

		public static string ShowActiveStatus(string ActiveCode)
		{
			return ActiveCode == "1" || ActiveCode == "True" ? "Hiển thị" : "Ẩn";
		}

		public static void LoadDropDownList(DropDownList ddl, ArrayList array)
		{
			ddl.DataSource = array;
			ddl.DataBind();
		}

		public static void LoadDropDownList(DropDownList ddl, string[] StringArray)
		{
			LoadDropDownList(ddl, StringArray, false);
		}

		public static void LoadDropDownList(DropDownList ddl, string[] StringArray, bool ListItem)
		{
			if (ListItem)
			{
				ddl.DataSource = StringArray2ListItem(StringArray);
				ddl.DataTextField = "Text";
				ddl.DataValueField = "Value";

			}
			else
			{
				ddl.DataSource = StringArray2ArrayList(StringArray);
			}
			ddl.DataBind();
		}

		public static List<ListItem> StringArray2ListItem(string[] StringArray)
		{
			char[] splitter = { ',', ';' };
			List<ListItem> list = new List<ListItem>();
			for (int i = 0; i < StringArray.Length; i++)
			{
				string[] arr = StringArray[i].Split(splitter);
				if (arr.Length > 1)
				{
					list.Add(new ListItem(arr[1], arr[0]));
				}
				else
				{
					list.Add(new ListItem(arr[0], arr[0]));
				}
			}
			return list;
		}

		public static ArrayList StringArray2ArrayList(string[] StringArray)
		{
			ArrayList arrlist = new ArrayList();
			for (int i = 0; i < StringArray.Length; i++)
			{
				arrlist.Add(StringArray[i]);
			}
			return arrlist;
		}

		public static void LoadDropDownListTarget(DropDownList ddl)
		{
			string[] myArr = new string[] { "_self", "_blank" };
			ddl.DataSource = StringArray2ArrayList(myArr);
			ddl.DataBind();
		}

		public static void LoadDropDownListNumber(DropDownList ddl, int BeginNumber, int EndNumber)
		{
			for (int i = BeginNumber; i <= EndNumber; i++)
			{
				ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
			}
		}

		public static void LoadDropDownListPosition(DropDownList ddl)
		{
			string[] myArr = new string[] { "1,Logo", "2,Banner giữa", "3,Đối tác", "4,Quảng cáo trái" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static string ShowAdvertisePosition(string Position)
		{
			string strString = "";
			string[] myArr = new string[] { "1,Logo", "2,Banner giữa", "3,Đối tác", "4,Quảng cáo trái" };
			char[] splitter = { ',', ';' };
			for (int i = 0; i < myArr.Length; i++)
			{
				string[] arr = myArr[i].Split(splitter);
				if (arr[0].Equals(Position))
				{
					strString = arr[1];
					break;
				}
			}
			return strString;
		}
		public static void LoadDropDownListYesNo(DropDownList ddl)
		{
			string[] myArr = new string[] { "1,Yes", "0,No" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static void LoadDropDownListCoKhong(DropDownList ddl)
		{
			string[] myArr = new string[] { "1,Có", "0,Không" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static string ShowProPriority(string Priority)
		{
			return Priority == "2" ? "Xuất hiện trang chủ" : "Bình thường";
		}

		public static void LoadDropProPriority(DropDownList ddl)
		{
			string[] myArr = new string[] { "0, -- Tất cả -- ", "1,Bình thường", "2,Xuất hiện trang chủ" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static void LoadDropDownListFilterActive(DropDownList ddl)
		{
			string[] myArr = new string[] { ", -- Tất cả -- ", "1,Hiển thị", "0,Ẩn" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static void LoadDropDownListActive(DropDownList ddl)
		{
			string[] myArr = new string[] { "1,Có", "0,Không" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static void LoadDropDownListPagePosition(DropDownList ddl)
		{
			string[] myArr = new string[] { "1,Menu trên và dưới", "2,Menu trên", "3,Menu dưới" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static string ShowPagePosition(string Position)
		{
			return Position == "1" ? "Menu trên và dưới" : Position == "2" ? "Menu trên" : "Menu dưới";
		}

		public static void LoadDropDownListLanguage(DropDownList ddl)
		{
			string[] myArr = new string[] { "vi,Việt Nam", "en,English" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static string ShowLanguage(string Position)
		{
			return Position == "en" ? "English" : "Việt Nam";
		}

		public static void LoadDropDownListNewsPosition(DropDownList ddl)
		{
			string[] myArr = new string[] { "2,Bên dưới banner", "3,Trang chủ", "4,Tin chạy banner" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static string ShowNewsPosition(string Position)
		{
			switch (Position)
			{
				case "2":
					return "Bên dưới banner";
				case "3":
					return "Trang chủ";
				case "4":
					return "Tin chạy banner";
				default:
					return "Bình thường";
			}
		}

		public static void LoadDropDownListPageType(DropDownList ddl)
		{
			string[] myArr = new string[] { "1,Trang liên kết", "2,Trang nội dung" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static void LoadDropDownListAdvertiseType(DropDownList ddl)
		{
			string[] myArr = new string[] { "1,Hình ảnh", "2,Nội dung" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static string ShowPageType(string ActiveCode)
		{
			return ActiveCode == "1" ? "Trang liên kết" : "Trang nội dung";
		}

		public static void LoadDropDownListSupportType(DropDownList ddl)
		{
			string[] myArr = new string[] { "1,Yahoo messenger", "2,Skype" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static string ShowSupportType(string Type)
		{
			return Type == "1" ? "Yahoo messenger" : Type == "2" ? "Skype" : "Google talk";
		}
		public static string Format_Price(string Price, string unit)
		{
			Price = Price.Replace(".", "");
			Price = Price.Replace(",", "");
			string tmp = "";
			while (Price.Length > 3)
			{
				tmp = "." + Price.Substring(Price.Length - 3) + tmp;
				Price = Price.Substring(0, Price.Length - 3);
			}
			tmp = Price + tmp;
			return tmp + " " + unit;
		}

		public static string GetContent(string URL)
		{
			string str = string.Empty;
			HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(URL);
			myRequest.Method = "GET";
			WebResponse myResponse = myRequest.GetResponse();
			StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
			str = sr.ReadToEnd();
			sr.Close();
			myResponse.Close();
			return str;
		}

		public static string GetContent(string URL, string strStart, string strEnd)
		{
			string Content = GetContent(URL);
			int pStart = Content.IndexOf(strStart);
			int pEnd = Content.IndexOf(strEnd);
			string strReturn = Content.Substring(pStart, pEnd - pStart);
			return StripATag(strReturn);
		}
		public static string StripATag(string text)
		{
			return Regex.Replace(text, @"<a[^>]*?href\s*=\s*[""']?([^'"" >]+?)[ '""]?/?>|<.a*?>", string.Empty);
		}
		public static string GeneralDetailUrl(string prefix, string group_name, string id, string pro_name)
		{
			string strUrl = string.Empty;
			strUrl = "/" + prefix + "/" + StringClass.NameToTag(group_name) + "/" + id + "/" + StringClass.NameToTag(pro_name);
			return strUrl;
		}
		public static string GeneralGroupUrl(string prefix, string id, string group_name)
		{
			string strUrl = string.Empty;
			strUrl = "/" + prefix + "/" + id + "/" + StringClass.NameToTag(group_name);
			return strUrl;
		}

		public static DataTable ModifyData(DataTable dt)
		{
			dt.Columns.Add("No", typeof(Int32));
			dt.Columns.Add("Link", typeof(string));
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				DataRow dr = dt.Rows[i];
				dr["No"] = (i + 1);
				dr["Link"] = PageHelper.GeneralDetailUrl(Consts.CON_TIN_TUC, dr["GroupTagNews"].ToString(), dr["Id"].ToString(), dr["Name"].ToString());
			}
			return dt;
		}
		public static DataTable ModifyDataGroup(DataTable dt)
		{
			dt.Columns.Add("No", typeof(Int32));
			dt.Columns.Add("Link", typeof(string));
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				DataRow dr = dt.Rows[i];
				dr["No"] = (i + 1);
				dr["Link"] = PageHelper.GeneralGroupUrl(Consts.CON_TIN_TUC, dr["Id"].ToString(), dr["Name"].ToString());
			}
			return dt;
		}
	}
}
