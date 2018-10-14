using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Feri_WebApplication.Areas.MyArea.Controllers
{
    public partial class MyHomeController : Controller
    {
        // GET: MyArea/Home
        public virtual ActionResult MyIndex()
        {
            return (Content("New area"));
        }
    }
}