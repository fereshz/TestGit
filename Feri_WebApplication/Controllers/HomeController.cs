using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Feri_WebApplication.Controllers
{
    public partial class HomeController : Controller
    {
        // GET: Home
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ViewResult edit()
        {
            return (View());
        }

        public virtual ViewResult Test()
        {
            //RedirectToAction(routeValues:new { Areas = "MyArea" }, controllerName: "MyHome", actionName: "MyIndex");
            ViewBag.title = "alllli";
            return (View());

        }

        public virtual ViewResult Disply(string name)
        {
            ViewBag.Name = name;
            return (View());
        }

    }
}