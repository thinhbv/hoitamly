using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Globalization;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : Page
{
	public BasePage()
	{
		//
		// TODO: Add constructor logic here
		//
        
	}

    protected override void InitializeCulture()
    {
        string lang = String.Empty;
        HttpCookie cookie = Request.Cookies["CurrentLanguage"];
        if (cookie != null && cookie.Value != null)
        {
            lang = cookie.Value;
            CultureInfo Cul = CultureInfo.CreateSpecificCulture(lang);
            System.Threading.Thread.CurrentThread.CurrentUICulture = Cul;
            System.Threading.Thread.CurrentThread.CurrentCulture = Cul;
        }
        else
        {
            lang = "vi";
            CultureInfo Cul = CultureInfo.CreateSpecificCulture(lang);
            System.Threading.Thread.CurrentThread.CurrentUICulture = Cul;
            System.Threading.Thread.CurrentThread.CurrentCulture = Cul;

            HttpCookie cookie_new = new HttpCookie("CurrentLanguage");
            cookie_new.Value = lang;
            cookie_new.Expires = DateTime.Now.AddMonths(6);
            Response.SetCookie(cookie_new);
        }

        base.InitializeCulture();
    }
}