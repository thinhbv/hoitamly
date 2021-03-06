﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MyWeb.Business;
using MyWeb.Common;
using MyWeb.Data;

namespace MyWeb.Controls
{
    public partial class Footer : System.Web.UI.UserControl
    {
		protected string Lang = "vi";
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
					DataTable dtConfig = ConfigService.Config_GetByTop("1", "Language='" + Lang + "'", "");
					if (dtConfig.Rows.Count > 0)
					{
						ltrInfo.Text = dtConfig.Rows[0]["Copyright"].ToString();
					}
					DataTable dt = PageService.Page_GetByTop("", "Active = 1 AND Position IN (1,3) AND Language='" + Lang + "'", "Ord");
					if (dt.Rows.Count > 0)
					{
						rptMenu.DataSource = dt;
						rptMenu.DataBind();
					}
					dt.Clear();
					dt.Dispose();
				}
				catch (Exception ex)
				{
					MailSender.SendMail("", "", "Error System", ex.Message);
				}
            }
        }
    }
}