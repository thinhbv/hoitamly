using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWeb.Controls
{
	public partial class U_Language : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				HttpCookie cookie = Request.Cookies["CurrentLanguage"];
				if (cookie != null && cookie.Value != null)
				{
					if (cookie.Value.IndexOf("en") >= 0)
					{
						ImgBtn_en.Enabled = false;
						ImgBtn_vi.Enabled = true;
					}
					else
					{
						ImgBtn_en.Enabled = true;
						ImgBtn_vi.Enabled = false;
					}
				}
			}
		}
		protected void ImgBtn_En_Click(object sender, ImageClickEventArgs e)
		{
			HttpCookie cookie = new HttpCookie("CurrentLanguage");
			cookie.Value = "en";
			cookie.Expires = DateTime.Now.AddMonths(6);
			Response.SetCookie(cookie);
			Response.Redirect(Request.RawUrl);
		}
		protected void ImgBtn_Vi_Click(object sender, ImageClickEventArgs e)
		{
			HttpCookie cookie = new HttpCookie("CurrentLanguage");
			cookie.Value = "vi";
			cookie.Expires = DateTime.Now.AddMonths(6);
			Response.SetCookie(cookie);
			Response.Redirect(Request.RawUrl);
		}
	}
}