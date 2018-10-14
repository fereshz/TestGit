using System.Web.Mvc;

namespace Feri_WebApplication.Areas.MyArea
{
    public class MyAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MyArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "MyDefault",
                url: "MyArea/{controller}/{action}/{id}",
                defaults: new { controller = "MyHome", action = "MyIndex", id = UrlParameter.Optional },
                namespaces: new[] { "Feri_WebApplication.Areas.MyArea.Controllers" }
            );
        }
    }
}