using System;
using System.Web;
using MyWeb.Data;
using MyWeb.Business;
using MyWeb.Common;
using System.Collections.Generic;

namespace MyWeb.Modules.Images
{
	public partial class ImageList : BasePage
	{
		protected string GroupId = string.Empty;
		private string GroupName = string.Empty;
		private string Lang = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
				if (Page.RouteData.Values["GroupId"] != null)
				{
					GroupId = Page.RouteData.Values["GroupId"] as string;
				}
				if (Lang == "en")
				{
					Page.Title = "VietNam Association Of Social Psychology";
				}
				else
				{
					Page.Title = "Hội Tâm Lý Học Xã Hội Việt Nam";
				}
				if (!IsPostBack)
				{
					if (Request.Cookies["CurrentLanguage"] != null)
					{
						Lang = Request.Cookies["CurrentLanguage"].Value;
					}
					List<GroupImages> listGrp = GroupImagesService.GroupImages_GetByTop("", "Active=1 AND Language='" + Lang + "'", "Ord");
					if (listGrp.Count > 0)
					{
						if (string.IsNullOrEmpty(GroupId))
						{
							GroupId = listGrp[0].Id;
						}
						for (int i = 0; i < listGrp.Count; i++)
						{
							if (listGrp[i].Id == GroupId)
							{
								GroupName = listGrp[i].Name;
								Page.Title = GroupName;
								break;
							}
						}
						rptGroupImages.DataSource = listGrp;
						rptGroupImages.DataBind();
						List<Data.Images> listImages = ImagesService.Images_GetByTop("", "Active = 1 AND GroupId = '" + GroupId + "'", "Ord");
						for (int i = 0; i < listImages.Count; i++)
						{
							//ltrImages.Text += "<a href=http://unitegallery.net>\n";
							ltrImages.Text += "<img alt='" + GroupName + "'\n";
							ltrImages.Text += "src='" + StringClass.ThumbImage(listImages[i].Image) + "'\n";
							ltrImages.Text += "data-image='" + listImages[i].Image + "'\n";
							ltrImages.Text += "style='display:none'>";
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