using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MyWeb.Business;
using MyWeb.Common;
using MyWeb.Data;

namespace MyWeb
{
    public partial class DefaultMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!IsPostBack)
			{
				try
				{
					DataTable dtDoiTac = AdvertiseService.Advertise_GetByPosition("3");
					rptDoiTac.DataSource = dtDoiTac;
					rptDoiTac.DataBind();

					DataTable dtSupport = SupportService.Support_GetByTop("2", "Active=1", "");
					if (dtSupport.Rows.Count > 0)
					{
						for (int i = 0; i < dtSupport.Rows.Count; i++)
						{
							DataRow dr = dtSupport.Rows[i];
							if (i == dtSupport.Rows.Count - 1)
							{
								ltrName.Text += string.Format("{0}: {1}", dr["Name"].ToString(), dr["Phone"].ToString());
							}
							else
							{
								ltrName.Text += string.Format("{0}: {1} | ", dr["Name"].ToString(), dr["Phone"].ToString());
							}
							
						}
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