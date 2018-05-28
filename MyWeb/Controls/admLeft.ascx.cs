using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWeb.Common;

namespace MyWeb.Controls
{
    public partial class admLeft : System.Web.UI.UserControl
    {
        private const string default_path_file = "/Admin/Default.aspx";  
        public string LastLoadedPage
        {
            get {  return ViewState["LastLoaded"] as string; }
            set { ViewState["LastLoaded"] = value; } 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
				if (Session["IsAdmin"] == null || Session["IsAdmin"].ToString() == "0")
				{
					table1.Visible = false;
					div1.Visible = false;
				}
				else
				{
					table1.Visible = true;
					div1.Visible = true;
				}
                LastLoadedPage = default_path_file;
            }
        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
			try
			{
				LinkButton lbt = (LinkButton)sender;
				LastLoadedPage = lbt.ID.Replace("lbt", "/Admins/") + ".aspx";
				Panel currentPanel = (Panel)lbt.Parent;
				Session["currentPanel"] = currentPanel.ID;
				Response.Redirect(LastLoadedPage, false);
			}
			catch (Exception ex)
			{
				MailSender.SendMail("", "", "Error System", ex.Message);
			}
        }
    }
}