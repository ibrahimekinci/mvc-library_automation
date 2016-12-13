using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mvc_Kutuphane
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session == null) return;
            var cultureInfo = (CultureInfo)Session["Culture"];
            if (cultureInfo == null)
            {
                var languageName = "tr";
                cultureInfo = new CultureInfo(languageName);
                Session["Culture"] = cultureInfo;
            }
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
        }

        //oturum açıldığında buraya girer
        protected void Session_Start(Object sender, EventArgs e)
        {
            if (Application["onlineZiyaretci"] == null)
                Application["onlineZiyaretci"] = 1;
            else
            {
                int deger = (int)Application["onlineZiyaretci"];
                deger += 1;
                Application["onlineZiyaretci"] = deger;
            }
        }

        protected void Session_End(Object sender, EventArgs e)
        {
            /* Oturum kapatıldığında devereye giren bu olayda, uygulama seviyesindeki Application nesnesinde saklanan değerini 1 azaltıyoruz. Böylece online ziyaretçi sayısını 1 azaltmış oluyoruz.*/
            int deger = (int)Application["onlineZiyaretci"];
            deger -= 1;
            Application["onlineZiyaretci"] = deger;
        }
    }
}
